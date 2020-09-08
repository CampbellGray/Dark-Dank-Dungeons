using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [Header("Health")]
    public float currentHealth = 4;
    public float healthCap = 4;
    public float maxHealth = 4;
    public Image heartImg;

    [Header("Health")]
    public float currentMana = 4;
    public float manaCap = 4;
    public float maxMana = 4;
    public Image manaImg;

    private UI ui;

    private void Awake()
    {
        ui = FindObjectOfType<UI>();
        GameObject heartImgObject = GameObject.FindGameObjectWithTag("Health");
        if (heartImgObject != null)
        {
            heartImg = heartImgObject.GetComponent<Image>();
        }
        GameObject manaImgObject = GameObject.FindGameObjectWithTag("Mana");
        if(manaImgObject != null)
        {
            manaImg = manaImgObject.GetComponent<Image>();
        }
    }
    void Start()
    {
        currentHealth = healthCap;
        currentMana = manaCap;
        ui.UpdateHealthBar(currentHealth, maxHealth);
    }
    private void Update()
    {
        if(currentHealth > healthCap)
        {
            currentHealth = healthCap;
        }
        UpdateHealthBar(currentHealth, maxHealth);
        if (currentMana > manaCap)
        {
            currentMana = manaCap;
        }
        UpdateManaBar(currentMana, maxMana);
    }
    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        heartImg.fillAmount = currentHealth / maxHealth;
    }

    public void UpdateManaBar(float currentMana, float maxMana)
    {
        manaImg.fillAmount = currentMana / maxMana;
    }
}
