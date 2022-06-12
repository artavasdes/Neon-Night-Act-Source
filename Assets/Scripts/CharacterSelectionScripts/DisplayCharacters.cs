using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class DisplayCharacters : MonoBehaviour
{

    [SerializeField]
    public GameObject ParentPanel;

    void Awake(){
        string path = Application.dataPath;
        if(CheckNFTOwner.validAddress == false){
            for(int i = 0; i < 14; i++){
                string grayCGPath = "";
                if(i == 13){
                    grayCGPath = "Assets/ArtAssets/CharacterSelectionGIFs/Normal/" + i + ".gif";
                }
                else{
                    grayCGPath = "Assets/ArtAssets/CharacterSelectionGIFs/Gray/" + i + "gray.gif";
                }  

                Texture2D grayCG = (Texture2D)AssetDatabase.LoadAssetAtPath(grayCGPath, typeof(Texture2D));
                Sprite grayCGSprite = Sprite.Create(grayCG, new Rect(0.0f, 0.0f, grayCG.width, grayCG.height), new Vector2(0.5f, 0.5f), 100.0f);
                GameObject NewObj = new GameObject();
                Image imageRenderer = NewObj.AddComponent<Image>();

                imageRenderer.sprite = grayCGSprite;

                NewObj.GetComponent<RectTransform>().SetParent(ParentPanel.transform);

                //positioning
                if(i == 0){
                    NewObj.GetComponent<RectTransform>().position = new Vector2((i*4)-8,2.5f);
                    NewObj.GetComponent<RectTransform>().sizeDelta = new Vector2(3.5f, 3.5f);
                }
            }
        }            
    }
}
