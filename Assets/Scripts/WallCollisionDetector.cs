using System.Runtime.CompilerServices;
using UnityEngine;

public class WallCollisionDetector : MonoBehaviour
{
    [SerializeField] private GameObject splash;
    [SerializeField] private int maxHits = 5;
    private int hitsTaken;

    private void Start()
    {
        hitsTaken = 0;
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

            gb.transform.localScale = new Vector3( originalSize.x * 3,
                                                   originalSize.y * 3,
                                                   1f);
            AudioManager.instance.Play("wallhit");
            //Debug.Log(collision.gameObject.transform.localScale.ToString());
            Destroy(collision.gameObject);

        }
    }
}
