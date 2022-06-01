using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuitButton : MonoBehaviour
{
    public UnityEvent buttonClick;

    void Awake(){
        if(buttonClick == null){
            buttonClick = new UnityEvent();
        }
    }

    void OnMouseDown(){
        Application.Quit();
    }
    
}
