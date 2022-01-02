using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour {
    private static GameManagerScript instance;
    GameObject _player;
    GameObject _model;
    GameManagerScript _gm;
    public bool _playerHited;
    public bool _playerRespawn;
    public Vector3 lastCheckPointPos;
    public int hitpoints;
    public int lifePoints;

    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
        _model = GameObject.Find("Model");
        _gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManagerScript>();
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
        lifePoints--;
        _playerHited = false;
        _playerRespawn = true;
        _player.SetActive(false);
        StartCoroutine(RespawnPlayerCoroutine(2));
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



    IEnumerator RespawnPlayerCoroutine(float time) {
        yield return new WaitForSeconds(time);

        _player.transform.position = _gm.lastCheckPointPos;
        _player.SetActive(true);
        _playerRespawn = false;
    }
}
