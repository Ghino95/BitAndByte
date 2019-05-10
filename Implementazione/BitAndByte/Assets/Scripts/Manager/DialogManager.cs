using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    private DiagolImages Images;
    private int count;

    public GameObject Blur;
    public GameObject ReadMe;
    public Image CurrentImage;

    public static DialogManager instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (ReadMe.activeInHierarchy && Input.GetButtonDown("Jump"))
        {
            NextImage();
        }
    }

    void NextImage()
    {

        Sprite image = Images.GetImagesNumber(count);

        if (image != null)
        {
            CurrentImage.sprite = image;
            count++;
        }
        else
        {
            ReadMe.SetActive(false);
            Blur.SetActive(false);
            Time.timeScale = 1;
            EventManager.TriggerEvent("ResumePlayer");
        }
    }

    public void StartDialog(DiagolImages Images)
    {
        this.Images = Images;

        Time.timeScale = 0;
        count = 0;
        EventManager.TriggerEvent("PausePlayer");
        ReadMe.SetActive(true);
        Blur.SetActive(true);
        NextImage();

    }

}
