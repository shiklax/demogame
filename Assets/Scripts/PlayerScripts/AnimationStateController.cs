using UnityEngine;

public class AnimationStateController : MonoBehaviour {

    Animator _animator;
    CharacterController _characterController;
    Dash _dash;
    WallWalking _wallWalking;
    WallGrab _wallGrab;
    WallJump _wallJump;
    void Start() {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
        _dash = GetComponent<Dash>();
        _wallWalking = GetComponent<WallWalking>();
        _wallGrab = GetComponent<WallGrab>();
        _wallJump = GetComponent<WallJump>();
    }
    void Update() {
        print(_characterController.isGrounded);
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) && _characterController.isGrounded) {
            _animator.SetBool("isWalking", true);
            _animator.SetBool("isInAir", false);
            _animator.SetBool("isDashing", false);
            _animator.SetBool("isHanging", false);
            _animator.SetBool("isClimbingUp", false);
            _animator.SetBool("isClimbingDown", false);
            if (Input.GetKey(KeyCode.RightArrow)) {
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            if (Input.GetKey(KeyCode.LeftArrow)) {
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
        }
        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && _characterController.isGrounded) {
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isHanging", false);
            _animator.SetBool("isInAir", false);
            _animator.SetBool("isDashing", false);
            _animator.SetBool("isClimbingUp", false);
            _animator.SetBool("isClimbingDown", false);
        }
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow) && _characterController.isGrounded) {
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isInAir", false);
            _animator.SetBool("isDashing", false);
            _animator.SetBool("isClimbingUp", false);
            _animator.SetBool("isClimbingDown", false);
            _animator.SetBool("isHanging", false);
        }
        if (_dash.isCoroutineRunning == true && Input.GetKey(KeyCode.RightArrow)) {
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isDashing", true);
            _animator.SetBool("isInAir", false);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            if (_dash.isDashing == false) {
                _animator.SetBool("isWalking", false);
                _animator.SetBool("isDashing", false);
                _animator.SetBool("isInAir", true);
            }
        }
        if (_dash.isCoroutineRunning == true && Input.GetKey(KeyCode.LeftArrow)) {
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isDashing", true);
            _animator.SetBool("isInAir", false);
            transform.rotation = Quaternion.Euler(0, -90, 0);
            if (_dash.isDashing == false) {
                _animator.SetBool("isWalking", false);
                _animator.SetBool("isDashing", false);
                _animator.SetBool("isInAir", true);
            }
        }
        if (_dash.isCoroutineRunning == true && Input.GetKey(KeyCode.UpArrow)) {
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isDashing", true);
            _animator.SetBool("isInAir", false);
            if (_dash.isDashing == false) {
                _animator.SetBool("isWalking", false);
                _animator.SetBool("isDashing", false);
                _animator.SetBool("isInAir", true);
            }
        }
        if (_dash.isCoroutineRunning == false && !_characterController.isGrounded) {
            _animator.SetBool("isDashing", false);
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isDashing", false);
            _animator.SetBool("isInAir", true);
        }
        if (_wallWalking.enabled == true) {
            _animator.SetBool("isHanging", true);
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isDashing", false);
            _animator.SetBool("isInAir", false);
            if (_wallGrab.isRightWallGrabbed) {
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            if (_wallGrab.isLeftWallGrabbed) {
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            if (Input.GetKey(KeyCode.UpArrow))
                _animator.SetBool("isClimbingUp", true);
            if (!Input.GetKey(KeyCode.UpArrow))
                _animator.SetBool("isClimbingUp", false);
            if (Input.GetKey(KeyCode.DownArrow))
                _animator.SetBool("isClimbingDown", true);
            if (!Input.GetKey(KeyCode.DownArrow))
                _animator.SetBool("isClimbingDown", false);
        }
        if (!_wallWalking.enabled) {
            _animator.SetBool("isHanging", false);
        }
        if (_animator.GetBool("isInAir") == true) {
            _animator.SetBool("isClimbingUp", false);
            _animator.SetBool("isClimbingDown", false);
            _animator.SetBool("isWalking", false);
            if (Input.GetKey(KeyCode.RightArrow))
                transform.rotation = Quaternion.Euler(0, 90, 0);
            if (Input.GetKey(KeyCode.LeftArrow))
                transform.rotation = Quaternion.Euler(0, -90, 0);
        }

    }

}
