using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    public string gameScene;



    public void changeScene()
    {
        SceneManager.LoadScene(gameScene);
    }
}
