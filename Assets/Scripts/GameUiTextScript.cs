using System.Collections;
using TMPro;
using UnityEngine;

public class GameUiTextScript : MonoBehaviour {
    GameManagerScript _gameManagerScript;
    TextMeshProUGUI lifePointstxt;
    TextMeshProUGUI coinPointstxt;
    GameObject _LifeObjectHolder;
    public bool tabtoggle = false;
    void Start() {
        _gameManagerScript = GameObject.Find("GameManagerHelper").GetComponent<GameManagerScript>();
        _LifeObjectHolder = GameObject.Find("Canvas/UpUiWrapper");
        lifePointstxt = GameObject.Find("Canvas/UpUiWrapper/LifeCOUNT").GetComponent<TextMeshProUGUI>();
        coinPointstxt = GameObject.Find("Canvas/UpUiWrapper/CoinCOUNT").GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        lifePointstxt.text = _gameManagerScript.lifePoints.ToString();
        coinPointstxt.text = _gameManagerScript.coinPoints.ToString();
        TabToggle();
    }

    private void TabToggle() {
        if (Input.GetKeyDown(KeyCode.Tab) && !tabtoggle) {
            StartCoroutine("ShowHideLife");
        }
    }


    IEnumerator ShowHideLife() {
        tabtoggle = true;
        LeanTween.move(_LifeObjectHolder, new Vector3(_LifeObjectHolder.transform.position.x, _LifeObjectHolder.transform.position.y - 40, _LifeObjectHolder.transform.position.z), 1f).setEase(LeanTweenType.easeOutBounce);
        yield return new WaitForSeconds(2f);
        LeanTween.move(_LifeObjectHolder, new Vector3(_LifeObjectHolder.transform.position.x, _LifeObjectHolder.transform.position.y + 40, _LifeObjectHolder.transform.position.z), 1f).setEase(LeanTweenType.easeOutQuad);
        yield return new WaitForSeconds(0.8f);
        tabtoggle = false;
    }


}
