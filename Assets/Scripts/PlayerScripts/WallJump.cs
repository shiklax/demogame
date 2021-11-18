using UnityEngine;

public class WallJump : MonoBehaviour {
    WallWalking _wallWalking;
    Movement _movement;
    CharacterController _controller;
    Gravity _gravity;
    WallGrab _wallGrab;
    Jump _jump;
    void Start() {
        _wallWalking = GetComponent<WallWalking>();
        _movement = GetComponent<Movement>();
        _controller = GetComponent<CharacterController>();
        _gravity = GetComponent<Gravity>();
        _wallGrab = GetComponent<WallGrab>();
        _jump = GetComponent<Jump>();
    }

    void Update() {
        if (_wallGrab.isLeftWallGrabbed && Input.GetButton("Jump") /*&& (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow))*/) {
            GetComponent<Dash>().isCoroutineRunning = false;
            _gravity.enabled = true;
            _movement.enabled = true;
            _movement._directionY = _jump._jumpSpeed;
            _wallGrab.isLeftWallGrabbed = false;
            this.enabled = false;
            _wallWalking.enabled = false;
        }
        if (_wallGrab.isRightWallGrabbed && Input.GetButton("Jump") /*&& (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.UpArrow))*/) {
            GetComponent<Dash>().isCoroutineRunning = false;
            _gravity.enabled = true;
            _movement.enabled = true;
            _movement._directionY = _jump._jumpSpeed;
            _wallGrab.isRightWallGrabbed = false;
            this.enabled = false;
            _wallWalking.enabled = false;
        }
    }
}
