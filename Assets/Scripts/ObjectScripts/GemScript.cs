using UnityEngine;
using UnityEngine.UI;
public class GemScript : MonoBehaviour {

    [SerializeField] Texture pinkGemTexture;
    [SerializeField] Texture blueGemTexture;
    [SerializeField] Texture yellowGemTexture;
    [SerializeField] Texture greenGemTexture;
    //pink=1,yellow=2,green=3,blue=4
    int gemColour = 0;
    private void Start() {
        GemLogic();
    }
    private void OnTriggerEnter(Collider other) {
        switch (gemColour) {
            case 1:
                GameObject.Find("GameManagerHelper").GetComponent<GameManagerScript>().pinkGemTaken = true;
                GameObject.Find("PinkGemImage").GetComponent<RawImage>().texture = pinkGemTexture;
                GameObject.Find("Canvas").GetComponent<GameUiTextScript>().StartCoroutine("ShowGems");
                Destroy(this.gameObject);
                break;
            case 2:
                GameObject.Find("GameManagerHelper").GetComponent<GameManagerScript>().yellowGemTaken = true;
                GameObject.Find("BlueGemImage").GetComponent<RawImage>().texture = blueGemTexture;
                Destroy(this.gameObject);
                break;
            case 3:
                GameObject.Find("GameManagerHelper").GetComponent<GameManagerScript>().greenGemTaken = true;
                GameObject.Find("YellowGemImage").GetComponent<RawImage>().texture = yellowGemTexture;
                Destroy(this.gameObject);
                break;
            case 4:
                GameObject.Find("GameManagerHelper").GetComponent<GameManagerScript>().blueGemTaken = true;
                GameObject.Find("GreenGemImage").GetComponent<RawImage>().texture = greenGemTexture;
                Destroy(this.gameObject);
                break;
        }
    }
    void GemLogic() {
        switch (this.gameObject.name) {
            case "PinkGem":
                gemColour = 1;
                break;
            case "YellowGem":
                gemColour = 2;
                break;
            case "GreenGem":
                gemColour = 3;
                break;
            case "GlueGem":
                gemColour = 4;
                break;
        }
    }









}
