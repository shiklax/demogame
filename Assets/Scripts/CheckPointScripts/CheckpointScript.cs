using UnityEngine;

public class CheckpointScript : MonoBehaviour {
    Animation _animation;
    GameManagerScript _gm;
    [SerializeField] private bool isCheckpointTriggerd = false;
    [SerializeField] public Vector3 _checkpointVector3;
    private void Start() {
        _animation = GetComponent<Animation>();

        _gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManagerScript>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            if (!isCheckpointTriggerd) {
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                _gm.lastCheckPointPos = _checkpointVector3;
                isCheckpointTriggerd = true;
                _animation.Play();
            }
        }
    }
}
