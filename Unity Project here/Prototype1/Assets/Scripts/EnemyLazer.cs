using UnityEngine;

public class EnemyLazer : MonoBehaviour
{
    public float speed = 5f;
    public float damage = 1f;
    public float lifetime = 5f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Shoots left
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Hit the player
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
            return;
        }

        // Hit walls
        if (other.gameObject.layer == LayerMask.NameToLayer("walls"))
        {
            Destroy(gameObject);
        }
    }
}
