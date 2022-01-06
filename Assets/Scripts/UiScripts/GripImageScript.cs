using UnityEngine;
using UnityEngine.UI;

public class GripImageScript : MonoBehaviour {
    GameObject _gameManagerHelper;
    GameObject _gripImage;
    GameObject _player;



    void Start() {
        _gameManagerHelper = GameObject.Find("GameManagerHelper");
        _gripImage = GameObject.Find("GripImage");
        _player = GameObject.Find("Player");
        _gripImage.GetComponent<Image>().enabled = false;


    }
    void Update() {
        GripImageColour();
        GripUiHandler();
    }

    void GripUiHandler() {
        if (_player.GetComponent<WallWalking>().enabled) {
            if (_player.GetComponent<WallGrab>().isLeftWallGrabbed) {
                _gripImage.GetComponent<Image>().fillOrigin = 1;
                _gripImage.GetComponent<Image>().enabled = true;
                _gripImage.GetComponent<Image>().fillAmount -= 0.5f * Time.deltaTime;
            } else if (_player.GetComponent<WallGrab>().isRightWallGrabbed) {
                _gripImage.GetComponent<Image>().fillOrigin = 0;
                _gripImage.GetComponent<Image>().enabled = true;
                _gripImage.GetComponent<Image>().fillAmount -= 0.5f * Time.deltaTime;

            }
        } else {
            _gripImage.GetComponent<Image>().enabled = false;
            _gripImage.GetComponent<Image>().fillAmount = 1f;
        }
    }

    void GripImageColour() {
        if (_gripImage.GetComponent<Image>().fillAmount >= 0.7f) {
            _gripImage.GetComponent<Image>().color = Color.green;
        } else if (_gripImage.GetComponent<Image>().fillAmount >= 0.4f)
            _gripImage.GetComponent<Image>().color = Color.yellow;
        else
            _gripImage.GetComponent<Image>().color = Color.red;

    }

}
