using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    // heart variables

    public float health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // gets rid of the menu mouse
        Cursor.visible = false;
    }
    void Update()
    {
        // cant go over max health
        if (health > numOfHearts)
            health = numOfHearts;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)  // if health is more than 0 it uses a full heart sprite
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

            if (health <= 0)
            {
                SceneManager.LoadScene("Menu");
                Cursor.lockState = CursorLockMode.Confined; //turns cursor back on so you can use te menu
                Cursor.visible = true;
            }
        }
    }
}