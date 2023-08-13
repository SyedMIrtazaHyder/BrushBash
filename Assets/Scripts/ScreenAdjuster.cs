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
        float planeHeightScale = (2.0f * Mathf.Tan(0.5f * Camera.main.fieldOfView * Mathf.Deg2Rad) * planeToCameraDistance) / 10.0f;
        float planeWidthScale = planeHeightScale * Camera.main.aspect;
        transform.localScale = new Vector3(planeWidthScale, 1f, planeHeightScale);
    }
}

    ////[SerializeField] RectTransform canvas; 
    //private float ratio = 450f;
    //private void Start()//Change to Start Later
    //{
    //    // Get screen dimensions
    //    Vector2 screenSize = new Vector2(Screen.width, Screen.height);

    //    // Adjust the dimensions of this GameObject based on screen size
    //    Debug.Log(screenSize.ToString());
    //    AdjustDimensions(screenSize);
    //}

    //private void AdjustDimensions(Vector2 screenSize)
    //{
    //    // Calculate new dimensions based on screen size
    //    Vector3 newScale = new Vector3(screenSize.x / ratio, 1f, screenSize.y / ratio);
    //    Debug.Log(screenSize.x.ToString() + ", " + screenSize.y.ToString());
    //    // Apply the new dimensions to the GameObject's Transform
    //    transform.localScale = newScale;
    //}