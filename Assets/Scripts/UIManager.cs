using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //to allow changes to the UI
using TMPro; // Add this line to include Text Mesh Pro


public class UIManager : MonoBehaviour
{
    private HealthManager healthManager;
    public Slider healthBar;
    // public Text HPText;
    public TextMeshProUGUI HPText; // Change this to TextMeshProUGUI

    // Start is called before the first frame update
    void Start()
    {
        healthManager = FindFirstObjectByType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = healthManager.maxHealth;
        healthBar.value = healthManager.currentHealth;
        HPText.text = "HP: " + healthManager.currentHealth + "/" + healthManager.maxHealth;
    }
}
