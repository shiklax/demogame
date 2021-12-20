using UnityEngine;

public class FireballCollisons : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Enemy")
            Destroy(this.gameObject);
    }
}
