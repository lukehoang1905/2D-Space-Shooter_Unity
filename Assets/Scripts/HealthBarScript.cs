using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Slider slider;
    public static HealthBarScript HealthInstance;
    private int health, maxHealth;
    private void Awake()
    {
        HealthInstance = this;
    }
    void Start()
    {
        maxHealth = 5;
        slider.maxValue = maxHealth;
    }

    public void SetHealthMax(int hp)
    {
        maxHealth = hp;
        slider.maxValue = maxHealth;
    }
    public void UpdateHealth(int hp)
    {
        health += hp;
        slider.value = health;
    }
}
