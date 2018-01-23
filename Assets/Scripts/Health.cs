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
        int rand = Random.Range(0, 100);
        if (rand < 5)
        {
            int rand2 = Random.Range(1, 5);
            TakeDamage(rand2);
        }

    }


    public void TakeDamage(int amount)
    {

        currentHealth -= amount;
        healthSlider.value = ((float)currentHealth);

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

    public void PlaySoundEffect(AudioSource audio)
    {
        audio.Play();
    }
}