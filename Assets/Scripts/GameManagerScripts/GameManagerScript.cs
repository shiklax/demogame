using System.Collections;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {
    private static GameManagerScript instance;
    GameObject _player;
    GameManagerScript _gm;
    public Vector3 lastCheckPointPos;
    public int hitpoints = 2;

    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
        _gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManagerScript>();
    }


    private void Update() {
        HitpointsChecker();
        print(hitpoints);
    }
    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
        } else {
            Destroy(gameObject);
        }
    }
    public void RespawnPlayer() {
        _player.SetActive(false);
        StartCoroutine(RespawnPlayerCoroutine(2));
        hitpoints = 1;
    }

    public void HitpointsChecker() {
        if (hitpoints == 0) {
            RespawnPlayer();
            hitpoints = 2;
        }
    }



    IEnumerator RespawnPlayerCoroutine(float time) {
        yield return new WaitForSeconds(time);

        _player.transform.position = _gm.lastCheckPointPos;
        _player.SetActive(true);
    }
}
