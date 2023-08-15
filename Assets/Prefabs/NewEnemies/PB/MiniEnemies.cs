using UnityEngine;

public class MiniEnemies : MonoBehaviour
{
    [SerializeField] private GameObject miniEnemy;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Brush"))
        {
            int enemyNo = Random.Range(1, 4);
            while (enemyNo != 0)
            {
                GameObject gb = Instantiate(miniEnemy, transform.position, transform.rotation);
                gb.transform.localScale = transform.localScale * 0.5f;
                enemyNo--;
            }
        }
    }
}
