using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
       AudioSource audioBack = Resources.Load<AudioSource>("Audio/StageAudio/map_" + MapManager.selectedMap);
       audioBack.Play(); 
    }
}
