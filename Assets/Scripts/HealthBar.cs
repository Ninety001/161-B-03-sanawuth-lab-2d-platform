using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Character target;   
    public Vector3 offset = new Vector3(0, 1.0f, 0); 

    void Start()
    {
        if (target == null)
            target = GetComponentInParent<Character>(); 
    }

    void Update()
    {
        if (target == null || slider == null) return;

        transform.position = target.transform.position + offset;

        slider.value = (float)target.Health / target.MaxHealth;
    }

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        if (slider != null)
            slider.value = currentValue / maxValue;
    }
}

