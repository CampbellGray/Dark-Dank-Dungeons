using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI : MonoBehaviour
{
    [Header("Health")]
    public static float currentHealth = 4;
    public static float healthCap = 4;
    public float maxHealth = 4;
    public Image heartImg;
    public Image emptyHeartImg;

    [Header("Mana")]
    public float currentMana = 4;
    public float manaCap = 4;
    public float maxMana = 4;
    public Image manaImg;

    public GameObject score;
    private Score saveHighScore;

    private void Awake()
    {
        GameObject heartImgObject = GameObject.FindGameObjectWithTag("Health");
        if (heartImgObject != null)
        {
            heartImg = heartImgObject.GetComponent<Image>();
        }
        GameObject EmptyheartImgObject = GameObject.FindGameObjectWithTag("EmptyHealth");
        if (EmptyheartImgObject != null)
        {
            emptyHeartImg = EmptyheartImgObject.GetComponent<Image>();
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
        saveHighScore = score.GetComponent<Score>();
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

        if(currentHealth < 0)
        {
            currentHealth = 0;
        }
    }
    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        heartImg.fillAmount = currentHealth / maxHealth;
        emptyHeartImg.fillAmount = healthCap / maxHealth;
    }

    public void UpdateManaBar(float currentMana, float maxMana)
    {
        manaImg.fillAmount = currentMana / maxMana;
    }

    public void ApplyDamage()
    {
        currentHealth -= 1;
        if(currentHealth == 0)
        {
            saveHighScore.SaveScoreList();
            SceneManager.LoadScene("GameOver");
        }
    }
}
