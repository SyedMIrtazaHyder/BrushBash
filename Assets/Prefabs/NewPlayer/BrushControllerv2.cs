using UnityEngine;

public class BrushControllerv2 : MonoBehaviour
{
    //This script is used with co-ordination with the Unity's new input system and character controller
    // Start is called before the first frame update
    private Player player;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private int killRequirement = 10;
    private int killed;

    private void Awake()
    {
        player = new Player();
        controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        player.Enable();
    }

    private void OnDisable()
    {
        player.Disable();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = player.Move.Movement.ReadValue<Vector2>();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object tagged as "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the enemy GameObject
            Destroy(collision.gameObject);
            killed++;
        }

        if (killed == killRequirement)
        {
            Debug.Log("Going to Next Level");
            GetComponent<GameManager>().LoadNextLevel();
        }
    }
}
