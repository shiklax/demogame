using UnityEngine;

public class CoinScript : MonoBehaviour {

    private void Start() {
        transform.Rotate(0, Random.Range(-90, 90), 0, 0);
    }
    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Player")) {
            Destroy(this.gameObject);
        }
    }
}
