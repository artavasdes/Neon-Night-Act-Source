using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EthereumWallettInputScript : MonoBehaviour
{
    public string walletAddress;
    [SerializeField]
    public TextMeshProUGUI validMessageChange;
    public Dictionary<string, string> imagePaths = new Dictionary<string, string>();

    public async void ReadStringInput(string s){
        //LoadImages();
        string path = Application.dataPath;
        Debug.Log(path);
        if(s.Length == 42){
            Debug.Log("Valid Address");
            walletAddress = s;
            CheckNFTOwner nftOwnerCheck = new CheckNFTOwner();  

            await nftOwnerCheck.CheckOwner(walletAddress);

            Debug.Log("count" + nftOwnerCheck.ownerDic.Count);

            foreach (KeyValuePair<int, bool> kvp in nftOwnerCheck.ownerDic)
                Debug.Log("Key = {0}, Value = {1}" + kvp.Key + kvp.Value);

            CharacterDisplayer(nftOwnerCheck.ownerDic);

            validMessageChange.text = "Valid Address";
        }
        else{
            validMessageChange.text = "Please Enter a Valid Ethereum Address";
        }
    }

    private void CharacterDisplayer(Dictionary<int, bool> nftDic){

    }

    private void LoadImages(){
        for(int i = 0; i <= 14; i++){
            string cgPath = "";
            string grayCGPath = "";
            imagePaths.Add(cgPath,grayCGPath);        
        }
    }
}
