using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{

    [SerializeField] private GameObject botonPausa;

    [SerializeField] private GameObject menuPausa;

    private bool juegoPausado = false;
    private Scene scene;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausa();
            }
        }
    }

    public void Pausa()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);

    }

    public void Reanudar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false); 
    }

    public void Cerrar()
    {
        Debug.Log("Cerrando Juego");
        Application.Quit();
    }

    public void ReiniciarNivel()
    {
        Debug.Log("Reiniciando Escena " + scene.name);
        SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
        // Application.Quit();
    }    

    public void Salir_Menu()
    {
        Debug.Log("Saliendo al menu");
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        // Application.Quit();
    }       
}
