using TMPro;
using UnityEngine;

public class FadingScript : MonoBehaviour
{

    [SerializeField] private float fadeSpd, fadeAmt;
    [SerializeField] private bool isUI = false;
    private Material mat;
    private TMP_Text txt;

    // Start is called before the first frame update
    void Start()
    {
        if (isUI)
        {
            txt = GetComponent<TMP_Text>();
            txt.SetText("Level " + GetComponent<GameManager>().GetSceneNo());
        }

        else
            mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Color currentColor;
        if (isUI)
        {
            //txt.SetText("Level " + GetComponent<GameManager>().GetSceneNo());
            txt.CrossFadeAlpha(fadeAmt, fadeSpd, false);
        }

        else
        {
            currentColor = mat.color;

            Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b,
                Mathf.Lerp(currentColor.a, fadeAmt, fadeSpd * Time.deltaTime));
            mat.color = smoothColor;
            if (smoothColor.a < 0.05)
                Destroy(gameObject);
        }

    }

}
