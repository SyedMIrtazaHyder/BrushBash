using UnityEngine;

public class ScreenAdjuster : MonoBehaviour
{ 
    //[SerializeField] 
    private float ratio = 450f;
    private void Start()//Change to Start Later
    {
        // Get screen dimensions
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);

        // Adjust the dimensions of this GameObject based on screen size
        AdjustDimensions(screenSize);
    }

    private void AdjustDimensions(Vector2 screenSize)
    {
        // Calculate new dimensions based on screen size
        Vector3 newScale = new Vector3(screenSize.x/ratio, 1f, screenSize.y / ratio);
        Debug.Log(screenSize.x.ToString() + ", " + screenSize.y.ToString());
        // Apply the new dimensions to the GameObject's Transform
        transform.localScale = newScale;
    }
}
