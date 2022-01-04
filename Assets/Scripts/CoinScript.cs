using UnityEngine;

public class CoinScript : MonoBehaviour {


    GameObject GameManager;



    private void Start() {
        transform.Rotate(0, Random.Range(-90, 90), 0, 0);
    }
    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Player")) {
            GameObject.Find("GameManagerHelper").GetComponent<GameManagerScript>().coinPoints++;
            Destroy(this.gameObject);
        }
    }
}
