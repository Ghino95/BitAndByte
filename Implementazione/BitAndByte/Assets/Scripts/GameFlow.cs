using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameFlow : ScriptableObject {

    public string Menu;
    public string[] levels;
    private int currentLevel;

    public GameFlow(){
        currentLevel = 0;
    }

    public string GetCurrentLevel(){
        return levels[currentLevel];
    }

    public string GoToNextLevel(){
        currentLevel++;
        return currentLevel == levels.Length ? Menu : levels[currentLevel];
    }

    public string MainMenu(){
        return Menu;
    }

}
