using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuPause : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject menuPauseUI;
    public GameObject player;
    public string menuPrincipal = "MenuPrincipal";

    public GameObject pauseFirstButton;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
       if (Input.GetButtonDown("Pause"))
        {
            if (isPaused == true)
            {
                Reprendre();
            }
            else
            {
                SurPause();
            }
        }
    }

    public void Reprendre() //fonction pour le bouton "reprendre" aussi
    {
        menuPauseUI.SetActive(false);
        Time.timeScale = 1f; 
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked; 
        player.GetComponent<PlayerMovement>().enabled = true;
    }

    void SurPause()
    {
        menuPauseUI.SetActive(true);
        Time.timeScale = 0f; //met le jeu sur pause
        isPaused = true;
        EventSystem.current.SetSelectedGameObject(null);    //clear les selection
        EventSystem.current.SetSelectedGameObject(pauseFirstButton); //cree nouvelle selection (pour manette)
        Cursor.lockState = CursorLockMode.None; //fait reapparaitre le curseur
        player.GetComponent<PlayerMovement>().enabled = false; //fait qu'on ne peut pas "dash" durant le menu
    }

    public void LoadMenu()
    {
        //Debug.Log("loadingMenuPrincipal");
        SceneManager.LoadScene(menuPrincipal);
        Time.timeScale = 1f; 
    }

    public void Quitter()
    {
        //Debug.Log("Quitte le jeu");
        Application.Quit();
    }
}
