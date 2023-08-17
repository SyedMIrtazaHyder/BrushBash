using UnityEngine;

public class BouncinessScript : MonoBehaviour
{
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
       if (collision.collider.CompareTag("Floor"))
        {
            _animator.SetTrigger("OnTerrainCollision");
        }
    }

}
