using UnityEngine;

public class PlayerCollisons : MonoBehaviour {
    GameObject _player;
    GameManagerScript _gm;
    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
        _gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManagerScript>();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            _gm.hitpoints--;
        }
    }
}
