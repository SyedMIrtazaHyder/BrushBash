using UnityEngine;

public class WallCollisionDetector : MonoBehaviour
{
    [SerializeField] private GameObject splash;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Vector3 collisionPoint = collision.GetContact(0).point;
            collisionPoint.z -= 0.2f;
            Vector3 originalSize =  splash.transform.localScale;
            GameObject gb = Instantiate(splash, collisionPoint, Quaternion.Euler(0, 180, 0));
            gb.transform.localScale = new Vector3( originalSize.x * 3,
                                                   originalSize.y * 3,
                                                   1f);
            //Debug.Log(collision.gameObject.transform.localScale.ToString());
            Destroy(collision.gameObject);
        }
    }
}
