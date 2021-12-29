using UnityEngine;

public class PlayerColisionDeadZone : MonoBehaviour {
    GameObject _player;
    GameObject _model;
    GameManagerScript _gm;
    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
        _model = GameObject.Find("Model");
        _gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManagerScript>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            _gm.RespawnPlayer();
        }
    }

}

