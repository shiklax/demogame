using System.Collections;
using UnityEngine;


public class Dash : MonoBehaviour {

    Gravity _gravity;
    Movement _movement;
    CharacterController _characterController;
    [SerializeField]
    private float dashSpeed;
    [SerializeField]
    private float dashTime;
    public bool isCoroutineRunning = false;
    public bool isDashing = false;
    void Start() {
        _gravity = GetComponent<Gravity>();
        _movement = GetComponent<Movement>();
        _characterController = GetComponent<CharacterController>();
        dashTime = 0.4f;
        dashSpeed = 150f;
    }
    void Update() {
        DashingHandler();
    }
    void DashingHandler() {
        //dash right
        if (Input.GetKeyDown(KeyCode.C) && Input.GetKey(KeyCode.RightArrow) && !isCoroutineRunning && !_characterController.isGrounded) {
            isCoroutineRunning = true;
            StartCoroutine(Dashing(new Vector3(0.1f, 0, 0), dashTime, dashSpeed));
        }
        //dash right
        if (Input.GetKeyDown(KeyCode.C) && Input.GetKey(KeyCode.LeftArrow) && !isCoroutineRunning && !_characterController.isGrounded) {
            isCoroutineRunning = true;
            StartCoroutine(Dashing(new Vector3(-0.1f, 0, 0), dashTime, dashSpeed));
        }
        //dash up
        if (Input.GetKeyDown(KeyCode.C) && Input.GetKey(KeyCode.UpArrow) && !isCoroutineRunning && !_characterController.isGrounded) {
            isCoroutineRunning = true;
            StartCoroutine(Dashing(new Vector3(0, 0.1f, 0), dashTime, dashSpeed));
        }
    }
    IEnumerator Dashing(Vector3 destination, float dashTime, float dashSpeed) {
        while (dashTime > 0) {
            isDashing = true;
            _gravity.enabled = false;
            _movement.enabled = false;
            _characterController.Move(new Vector3(destination.x * dashSpeed * Time.deltaTime, destination.y * dashSpeed * Time.deltaTime, destination.z * dashSpeed * Time.deltaTime));
            yield return new WaitForFixedUpdate();
            dashTime -= Time.deltaTime;
            if ((_characterController.collisionFlags & CollisionFlags.CollidedSides) != 0)
                break;
            if ((_characterController.collisionFlags & CollisionFlags.Above) != 0)
                break;
        }
        isDashing = false;
        _gravity.enabled = true;
        _movement.enabled = true;
    }

}
