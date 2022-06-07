using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class CheckNFTOwner
{
    public string chain = "ethereum";
    public string network = "rinkeby";
    public string contract = "0x5D5220AC4aE1615C6ff524490e3b23988190599A";
    public int tokenIdAmount = 5;
    public async void CheckOwner(string account)
    {
        for(int i = 0; i <= tokenIdAmount; i++){
            BigInteger balanceOf = await ERC1155.BalanceOf(chain, network, contract, account, i.ToString());
            Debug.Log(balanceOf);
        }       
    }
}
