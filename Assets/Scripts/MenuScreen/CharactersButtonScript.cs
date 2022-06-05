using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharactersButtonScript : MonoBehaviour
{
    public void characterViewSceneChange(){
        SceneManager.LoadScene("CharactersView");
    }
}
