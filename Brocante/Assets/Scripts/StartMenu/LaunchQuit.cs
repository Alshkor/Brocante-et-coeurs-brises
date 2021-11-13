using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchQuit : MonoBehaviour
{
    /*Simples fonctions pour permettre de quitter ou lancer le jeu*/
    public void QuitGame() {
        Debug.Log("On quitte le jeu");
        Application.Quit();
    }

    public void LaunchGame() {
        Debug.Log("On lance le jeu");
        SceneManager.LoadScene("FinalScene");
    }
}
