using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;


    private Rigidbody2D rb;
    private float verticalInput;

    AudioManagerScript audioManager;

    private AudioSource idleSource;


 private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Start()
    {
        Time.timeScale = 1f; 
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
    
        //start a looping idle sound one time
        idleSource = audioManager.PlaySFX(audioManager.PlayerIdle);
        idleSource.loop = true;
        //idleSource.Play();
    }


    
    public void OnMoveVertical(InputValue value)
    {
        verticalInput = value.Get<float>();
        //audioManager.PlaySFX(audioManager.PlayerIdle); // Play idle sound when moving   
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(0f, verticalInput * moveSpeed);

    }
}
