using System.Collections;
using UnityEngine;
public class GameManagerScript : MonoBehaviour {
    private static GameManagerScript instance;
    GameObject _player;
    GameObject _model;
    GameManagerScript _gm;
    public bool _playerHited;
    public bool _playerRespawn;
    public Vector3 lastCheckPointPos;
    public int hitpoints;

    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
        _model = GameObject.Find("Model");
        _gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManagerScript>();
    }
    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
        } else {
            Destroy(gameObject);
        }
    }
    private void Update() {
        print(hitpoints);




        HitpointsChecker();
    }


    public void RespawnPlayer() {
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
    IEnumerator RespawnPlayerCoroutine(float time) {
        yield return new WaitForSeconds(time);

        _player.transform.position = _gm.lastCheckPointPos;
        _player.SetActive(true);
        _playerRespawn = false;
    }
}
