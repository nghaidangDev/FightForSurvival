using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    public Health health;
    public Slider slider;

    private void Start()
    {
        slider.maxValue = health.currentHealth;
    }

    private void Update()
    {
        slider.value = health.currentHealth;
    }
}
