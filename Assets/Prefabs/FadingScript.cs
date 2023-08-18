using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingScript : MonoBehaviour
{

    [SerializeField] private float fadeSpd, fadeAmt;
    private Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Color currentColor = mat.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b,
            Mathf.Lerp(currentColor.a, fadeAmt, fadeSpd * Time.deltaTime));
        mat.color = smoothColor;
        if (smoothColor.a < 0.05)
            Destroy(gameObject);
    }
}
