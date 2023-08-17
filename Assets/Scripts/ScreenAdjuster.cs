using UnityEngine;

public class ScreenAdjuster : MonoBehaviour
{
    private Vector2 screenResolution;
    // Start is called before the first frame update
    void Start()
    {
        screenResolution = new Vector2(Screen.width, Screen.height);
        MatchPlaneToScreenSize();
    }

    // Update for testing
    void Update()
    {
        if (screenResolution.x != Screen.width || screenResolution.y != Screen.height)
        {
            MatchPlaneToScreenSize();
            screenResolution.x = Screen.width;
            screenResolution.y = Screen.height;
        }
    }

    private void MatchPlaneToScreenSize()
    {
        float planeToCameraDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Debug.Log(Camera.main.fieldOfView.ToString());
        float planeHeightScale = (2.0f * Mathf.Tan(0.5f * Camera.main.fieldOfView * Mathf.Deg2Rad) * planeToCameraDistance) / 10.0f;
        float planeWidthScale = planeHeightScale * Camera.main.aspect;
        transform.localScale = new Vector3(planeWidthScale, 1f, planeHeightScale * 1.75f);
    }
}