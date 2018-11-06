using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameFlow : ScriptableObject {

    public string[] levels;

    public string GetLevel(int number){
        return levels[number];
    }

    public int NumberOfScene(){
        return levels.Length;
    }

}
