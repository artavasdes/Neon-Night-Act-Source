using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyAudio : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Awake(){
        audioSource.Play();
        // Scene currentScene = SceneManager.GetActiveScene ();
        // string sceneName = currentScene.name;
        // if(sceneName == "CharacterSelection"){
        //     DontDestroyOnLoad(transform.gameObject);
        // }
        // else if(sceneName == "CharactersView"){
        //     DontDestroyOnLoad(transform.gameObject);
        // }
        // else if(sceneName == "MainMenu"){
        //     DontDestroyOnLoad(transform.gameObject);
        // }
        // else{
        //     Destroy(transform.gameObject);
        // }
        
    }
}
