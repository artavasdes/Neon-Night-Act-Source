using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public GameObject parentCanvas;
    public int chosenCharacter = AltCharacterDisplay.chosenCharacter; 
    
    void Awake(){
        string cgPath = "Headshots/char_" + chosenCharacter + "_icon";
        Texture2D CG = Resources.Load<Texture2D>(cgPath);
        GameObject HeaderUI = parentCanvas.transform.GetChild(1).gameObject;
        
    }
}
