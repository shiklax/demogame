using UnityEngine;

public class PlayerCollisonsWithEnemy : MonoBehaviour {
    GameObject _player;
    GameObject _model;
    GameManagerScript _gm;
    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
        _model = GameObject.Find("Model");
        _gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManagerScript>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && !_gm._playerHited) {
            _gm._playerHited = true;
            _gm.hitpoints--;
        }
    }
    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player") && !_gm._playerHited) {
            _gm._playerHited = true;
            _gm.hitpoints--;
        }
    }
}

