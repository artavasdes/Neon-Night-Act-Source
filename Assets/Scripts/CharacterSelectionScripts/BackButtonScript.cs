using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void backFromSelection()
    {
        SceneManager.LoadScene(sceneName:"MainMenu");
    }
}
