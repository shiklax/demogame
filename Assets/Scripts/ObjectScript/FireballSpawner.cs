using UnityEngine;

public class FireballSpawner : MonoBehaviour {
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed;
    Animation _animation;


    private void Start() {
        _animation = GetComponent<Animation>();
    }
    void SpawnFireball() {
        GameObject fireball = Instantiate(projectile, transform) as GameObject;
        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        rb.velocity = transform.up * projectileSpeed;
    }
}
