using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DiagolImages : ScriptableObject {

    public Sprite[] Images;

    public Sprite GetImagesNumber(int index){
        return index < Images.Length ? Images[index] : null;
    }
	
}
