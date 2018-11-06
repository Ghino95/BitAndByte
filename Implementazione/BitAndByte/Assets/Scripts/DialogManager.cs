using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

    public static DialogManager instance
    {
        get;
        private set;
    }

    public GameObject NPC;
    public GameObject can;
    public GameObject Baloon;
    public GameObject EmptyImage;
    public Sprite[] Contenuto;

    private int count;
    private Image Current;
    private GameObject instaceBaloon;


    private void Awake()
    {
        EventManager.StartListening("OpenJail",StartDialog);
        instaceBaloon = null;
    }

    private void Update()
    {
        if(instaceBaloon != null && Input.GetKeyDown(KeyCode.P)){
            NextImage();
        }
    }



    void StartDialog(){
        Time.timeScale = 0;
        instaceBaloon = Instantiate(Baloon);
        instaceBaloon.transform.SetParent(can.transform, false);
        instaceBaloon.transform.SetPositionAndRotation(NPC.transform.position + new Vector3(2,2,0), Quaternion.identity);

        GameObject instaceEmptyImage = Instantiate(EmptyImage);
        instaceEmptyImage.transform.SetParent(instaceBaloon.transform, false);
        Current = instaceEmptyImage.GetComponent<Image>();
        Current.preserveAspect = true;
        Current.sprite = Contenuto[count];
        count++;
    }

    void NextImage(){
        if(count < Contenuto.Length){
            Current.sprite = Contenuto[count];
            count++;
        }else{
            Destroy(instaceBaloon);
            instaceBaloon = null;
            Time.timeScale = 1;
        }
    }

    private void OnDestroy()
    {
        EventManager.StopListening("OpenJail", StartDialog);
    }

}
