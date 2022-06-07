using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EthereumWallettInputScript : MonoBehaviour
{
    public string walletAddress;

    private Text text;
    public void ReadStringInput(string s){
        if(s.Length == 42){
            Debug.Log("Valid Address");
            walletAddress = s;
            CheckNFTOwner nftOwnerCheck = new CheckNFTOwner();        
            nftOwnerCheck.CheckOwner(walletAddress);
        }
        else{

        }
    }
}
