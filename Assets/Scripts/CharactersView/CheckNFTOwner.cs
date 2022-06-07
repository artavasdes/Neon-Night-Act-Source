using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class CheckNFTOwner : MonoBehaviour
{
    public string chain = "ethereum";
    public string network = "rinkeby";
    public string contract = "0x5D5220AC4aE1615C6ff524490e3b23988190599A";
    public string account = "0x36F4D7ff8C442ea1eB38F60BeC8e8177101134BC";
    public string tokenId = "10";

    async void CheckOwner()
    {
        BigInteger balanceOf = await ERC1155.BalanceOf(chain, network, contract, account, tokenId);
        Debug.Log(balanceOf);
    }
}
