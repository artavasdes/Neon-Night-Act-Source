using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class EthereumWallettInputScript : MonoBehaviour
{
    public string walletAddress;
    [SerializeField]
    public TextMeshProUGUI validMessageChange;
    public Dictionary<Sprite, Sprite> imageSprites = new Dictionary<Sprite, Sprite>();
    [SerializeField]
    public GameObject ParentPanel;
    public List<GameObject> objectsList = new List<GameObject>();

    public async void ReadStringInput(string s){
        if(s.Length == 42){
            Debug.Log("Valid Address");
            walletAddress = s;

            await CheckNFTOwner.CheckOwner(walletAddress);

            Debug.Log("count" + CheckNFTOwner.ownerDic.Count);

            foreach (KeyValuePair<int, bool> kvp in CheckNFTOwner.ownerDic)
                Debug.Log("Key = {0}, Value = {1}" + kvp.Key + kvp.Value);

            CharacterDisplayer(CheckNFTOwner.ownerDic);
            CheckNFTOwner.validAddress = true;
            validMessageChange.text = "Valid Address";
        }
        else{
            CheckNFTOwner.validAddress = false;
            MakeGray();
            validMessageChange.text = "Please Enter a Valid Ethereum Address";
        }
    }

    void Awake(){
        string path = Application.dataPath;
        for(int i = 0; i < 14; i++){
            //Obtains b/w character cg
            string grayCGPath = "";
            if(i == 13){
                grayCGPath = "Assets/ArtAssets/HighQualityCGs/Normal/" + i + "cg.png";
            }
            else{
                grayCGPath = "Assets/ArtAssets/HighQualityCGs/Gray/" + i + "gray.png";
            }           
            Texture2D grayCG = (Texture2D)AssetDatabase.LoadAssetAtPath(grayCGPath, typeof(Texture2D));
            Sprite grayCGSprite = Sprite.Create(grayCG, new Rect(0.0f, 0.0f, grayCG.width, grayCG.height), new Vector2(0.5f, 0.5f), 100.0f);
            GameObject NewObj = new GameObject();
            Image imageRenderer = NewObj.AddComponent<Image>();
            imageRenderer.sprite = grayCGSprite;
            NewObj.GetComponent<RectTransform>().SetParent(ParentPanel.transform);
            if(i == 0){
                NewObj.GetComponent<RectTransform>().position = new Vector2((i*4)-8,2.5f);
                NewObj.GetComponent<RectTransform>().sizeDelta = new Vector2(3.5f, 3.5f);
            }
            else if(i<5){
                NewObj.GetComponent<RectTransform>().position = new Vector2((i*4)-8,3);
                NewObj.GetComponent<RectTransform>().sizeDelta = new Vector2(3.5f, 3.5f);
            }
            else if(i<7){
                NewObj.GetComponent<RectTransform>().position = new Vector2((i*3)-22,0);
                NewObj.GetComponent<RectTransform>().sizeDelta = new Vector2(3.5f, 3.5f);
            }
            else if(i<10){
                NewObj.GetComponent<RectTransform>().position = new Vector2((i*3)-22,0);
                NewObj.GetComponent<RectTransform>().sizeDelta = new Vector2(4f, 4f);
            }
            else if(i == 10){
                NewObj.GetComponent<RectTransform>().position = new Vector2((i*4)-45,-3);
                NewObj.GetComponent<RectTransform>().sizeDelta = new Vector2(3.5f, 3.5f);
            }
            else if(i == 11 || i == 12){
                NewObj.GetComponent<RectTransform>().position = new Vector2((i*4)-45,-3);
                NewObj.GetComponent<RectTransform>().sizeDelta = new Vector2(2.75f, 2.75f);
            }
            else{
                NewObj.GetComponent<RectTransform>().position = new Vector2((i*4)-45,-2f);
                NewObj.GetComponent<RectTransform>().sizeDelta = new Vector2(4.5f, 4.5f);
            }            
            NewObj.SetActive(true);
            if(i != 13){
                objectsList.Add(NewObj);
            }
        }
    }

    void MakeGray(){
        string path = Application.dataPath;
        for(int i = 0; i < 13; i++){
            string grayCGPath = "Assets/ArtAssets/HighQualityCGs/Gray/" + i + "gray.png";
            Texture2D grayCG = (Texture2D) AssetDatabase.LoadAssetAtPath(grayCGPath, typeof(Texture2D));
            Sprite grayCGSprite = Sprite.Create(grayCG , new Rect(0.0f, 0.0f, grayCG.width, grayCG.height), new Vector2(0.5f, 0.5f), 100.0f);
            GameObject NewObj = objectsList[i];
            Image imageRenderer = NewObj.GetComponent<Image>();
            imageRenderer.sprite = grayCGSprite;
        }                      
    }

    private void CharacterDisplayer(Dictionary<int, bool> nftDic){
        string path = Application.dataPath;
        for(int i = 0; i < 13; i++){
            if (nftDic[i] == true){
                string cgPath = "Assets/ArtAssets/HighQualityCGs/Normal/" + i + "cg.png";
                Texture2D CG = (Texture2D) AssetDatabase.LoadAssetAtPath(cgPath, typeof(Texture2D));
                Sprite cgSprite = Sprite.Create(CG, new Rect(0.0f, 0.0f, CG.width, CG.height), new Vector2(0.5f, 0.5f), 100.0f);
                GameObject NewObj = objectsList[i];
                Image imageRenderer = NewObj.GetComponent<Image>();
                imageRenderer.sprite = cgSprite;
            }
            else{
                string grayCGPath = "Assets/ArtAssets/HighQualityCGs/Gray/" + i + "gray.png";
                Texture2D grayCG = (Texture2D) AssetDatabase.LoadAssetAtPath(grayCGPath, typeof(Texture2D));
                Sprite grayCGSprite = Sprite.Create(grayCG , new Rect(0.0f, 0.0f, grayCG.width, grayCG.height), new Vector2(0.5f, 0.5f), 100.0f);
                GameObject NewObj = objectsList[i];
                Image imageRenderer = NewObj.GetComponent<Image>();
                imageRenderer.sprite = grayCGSprite;
            }                      
        }
    }
}
