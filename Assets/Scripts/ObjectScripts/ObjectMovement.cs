using UnityEngine;

public class ObjectMovement : MonoBehaviour {
    [SerializeField] private Vector3 _targetA, _targetB;
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private bool _movementEnabled;
    [SerializeField] private Vector3 _rotation;
    private bool _switching = false;
    private void FixedUpdate() {
        transform.Rotate(_rotation * Time.deltaTime);


        if (_movementEnabled) {

            if (!_switching) {
                transform.position = Vector3.MoveTowards(transform.position, _targetB, _speed * Time.fixedDeltaTime);
            } else if (_switching) {
                transform.position = Vector3.MoveTowards(transform.position, _targetA, _speed * Time.fixedDeltaTime);
            }
            if (transform.position == _targetB) {
                _switching = true;
            }
            if (transform.position == _targetA) {
                _switching = false;
            }
        }
    }
}
