using UnityEngine;

public class Movement : MonoBehaviour {
    CharacterController _controller;
    Gravity _gravity;
    AttachPlayer _attachPlayer;

    [SerializeField]
    public float _moveSpeed = 10f;
    [SerializeField]
    private float _fallSpeed = 2.81f;
    public float _directionY;

    void Start() {
        _controller = GetComponent<CharacterController>();
        _gravity = GetComponent<Gravity>();
        _attachPlayer = GameObject.FindGameObjectWithTag("MovingPlatform").GetComponent<AttachPlayer>();
        _directionY = 0f;
        //Animation bug fix
        this.enabled = false;
        this.enabled = true;
        //Animation bug fix
    }
    void Update() {
        Movements();
        Physics.IgnoreLayerCollision(0, 7);
    }
    void Movements() {
        if (!_attachPlayer.isOnMovingPlatform) {
            if (_directionY < -_fallSpeed)
                _directionY = -_fallSpeed;
        }
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0f, 0f);
        direction.y = _directionY;
        Vector3 movement = direction * Time.deltaTime * _moveSpeed;
        _controller.Move(movement);
    }
}
