
using System.Collections;
using UnityEngine;

public class PaintModel : MonoBehaviour {
    GameObject _player;
    GameObject _model;
    GameManagerScript _gm;
    [SerializeField]
    // DURATION is also "Invincibility frames"
    float DURATION;
    [SerializeField]
    float FLASH_SPEED;
    [SerializeField]
    public bool flashingCoroutineRunning = false;

    Color32[] objColor = new Color32[9];

    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
        _model = GameObject.Find("Model");
        _gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManagerScript>();
        GetColors();
    }

    private void Update() {
        if (_gm._playerHited && !_gm._playerRespawn && !flashingCoroutineRunning) {
            flashingCoroutineRunning = true;
            StartFlash();
        }
    }

    public void StartFlash() => StartCoroutine(EFlash());
    private IEnumerator EFlash() {
        float startTime = Time.time;
        bool b = false;
        while (startTime + DURATION > Time.time) {
            b = !b;
            if (b) PaintRed();
            else PaintDefault();
            yield return new WaitForSeconds(FLASH_SPEED);
        }
        _gm._playerHited = false;
        flashingCoroutineRunning = false;
        PaintDefault();
    }


    void PaintRed() {
        for (int i = 0; i < _model.GetComponent<SkinnedMeshRenderer>().materials.Length; i++) {
            _model.GetComponent<SkinnedMeshRenderer>().materials[i].color = Color.red;
        }
    }
    public void PaintDefault() {

        for (int i = 0; i < _model.GetComponent<SkinnedMeshRenderer>().materials.Length; i++) {
            _model.GetComponent<SkinnedMeshRenderer>().materials[i].color = objColor[i];
        }
    }
    void GetColors() {
        for (int i = 0; i < _model.GetComponent<SkinnedMeshRenderer>().materials.Length; i++) {
            objColor[i] = _model.GetComponent<SkinnedMeshRenderer>().materials[i].color;
        }
    }
}
