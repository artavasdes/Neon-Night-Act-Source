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

    public async void ReadStringInput(string s){
        if(s.Length == 42){
            Debug.Log("Valid Address");
            walletAddress = s;
            CheckNFTOwner nftOwnerCheck = new CheckNFTOwner();  

            await nftOwnerCheck.CheckOwner(walletAddress);

            Debug.Log("count" + nftOwnerCheck.ownerDic.Count);

            foreach (KeyValuePair<int, bool> kvp in nftOwnerCheck.ownerDic)
                Debug.Log("Key = {0}, Value = {1}" + kvp.Key + kvp.Value);
                
            validMessageChange.text = "Valid Address";
        }
        else{
            validMessageChange.text = "Enter a Valid Ethereum Address Please";
        }
    }
}
