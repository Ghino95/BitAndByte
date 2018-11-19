using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{

    public GameObject can;
    public GameObject Baloon;
    public GameObject EmptyImage;

    private DiagolImages Images;
    private int count;
    private Image Current;
    private GameObject instaceBaloon;

    public static DialogManager instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        instance = this;
        instaceBaloon = null;
    }

    private void Update()
    {
        if (instaceBaloon != null && Input.GetButtonDown("Jump"))
        {
            NextImage();
        }
    }



    public void StartDialog(DiagolImages Images, GameObject NPC)
    {
        this.Images = Images;

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
            instaceBaloon = null;
            Images = null;
            Time.timeScale = 1;
            ControllerManager.instance.ResumePlayer();
        }
    }


}
