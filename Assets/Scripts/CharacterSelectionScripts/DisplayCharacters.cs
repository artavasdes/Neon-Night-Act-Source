using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayCharacters : MonoBehaviour
{
    [SerializeField]
    public GameObject ParentPanel;
    string path = Application.dataPath;

    void Awake(){
        //If address false, all images gray
        if(CheckNFTOwner.validAddress == false){
            for(int i = 0; i < 14; i++){
                string grayCGPath = "";
                if(i == 13){
                    grayCGPath = "CharacterSelectionGIFs/Normal/" + i;
                }
                else{
                    grayCGPath = "CharacterSelectionGIFs/Gray/" + i + "gray";
                }  
                Texture2D grayCG = Resources.Load<Texture2D>(grayCGPath);
                Sprite grayCGSprite = Sprite.Create(grayCG, new Rect(0.0f, 0.0f, grayCG.width, grayCG.height), new Vector2(0, 0), 100.0f);
                GameObject NewObj = new GameObject();
                Image imageRenderer = NewObj.AddComponent<Image>();
                imageRenderer.sprite = grayCGSprite;
                NewObj.GetComponent<RectTransform>().SetParent(ParentPanel.transform);
                //positioning
                if(i<5){
                    NewObj.GetComponent<RectTransform>().position = new Vector2((i*3)-6,3);
                    NewObj.GetComponent<RectTransform>().sizeDelta = new Vector2(3f, 3f);
                }
                else if(i<10){
                    NewObj.GetComponent<RectTransform>().position = new Vector2((i*3)-22,0);
                    NewObj.GetComponent<RectTransform>().sizeDelta = new Vector2(3f, 3f);
                }
                else{
                    NewObj.GetComponent<RectTransform>().position = new Vector2((i*4)-45,-3f);
                    NewObj.GetComponent<RectTransform>().sizeDelta = new Vector2(3f, 3f);
                }                        
            }
        } 
        //if address correct
        else{
            for(int i = 0; i < 13; i++){
                //if nft is owned
                if (CheckNFTOwner.ownerDic[i] == true){
                    string cgPath = "CharacterSelectionGIFs/Normal/" + i;
                    Texture2D CG = Resources.Load<Texture2D>(cgPath);
                    Sprite cgSprite = Sprite.Create(CG, new Rect(0.0f, 0.0f, CG.width, CG.height), new Vector2(0f, 0f), 100.0f);

                    GameObject NewObj = new GameObject();

                    //Setting up button
                    Button selectionButton = NewObj.AddComponent<Button>();
                    ColorBlock colorVar = selectionButton.colors;
                    colorVar.highlightedColor = new Color(0.6235294f, 0.1490196f, 0.1490196f);
                    selectionButton.colors = colorVar;

                    Image imageRenderer = NewObj.AddComponent<Image>();
                    imageRenderer.sprite = cgSprite;

                    NewObj.GetComponent<RectTransform>().SetParent(ParentPanel.transform);
                    if(i<5){
                        NewObj.GetComponent<RectTransform>().position = new Vector2((i*3)-6,3);
                        NewObj.GetComponent<RectTransform>().sizeDelta = new Vector2(3f, 3f);
                    }
                    else if(i<10){
                        NewObj.GetComponent<RectTransform>().position = new Vector2((i*3)-22,0);
                        NewObj.GetComponent<RectTransform>().sizeDelta = new Vector2(3f, 3f);
                    }
                    else{
                        NewObj.GetComponent<RectTransform>().position = new Vector2((i*4)-45,-3f);
                        NewObj.GetComponent<RectTransform>().sizeDelta = new Vector2(3f, 3f);
                    } 
                }
                else{
                    string grayCGPath = "CharacterSelectionGIFs/Gray/" + i + "gray";
                    Texture2D grayCG = Resources.Load<Texture2D>(grayCGPath);
                    Sprite grayCGSprite = Sprite.Create(grayCG , new Rect(0.0f, 0.0f, grayCG.width, grayCG.height), new Vector2(0f, 0f), 100.0f);
                    GameObject NewObj = new GameObject();
                    Image imageRenderer = NewObj.AddComponent<Image>();
                    imageRenderer.sprite = grayCGSprite;
                    NewObj.GetComponent<RectTransform>().SetParent(ParentPanel.transform);
                    if(i<5){
                        NewObj.GetComponent<RectTransform>().position = new Vector2((i*3)-6,3);
                        NewObj.GetComponent<RectTransform>().sizeDelta = new Vector2(3f, 3f);
                    }
                    else if(i<10){
                        NewObj.GetComponent<RectTransform>().position = new Vector2((i*3)-22,0);
                        NewObj.GetComponent<RectTransform>().sizeDelta = new Vector2(3f, 3f);
                    }
                    else{
                        NewObj.GetComponent<RectTransform>().position = new Vector2((i*4)-45,-3f);
                        NewObj.GetComponent<RectTransform>().sizeDelta = new Vector2(3f, 3f);
                    }
                }
                //Add button for Shiki

            }
        }           
    }
}
