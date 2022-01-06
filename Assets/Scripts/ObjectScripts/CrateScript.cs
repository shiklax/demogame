using UnityEngine;

public class CrateScript : MonoBehaviour {
    [SerializeField] GameObject destroyCrate;
    [SerializeField] float destroyDelay;

    GameObject _player;
    bool hitted = false;
    public void Start() {
        _player = GameObject.Find("Player");
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && _player.GetComponent<Dash>().isCoroutineRunning && !hitted) {
            hitted = true;
            this.transform.parent.GetComponent<BoxCollider>().enabled = false;
            GameObject destroyCrateObject = Instantiate(destroyCrate, this.gameObject.transform) as GameObject;
            this.transform.GetChild(0).gameObject.SetActive(false);
            destroyCrateObject.GetComponent<ExplodeScript>().Expolde();
            Destroy(this.gameObject, destroyDelay);
        }
    }

}
