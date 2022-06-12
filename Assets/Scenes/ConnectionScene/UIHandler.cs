using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public void onHostButtonClick() {
      SceneManager.LoadScene("Fight Scene");
    }

    public void onConnectButtonClick() {
      SceneManager.LoadScene("Fight Scene");
    }

    public void onCodeInputChange() {
      // SceneManager.LoadScene("BattleScene");
    }
}
