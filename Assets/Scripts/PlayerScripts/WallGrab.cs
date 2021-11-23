using UnityEngine;

public class WallGrab : MonoBehaviour {
    Movement _movement;
    CharacterController _characterController;
    Gravity _gravity;
    Jump _jump;
    WallWalking _wallWalking;
    Dash _dash;
    public bool isLeftWallGrabbed;
    public bool isRightWallGrabbed;
    public string LastGrabbedObject;
    private float LeftArrowTapTime;
    private float RightArrowTapTime;
    private const float DOUBLE_TAP_TIME = .2f;

    void Start() {
        _movement = GetComponent<Movement>();
        _characterController = GetComponent<CharacterController>();
        _gravity = GetComponent<Gravity>();
        _jump = GetComponent<Jump>();
        _wallWalking = GetComponent<WallWalking>();
        _dash = GetComponent<Dash>();

    }

    void Update() {
        WallGrabing();
    }
    void WallGrabing() {
        Vector3 rayOrigin = transform.position + new Vector3(0, 1, 0);
        Vector3 rayDirection = new Vector3(0.8f, 0, 0);
        Debug.DrawRay(rayOrigin, rayDirection, Color.red);
        Debug.DrawRay(rayOrigin, -rayDirection, Color.red);

        Ray rayRight = new Ray(rayOrigin, rayDirection);
        Ray rayLeft = new Ray(rayOrigin, -rayDirection);
        if (Physics.Raycast(rayRight, out RaycastHit raycastHit, rayDirection.x)) {

            if (Input.GetKey(KeyCode.RightArrow)) {
                LastGrabbedObject = raycastHit.transform.name;
                isRightWallGrabbed = true;
                _gravity.enabled = false;
                _movement.enabled = false;
                _wallWalking.enabled = true;
                _dash.enabled = false;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                float TimeSinceLastTapLeft = Time.time - LeftArrowTapTime;
                LeftArrowTapTime = Time.time;
                if (TimeSinceLastTapLeft <= DOUBLE_TAP_TIME) {
                    isRightWallGrabbed = false;
                    _gravity.enabled = true;
                    _movement.enabled = true;
                    _wallWalking.enabled = true;
                    _dash.enabled = true;
                }
            }
        }
        if (Physics.Raycast(rayLeft, out raycastHit, rayDirection.x)) {
            if (Input.GetKey(KeyCode.LeftArrow)) {
                LastGrabbedObject = raycastHit.transform.name;
                isLeftWallGrabbed = true;
                _gravity.enabled = false;
                _movement.enabled = false;
                _wallWalking.enabled = true;
                _dash.enabled = false;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                float TimeSinceLastTapRight = Time.time - RightArrowTapTime;
                RightArrowTapTime = Time.time;
                if (TimeSinceLastTapRight <= DOUBLE_TAP_TIME) {
                    isRightWallGrabbed = false;
                    _gravity.enabled = true;
                    _movement.enabled = true;
                    _wallWalking.enabled = true;
                    _dash.enabled = true;
                }
            }
        }
    }
}
