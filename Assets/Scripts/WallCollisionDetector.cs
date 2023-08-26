using System.Runtime.CompilerServices;
using UnityEngine;

public class WallCollisionDetector : MonoBehaviour
{
    [SerializeField] private GameObject splash;
    [SerializeField] private int maxhealth = 10;
    private int health;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private float mul;

    private void Start()
    {
        health = maxhealth;
        healthBar.setmaxhealth(maxhealth);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Vector3 collisionPoint = collision.GetContact(0).point;
            collisionPoint.z -= 0.2f;
            Vector3 originalSize =  splash.transform.localScale;
            GameObject gb = Instantiate(splash, collisionPoint, Quaternion.Euler(0, 180, 0));

           if (collision.gameObject.GetComponentsInChildren<MeshRenderer>().Length > 0)
                gb.GetComponent<MeshRenderer>().material = collision.gameObject.GetComponentInChildren<MeshRenderer>().material;
            else
                gb.GetComponent<MeshRenderer>().material = collision.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material;

            Debug.Log(gb.GetComponentInParent<Transform>().position.ToString());
            //Playing Sound Effect
            AudioManager.instance.Play("wallhit");
            //Decreasing Health of Wall
            health--;
            healthBar.sethealth(health);
            Destroy(collision.gameObject);
            if (health == 0)
                GetComponent<GameManager>().Restart();
        }
    }
}