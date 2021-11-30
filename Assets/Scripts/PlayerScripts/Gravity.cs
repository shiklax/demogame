using UnityEngine;

public class Gravity : MonoBehaviour {
    Movement _movement;
    CharacterController _controller;
    [SerializeField]
    private float _gravityValue = 9.81f;
    void Start() {
        _gravityValue = 9.81f;
        _movement = GetComponent<Movement>();
        _controller = GetComponent<CharacterController>();
    }
    void Update() {
        Gravitation();
    }
    private void Gravitation() {
        _movement._directionY -= _gravityValue * Time.deltaTime;
    }
}
