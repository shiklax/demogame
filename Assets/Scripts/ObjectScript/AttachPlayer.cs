using UnityEngine;

public class AttachPlayer : MonoBehaviour {
    public GameObject Player;
    public bool isOnMovingPlatform = false;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == Player) {
            isOnMovingPlatform = true;
            Player.transform.parent = this.transform;
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject == Player) {
            isOnMovingPlatform = false;
            Player.transform.parent = null;
        }
    }
}
