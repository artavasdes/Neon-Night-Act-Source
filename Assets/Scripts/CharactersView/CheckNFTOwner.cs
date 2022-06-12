using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;
using System.Threading.Tasks;

public class CheckNFTOwner
{
    public string chain = "polygon";
    public string network = "mainnet";
    public string contract = "0x3a686FaBCE1b315950D39367131C4C17B1BaBF23";
    public int tokenIdAmount = 12;
    public Dictionary<int, bool> ownerDic = new Dictionary<int, bool>();

    public async Task CheckOwner(string account)
    {
        for(int i = 0; i <= tokenIdAmount; i++){
            BigInteger balanceOf = await ERC1155.BalanceOf(chain, network, contract, account, i.ToString());
            if(balanceOf == 1){
                ownerDic.Add(i,true);
            }
            else{
                ownerDic.Add(i, false);
            }            
        }    
        await Task.Yield();
    }
}
