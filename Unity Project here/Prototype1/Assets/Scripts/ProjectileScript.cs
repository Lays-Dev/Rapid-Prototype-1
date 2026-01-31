using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    private Transform Enemy;
    private float moveSpeed;

    private float distance = 0.1f;

    private void Update()
    {
        Vector3 moveDirNormalized = (Enemy.position - transform.position).normalized;
        transform.position += moveDirNormalized * moveSpeed * Time.deltaTime;

        if(Vector3.Distance(transform.position, Enemy.position) < distance)
        {
            Destroy(gameObject);
        }
    }

    public void InitializeProjectile(Transform Enemy, float moveSpeed)
    {
        this.Enemy = Enemy;
        this.moveSpeed = moveSpeed;
    }
}
