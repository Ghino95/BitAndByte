using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHUD : MonoBehaviour {

    public Tasti ImagesKey;
    private Image Image;

    private void Awake()
    {
        Image = GetComponent<Image>();
        if (Input.GetJoystickNames().Length > 0)
        {
            Image.sprite = ImagesKey.GetImageButtonJoypad(name);
        }
        else
        {
            Image.sprite = ImagesKey.GetImageButtonKeyboard(name);
        }
    }


}
