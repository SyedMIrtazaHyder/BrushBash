using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Scripting.APIUpdating;

public class BrushControllerv2 : MonoBehaviour
{
    //This script is used with co-ordination with the Unity's new input system and character controller
    // Start is called before the first frame update
    private Player player;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private int killRequirement = 10;
    [SerializeField] private GameObject skidMark;
    [SerializeField] private float skidMarkX;
    [SerializeField] private float skidMarkY;
    [SerializeField] private float maxKillTime = 2f;
    [SerializeField] private GameObject VisualHelp;

    private Material skidMat;
    private float killtime;
    private Vector3 move;
    private int killed;

    //helper matrix
    Matrix4x4 matrixRot = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
    Matrix4x4 matrixMove = Matrix4x4.Rotate(Quaternion.Euler(0, -45, 0));

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
            playerVelocity.y = 0f;

        Vector2 movement = player.Move.Movement.ReadValue<Vector2>();
        move = new Vector3(movement.x, 0f, movement.y);
        //For top Down
        controller.Move(playerSpeed * Time.deltaTime * move);

        if (move != Vector3.zero)
        { 
            gameObject.transform.forward = move;
            if (VisualHelp != null)
                VisualHelp.SetActive(false);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        if (killtime > 0)
            placeSkid();
    }

    private void placeSkid()
    {
        killtime -= Time.deltaTime;
        GameObject skid = Instantiate(skidMark, new Vector3(transform.position.x, 0.01f, transform.position.z), Quaternion.Euler(-90f, transform.rotation.eulerAngles.y + 270, 0f));
        skid.transform.localScale = new Vector3(transform.localScale.x * skidMarkX, transform.localScale.y * skidMarkY, 1f);
        skid.GetComponent<Renderer>().material = skidMat;

    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object tagged as "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Vector3 pointOfContact = collision.GetContact(0).point;
            Vector3 pointOfContact = collision.gameObject.transform.position;
            pointOfContact.Set(pointOfContact.x, 0.05f, pointOfContact.z);
            /*GameObject skid = Instantiate(skidMark, pointOfContact, Quaternion.Euler(-90f, transform.rotation.eulerAngles.y + 270, 0f));
            skid.transform.localScale = new Vector3(transform.localScale.x * skidMarkX, transform.localScale.y * skidMarkY, 1f);
            skid.GetComponent<Renderer>().material = collision.gameObject.GetComponentInChildren<Renderer>().material;*/
            skidMat = collision.gameObject.GetComponentInChildren<Renderer>().material;
            killed++;
            killtime = maxKillTime;
        }

        if (killed == killRequirement)
        {
            Debug.Log("Going to Next Level");
            GetComponent<GameManager>().LevelComplete();
        }
    }
}