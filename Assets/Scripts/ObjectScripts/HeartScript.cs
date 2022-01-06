using UnityEngine;

public class HeartScript : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        GameObject.Find("GameManagerHelper").GetComponent<GameManagerScript>().lifePoints++;
        Destroy(this.gameObject);
    }
}
