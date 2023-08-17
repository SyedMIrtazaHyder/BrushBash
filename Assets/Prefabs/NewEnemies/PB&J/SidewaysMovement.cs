using UnityEngine;

public class SidewaysMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private ConstantForce forceComp;
    [SerializeField] int minSpeed, maxSpeed;
    private Animator _anim;
    private void Start()
    {
        forceComp = GetComponent<ConstantForce>();
        int randomDirection = Random.Range(-1, 2);
        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        forceComp.force = new Vector3(randomDirection * forceComp.force.x, forceComp.force.y, forceComp.force.z);
        _anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (forceComp == null || collision.collider.CompareTag("Brush"))
            return;
        _anim.SetTrigger("OnCollision");
        if (forceComp.force.x != 0)
            forceComp.force = new Vector3(-1 + forceComp.force.x, forceComp.force.y, forceComp.force.z);

        forceComp.force = new Vector3(-1 * forceComp.force.x, forceComp.force.y, forceComp.force.z);

    }
}