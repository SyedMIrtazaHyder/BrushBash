using UnityEngine;

public class HandRotateAround : MonoBehaviour
{
    /* the object to orbit */
    public Transform target;

    /* speed of orbit (in degrees/second) */
    public float speed;

    [SerializeField] private GameObject SpawnerReady;

    private void Awake()
    {
        SpawnerReady.SetActive(false);
    }

    private void Update()
    {
        if (target != null)
        {
            transform.RotateAround(target.position, Vector3.forward, speed * Time.deltaTime);
        }
    }

    private void OnDisable()
    {
        SpawnerReady.SetActive(true);
    }
}
