using System.Collections;
using TMPro;
using UnityEngine;

public class GameUiTextScript : MonoBehaviour {
    GameManagerScript _gameManagerScript;
    TextMeshProUGUI lifePointstxt;
    TextMeshProUGUI coinPointstxt;
    GameObject _gemImageContainer;
    GameObject _LifeObjectHolder;
    public bool tabtoggle = false;

    void Start() {
        _gameManagerScript = GameObject.Find("GameManagerHelper").GetComponent<GameManagerScript>();
        _LifeObjectHolder = GameObject.Find("Canvas/UpUiWrapper");
        lifePointstxt = GameObject.Find("Canvas/UpUiWrapper/LifeCOUNT").GetComponent<TextMeshProUGUI>();
        coinPointstxt = GameObject.Find("Canvas/UpUiWrapper/CoinCOUNT").GetComponent<TextMeshProUGUI>();
        _gemImageContainer = GameObject.Find("Canvas/GemImageContainer");


    }

    private void Update() {
        lifePointstxt.text = _gameManagerScript.lifePoints.ToString();
        coinPointstxt.text = _gameManagerScript.coinPoints.ToString();
        TabToggle();
        if (Input.GetKeyDown(KeyCode.T)) {
        }
    }

    private void TabToggle() {
        if (Input.GetKeyDown(KeyCode.Tab) && !tabtoggle) {
            StartCoroutine("ShowHideLife");
        }
    }


    IEnumerator ShowHideLife() {
        tabtoggle = true;
        StartCoroutine("ShowGems");
        LeanTween.move(_LifeObjectHolder, new Vector3(_LifeObjectHolder.transform.position.x, _LifeObjectHolder.transform.position.y - 40, _LifeObjectHolder.transform.position.z), 1f).setEase(LeanTweenType.easeOutBounce);
        yield return new WaitForSeconds(2f);
        LeanTween.move(_LifeObjectHolder, new Vector3(_LifeObjectHolder.transform.position.x, _LifeObjectHolder.transform.position.y + 40, _LifeObjectHolder.transform.position.z), 1f).setEase(LeanTweenType.easeOutQuad);
        yield return new WaitForSeconds(0.8f);
        tabtoggle = false;
    }
    IEnumerator ShowGems() {
        tabtoggle = true;
        LeanTween.move(_gemImageContainer, new Vector3(_gemImageContainer.transform.position.x, _gemImageContainer.transform.position.y + 35, _gemImageContainer.transform.position.z), 0.5f).setEase(LeanTweenType.easeInQuad);
        yield return new WaitForSeconds(2f);
        LeanTween.move(_gemImageContainer, new Vector3(_gemImageContainer.transform.position.x, _gemImageContainer.transform.position.y - 35, _gemImageContainer.transform.position.z), 1f).setEase(LeanTweenType.easeOutQuad);
        yield return new WaitForSeconds(0.8f);
        tabtoggle = false;
    }



}
