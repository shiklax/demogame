using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour {
    GameObject _player;
    GameObject _canvas;
    GameManagerScript _gm;
    public bool _playerHited;
    public bool _playerRespawn;

    public bool pinkGemTaken = false;
    public bool yellowGemTaken = false;
    public bool greenGemTaken = false;
    public bool blueGemTaken = false;


    public Vector3 lastCheckPointPos;
    public int hitpoints;
    public int lifePoints;
    public int coinPoints;

    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
        _gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManagerScript>();
        _canvas = GameObject.Find("Canvas");
        //fixing weird graphic bug
        StartCoroutine("HidePlayer");
    }
    private void Awake() {
        /*
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
        } else {
            Destroy(gameObject);
        }
        */
    }
    private void Update() {
        HitpointsChecker();
        if (lifePoints == 0) {
            ReloadScene();
        }
    }


    public void RespawnPlayer() {
        _player.GetComponent<Dash>().isDashing = false;
        if (!_canvas.GetComponent<GameUiTextScript>().tabtoggle)
            _canvas.GetComponent<GameUiTextScript>().StartCoroutine("ShowHideLife");
        lifePoints--;
        _playerHited = false;
        _playerRespawn = true;
        _player.SetActive(false);
        StartCoroutine(RespawnPlayerCoroutine(2));
        _player.GetComponent<Movement>().enabled = true;
        _player.GetComponent<Gravity>().enabled = true;
        hitpoints = 2;
    }
    public void HitpointsChecker() {
        if (hitpoints == 0) {
            RespawnPlayer();
        }
    }

    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        lifePoints = 2;
    }


    IEnumerator HidePlayer() {
        _player.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().enabled = false;
        _player.GetComponent<Movement>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        _player.GetComponent<Movement>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        _player.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().enabled = true;
    }



    IEnumerator RespawnPlayerCoroutine(float time) {
        yield return new WaitForSeconds(time);

        _player.transform.position = _gm.lastCheckPointPos;
        _player.SetActive(true);
        _playerRespawn = false;

    }


}
