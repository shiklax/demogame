using UnityEngine;

public class WallWalking : MonoBehaviour {
    CharacterController _controller;
    WallGrab _wallGrab;
    WallJump _wallJump;
    Gravity _gravity;
    Jump _jump;
    Movement _movement;
    Dash _dash;
    [SerializeField]
    private float wallWalkingSpeed = 10f;
    [SerializeField]
    private float wallWalkingTime = 2f;
    void Start() {
        _wallGrab = GetComponent<WallGrab>();
        _controller = GetComponent<CharacterController>();
        _gravity = GetComponent<Gravity>();
        _jump = GetComponent<Jump>();
        _movement = GetComponent<Movement>();
        _dash = GetComponent<Dash>();
        this.enabled = false;
    }
    void Update() {
        if (wallWalkingTime > 0) {
            WallWakingScript();
            wallWalkingTime -= Time.deltaTime;
        } else {
            this.enabled = false;
            _wallGrab.enabled = false;
            _wallGrab.isRightWallGrabbed = false;
            _wallGrab.isLeftWallGrabbed = false;
            _gravity.enabled = true;
            _movement.enabled = true;
        }
    }
    private void OnEnable() {
        _wallJump = GetComponent<WallJump>();
        _wallJump.enabled = true;
    }
    private void OnDisable() {
        wallWalkingTime = 2f;
        _wallJump.enabled = false;
        _dash.enabled = true;

    }
    void WallWakingScript() {
        Vector3 rayDirection = new Vector3(0.8f, 0, 0);
        RaycastHit raycastHit;
        Ray rayUpRight = new Ray(new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), rayDirection);
        Ray rayDownRight = new Ray(new Vector3(transform.position.x, transform.position.y, transform.position.z), rayDirection);
        Ray rayUpLeft = new Ray(new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), -rayDirection);
        Ray rayDownLeft = new Ray(new Vector3(transform.position.x, transform.position.y, transform.position.z), -rayDirection);
        //up right
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), rayDirection, Color.cyan);
        //down right
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, transform.position.z), rayDirection, Color.green);
        //up left
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), -rayDirection, Color.black);
        //down left
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, transform.position.z), -rayDirection, Color.yellow);
        if ((Physics.Raycast(rayUpLeft, out raycastHit, rayDirection.x)) || (Physics.Raycast(rayDownLeft, out raycastHit, rayDirection.x))) {
            if (Physics.Raycast(rayUpLeft, out raycastHit, rayDirection.x) && (Physics.Raycast(rayDownLeft, out raycastHit, rayDirection.x))) {
                movementControls();
            } else if (!(Physics.Raycast(rayUpLeft, out raycastHit, rayDirection.x))) {
                wallWalkingControlsDown();
            } else {
                wallWalkingControlsUp();
            }
        }
        if ((Physics.Raycast(rayUpRight, out raycastHit, rayDirection.x)) || (Physics.Raycast(rayDownRight, out raycastHit, rayDirection.x))) {
            if (Physics.Raycast(rayUpRight, out raycastHit, rayDirection.x) && (Physics.Raycast(rayDownRight, out raycastHit, rayDirection.x))) {
                movementControls();
            } else if (!(Physics.Raycast(rayUpRight, out raycastHit, rayDirection.x))) {
                wallWalkingControlsDown();
            } else {
                wallWalkingControlsUp();
            }
        }

    }
    void wallWalkingControlsUp() {
        Vector3 directionup = new Vector3(0f, 1, 0f);
        if (Input.GetKey(KeyCode.UpArrow)) {
            _controller.Move(directionup * Time.deltaTime * wallWalkingSpeed);
        }
    }
    void wallWalkingControlsDown() {
        Vector3 directiondown = new Vector3(0f, -1, 0f);
        if (Input.GetKey(KeyCode.DownArrow)) {
            _controller.Move(directiondown * Time.deltaTime * wallWalkingSpeed);
        }
    }
    void movementControls() {

        wallWalkingControlsUp();
        wallWalkingControlsDown();
    }
}
