using UnityEngine;

public class GameManagerScript : MonoBehaviour {
    private static GameManagerScript instance;
    GameObject _player;
    GameManagerScript _gm;
    public Vector3 lastCheckPointPos;

    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
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
    public void RespawnPlayer() {
        _player.transform.position = _gm.lastCheckPointPos;
    }
}
