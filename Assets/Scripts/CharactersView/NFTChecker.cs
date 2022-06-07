using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class NFTChecker : MonoBehaviour
{
    public string chain = "ethereum";
    public string network = "rinkeby";
    public string contract = "0x5D5220AC4aE1615C6ff524490e3b23988190599A";
    public string tokenId = "0";

    private void Start(){
        GetNFTImage();
    }

    public class Response {
        public string image;
    }

    async private void GetNFTImage(){
        string uri = await ERC1155.URI(chain, network, contract, tokenId);
        Debug.Log(uri);

        UnityWebRequest webRequest = UnityWebRequest.Get(uri);
        await webRequest.SendWebRequest();
        Response data = JsonUtility.FromJson<Response>(System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data));

        string imageUri = data.image;

        Debug.Log(imageUri);

        //Succesfully pulls correct URI

        UnityWebRequest textureRequest = UnityWebRequestTexture.GetTexture(imageUri);

        await textureRequest.SendWebRequest();
        if(textureRequest == null){
            Debug.Log("texture request is null");
        }

        //texture 2d null for some reason
        Texture2D texture2d = DownloadHandlerTexture.GetContent(textureRequest);

        //Texture2D texture2d = (Texture2D) textureOriginal;
        if(texture2d == null){
            Debug.Log("texture 2d null");
        }
        // Sprite mySprite = Sprite.Create(texture2d, new Rect(0.0f, 0.0f, texture2d.width, texture2d.height), new Vector2(0.5f, 0.5f), 100.0f);
        
        // SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        // spriteRenderer.sprite = mySprite;
    }
}
