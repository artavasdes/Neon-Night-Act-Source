using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class AltCharacterDisplay : MonoBehaviour
{    
    [SerializeField]
    public GameObject ParentPanel;
    public static Dictionary<GameObject, int> altCharactersDictionary = new Dictionary<GameObject, int>();
    public static int chosenCharacter;

    void Awake(){
        if(CheckNFTOwner.validAddress == false){
            for(int i = 0; i < 14; i++){
                string cgPath = "Headshots/char_" + i + "_icon";
                Texture2D CG = Resources.Load<Texture2D>(cgPath);
                Sprite cgSprite = Sprite.Create(CG, new Rect(0.0f, 0.0f, CG.width, CG.height), new Vector2(0f, 0f), 100.0f);
                GameObject button = ParentPanel.transform.GetChild(i).gameObject;
                Button buttonClick = button.AddComponent<Button>();
                buttonClick.transform.SetParent(ParentPanel.transform);
                buttonClick.onClick.AddListener(() => OnClick(button));
                button.GetComponent<Image>().sprite = cgSprite;
                
                if(i == 13){
                    button.GetComponent<Button>().interactable = true;
                }
                else{
                    button.GetComponent<Button>().interactable = false;
                }
                altCharactersDictionary.Add(button,i);
            }
        }
        else{
            for(int i = 0; i < 14; i++){
                if(i == 13){
                    string cgPath = "Headshots/char_" + i + "_icon";
                    Texture2D CG = Resources.Load<Texture2D>(cgPath);
                    Sprite cgSprite = Sprite.Create(CG, new Rect(0.0f, 0.0f, CG.width, CG.height), new Vector2(0f, 0f), 100.0f);
                    GameObject button = ParentPanel.transform.GetChild(i).gameObject;
                    Button buttonClick = button.AddComponent<Button>();
                    buttonClick.transform.SetParent(ParentPanel.transform);
                    buttonClick.onClick.AddListener(() => OnClick(button));
                    button.GetComponent<Image>().sprite = cgSprite;
                    button.GetComponent<Button>().interactable = true;
                    altCharactersDictionary.Add(button,i);
                }
                else if(CheckNFTOwner.ownerDic[i] == true){
                    string cgPath = "Headshots/char_" + i + "_icon";
                    Texture2D CG = Resources.Load<Texture2D>(cgPath);
                    Sprite cgSprite = Sprite.Create(CG, new Rect(0.0f, 0.0f, CG.width, CG.height), new Vector2(0f, 0f), 100.0f);
                    GameObject button = ParentPanel.transform.GetChild(i).gameObject;
                    Button buttonClick = button.AddComponent<Button>();
                    buttonClick.transform.SetParent(ParentPanel.transform);
                    buttonClick.onClick.AddListener(() => OnClick(button));
                    button.GetComponent<Image>().sprite = cgSprite;
                    button.GetComponent<Button>().interactable = true;
                    altCharactersDictionary.Add(button,i);                   
                }
                else{
                    string cgPath = "Headshots/char_" + i + "_icon";
                    Texture2D CG = Resources.Load<Texture2D>(cgPath);
                    Sprite cgSprite = Sprite.Create(CG, new Rect(0.0f, 0.0f, CG.width, CG.height), new Vector2(0f, 0f), 100.0f);
                    GameObject button = ParentPanel.transform.GetChild(i).gameObject;
                    Button buttonClick = button.AddComponent<Button>();
                    buttonClick.transform.SetParent(ParentPanel.transform);
                    buttonClick.onClick.AddListener(() => OnClick(button));
                    button.GetComponent<Image>().sprite = cgSprite;
                    button.GetComponent<Button>().interactable = false;
                    altCharactersDictionary.Add(button,i);
                }
            }
        }
    }

    public void OnClick(GameObject characterObject){
        int characterId = altCharactersDictionary[characterObject];
        Debug.Log("Clicked: " + characterId);
        chosenCharacter = characterId;
        SceneManager.LoadScene(sceneName:"ConnectionScene");
    }
}
