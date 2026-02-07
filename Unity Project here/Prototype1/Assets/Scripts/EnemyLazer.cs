using UnityEngine;

public class EnemyLazer : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 1;
    public float lifetime = 5f;

    //AudioManagerScript audioManager;

    void Start()
    {
        Destroy(gameObject, lifetime);
        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
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


        // Hit player bullets
        if (other.CompareTag("PlayerMagic"))
        {
            ScoreManager.Instance.ShotEnemyProjectile();
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
