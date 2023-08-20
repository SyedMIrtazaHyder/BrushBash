using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image Fill;

    public void setmaxhealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
       Fill.color =  gradient.Evaluate(1f);
    }
    public void sethealth(int health)
    {
        slider.value = health;
        Fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
