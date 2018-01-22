using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public string EntityID = "";

    bool isDead;

    void Awake()
    {
        currentHealth = startingHealth;
        isDead = false;
    }


    void Update()
    {

        if (Random.Range(0, 100) < 5)
        {
            TakeDamage(Random.Range(1, 5));
        }

    }


    public void TakeDamage(int amount)
    {

        currentHealth -= amount;
        healthSlider.value = currentHealth;

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;
        if (EntityID.Equals("Player"))
        {
            //Lose game
            SceneManager.LoadSceneAsync("Menu");
        }
        else
        {
            //Win game
            SceneManager.LoadSceneAsync("Menu");
        }

      //  Destroy(gameObject);
    }
}