using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameFlow : ScriptableObject {

    public string Menu;
    public string[] levels;


    public string GetCurrentLevel(string currentScene){
        int index = Array.FindIndex(levels,(string obj) => obj == currentScene);
        return levels[index];
    }

    public string GoToNextLevel(string currentScene)
    {
        int index = Array.FindIndex(levels, (string obj) => obj == currentScene);
        index++;
        return index >= levels.Length ? Menu : levels[index];
    }

    public string MainMenu(){
        return Menu;
    }

}
