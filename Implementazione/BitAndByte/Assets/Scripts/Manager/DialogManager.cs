using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{

    public GameObject NPC;
    public GameObject can;
    public GameObject Baloon;
    public GameObject EmptyImage;
    //public Sprite[] Contenuto;

    public DiagolImages Images;

    private int count;
    private Image Current;
    private GameObject instaceBaloon;


    private void Awake()
    {
        EventManager.StartListening("OpenJail", StartDialog);
        instaceBaloon = null;
    }

    private void Update()
    {
        if (instaceBaloon != null && Input.GetButtonDown("Jump"))
        {
            NextImage();
        }
    }



    void StartDialog()
    {
        Time.timeScale = 0;
        count = 0;
        ControllerManager.instance.PausePlayer();
        instaceBaloon = Instantiate(Baloon);
        instaceBaloon.transform.SetParent(can.transform, false);
        instaceBaloon.transform.SetPositionAndRotation(NPC.transform.position + new Vector3(2, 2, 0), Quaternion.identity);


        GameObject instaceEmptyImage = Instantiate(EmptyImage);
        instaceEmptyImage.transform.SetParent(instaceBaloon.transform, false);
        Current = instaceEmptyImage.GetComponent<Image>();
        Current.preserveAspect = true;
        NextImage();
    }

    void NextImage()
    {

        Sprite image = Images.GetImagesNumber(count);

        if (image != null)
        {
            Current.sprite = image;
            count++;
        }
        else
        {
            Destroy(instaceBaloon);
            Time.timeScale = 1;
            ControllerManager.instance.ResumePlayer();
            EventManager.StopListening("OpenJail", StartDialog);
        }
    }

    private void OnDestroy()
    {
        EventManager.StopListening("OpenJail", StartDialog);
    }

}
