using UnityEngine;

public class LootEntity : MonoBehaviour
{
    public float speed = 2f;
    public float height = 0.5f;
    public GameObject dropPrefab; // The item to "drop"
    private Vector3 startPos;

    void Start() => startPos = transform.position;

    void Update()
    {
        // Smoothly oscillate the Y position
        float newY = startPos.y + Mathf.Sin(Time.time * speed) * height;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Detect hit (e.g., by checking if hit by a "Player" or "Projectile")
        if (collision.gameObject.CompareTag("Projectile"))
        {
            DropItem();
        }
    }

    void DropItem()
    {
        if (dropPrefab != null)
        {
            // Spawn the item at the sprite's current position
            Instantiate(dropPrefab, transform.position, Quaternion.identity);
        }
    }
}
