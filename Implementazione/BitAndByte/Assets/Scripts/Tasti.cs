using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Tasti : ScriptableObject {

    public List<CustomDictionary> Joypad;
    public List<CustomDictionary> Keyboard;


    public Sprite GetImageButtonJoypad(string key)
    {
        foreach (CustomDictionary temp in Joypad)
        {
            if (temp.key == key)
            {
                return temp.Image;
            }
        }
        return null;
    }

    public Sprite GetImageButtonKeyboard(string key)
    {
        foreach (CustomDictionary temp in Keyboard)
        {
            if (temp.key == key)
            {
                return temp.Image;
            }
        }
        return null;
    }


}

[System.Serializable]
public class CustomDictionary
{
    public string key;
    public Sprite Image;

}
