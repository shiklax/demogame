using UnityEngine;
public class ExplodeScript : MonoBehaviour {
    public float minForce;
    public float maxForce;
    public float radius;
    public void Expolde() {
        foreach (Transform t in transform) {
            var rb = t.GetComponent<Rigidbody>();
            if (rb != null) {
                rb.AddExplosionForce(Random.Range(minForce, maxForce), transform.position, radius);
            }
        }
    }

}
