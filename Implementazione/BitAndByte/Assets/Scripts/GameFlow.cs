using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameFlow : ScriptableObject {

    public CustomDictionaryLevel Menu;
    //public string[] levels;

    public List<CustomDictionaryLevel> levels;


    public CustomDictionaryLevel GetCurrentLevel(string currentScene){

        CustomDictionaryLevel temp = levels.Find((CustomDictionaryLevel obj) => obj.Level == currentScene);

        return temp ?? Menu;
    }

    public CustomDictionaryLevel GoToNextLevel(string currentScene)
    {
        int index = levels.FindIndex((CustomDictionaryLevel obj) => obj.Level == currentScene);
        index++;
        return index >= levels.Count ? Menu : levels[index];
    }

    public CustomDictionaryLevel MainMenu(){
        return Menu;
    }

}


[System.Serializable]
public class CustomDictionaryLevel
{
    public string Level;
    public AudioClip Audio;

}
