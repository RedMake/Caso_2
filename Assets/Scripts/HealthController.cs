using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    float maxHealth;

    [SerializeField]
    Slider slider;


    private float _currentHealth;

    private GameObject[] objectsToDestroy;


    private void Start()
    {
        objectsToDestroy = GameObject.FindGameObjectsWithTag("HealthBar");

        _currentHealth = maxHealth;

        slider.maxValue = maxHealth;
        slider.value = _currentHealth;
    }

    private float GetHealth(float value, bool percentage, float factor)
    {
        if (percentage)
        {
            return (maxHealth * Mathf.Abs(value) / 100.0F) * factor;
        }
        else
        {
            return Mathf.Abs(value) * factor;
        }
    }

    private void UpdateSlider()
    {
        _currentHealth = Mathf.Clamp(_currentHealth, 0.0F, maxHealth);
        if (slider != null)
        {
            slider.value = _currentHealth;
        }
        if (_currentHealth == 0.0F && gameObject != null)
        {
            Die();
        }
    }
    private void Die()
    {

        foreach (GameObject obj in objectsToDestroy)
        {
            if (obj != null)
            {
                Slider healthSlider = obj.GetComponentInChildren<Slider>();

                if (healthSlider != null && healthSlider.value <= 0.01f)
                {
                    Destroy(obj);
                }

            }
        }
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
        
    }
    public void DecreaseHealth(float value, bool percentage = false)
    {
        _currentHealth += GetHealth(value, percentage, -1);
        
        UpdateSlider();
    }

    public void IncreaseHealth(float value, bool percentage = false)
    {
        _currentHealth += GetHealth(value, percentage, 1);
        UpdateSlider();
    }
}
