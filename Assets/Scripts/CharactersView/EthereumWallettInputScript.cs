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

    public void ReadStringInput(string s){
        if(s.Length == 42){
            Debug.Log("Valid Address");
            walletAddress = s;
            CheckNFTOwner nftOwnerCheck = new CheckNFTOwner();        
            nftOwnerCheck.CheckOwner(walletAddress);
            validMessageChange.text = "Valid Address";
        }
        else{
            validMessageChange.text = "Enter a Valid Ethereum Address Please";
        }
    }
}
