using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    public Health health;
    public Slider sliderHealth;

    private void Start()
    {
        if (health == null)
        {
            Debug.Log("Health chua duoc gan");
        }

        sliderHealth.maxValue = health.startingHealth;
    }

    private void Update()
    {
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        sliderHealth.value = health.startingHealth;
    }
}
