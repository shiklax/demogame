using UnityEngine;

public class Jump : MonoBehaviour {
    Movement _movement;
    CharacterController _controller;
    Gravity _gravity;
    WallGrab _wallGrab;
    [SerializeField]
    public float _jumpSpeed = 3.15f;
    public bool _canDoubleJump = false;
    public float coyoteTime = 0.15f;
    void Start() {
        _movement = GetComponent<Movement>();
        _controller = GetComponent<CharacterController>();
        _gravity = GetComponent<Gravity>();
        _wallGrab = GetComponent<WallGrab>();
    }
    void Update() {
        IsOnGround();
        Jumping();
    }
    void OnDisable() {
        _canDoubleJump = true;
    }
    private void FixedUpdate() {
        InvokeRepeating("checkScript", 1.0f, 1.0f);
    }
    void Jumping() {
        if (coyoteTime > 0) {
            _canDoubleJump = true;
            GetComponent<Dash>().isCoroutineRunning = false;
            if (Input.GetButtonDown("Jump")) {
                _movement._directionY = _jumpSpeed;
            }
        } else {
            if (Input.GetButtonDown("Jump") && _canDoubleJump) {
                _movement._directionY = _jumpSpeed;
                _canDoubleJump = false;
            }
        }
    }
    //coyte time
    void IsOnGround() {
        if (_controller.isGrounded) {
            coyoteTime = 0.15f;
            _wallGrab.enabled = true;
            _movement._directionY = 0;
            _wallGrab.LastGrabbedObject = "RESET GROUND";
        } else {
            coyoteTime -= Time.deltaTime;
        }
    }
    void checkScript() {
        if (_gravity.enabled)
            this.enabled = true;
        else {
            this.enabled = false;
            _movement._directionY = 0;
        }
    }
}
