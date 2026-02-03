using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private float verticalInput;

    void Start()
    {
        Time.timeScale = 1f; 
    }


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    public void OnMoveVertical(InputValue value)
    {
        verticalInput = value.Get<float>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(0f, verticalInput * moveSpeed);
    }
}
