using System.Collections;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private Animator m_Animator;
    private void Start()
    {
        m_Animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Brush") && gameObject.CompareTag("Enemy"))
        {
            m_Animator.SetTrigger("Death");
            Destroy(gameObject.GetComponent<ConstantForce>());//preventing Enemy to move anymore
            Destroy(gameObject.GetComponent<Collider>());
            Destroy(gameObject.GetComponent<Rigidbody>());
            StartCoroutine(WaitForAnimation());
        }
    }

    private IEnumerator WaitForAnimation()
    {
        AudioManager.instance.Play("jellycrush");

        yield return new WaitForSeconds(1.2f);//may work only for mobile games
        Debug.Log("Killing Enemy");
        Destroy(gameObject);
    }
}
