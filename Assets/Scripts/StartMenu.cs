using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public string gameSceneName = "SampleScene"; // Asegúrate de que el nombre coincida con tu escena de juego

    public void StartGame()
    {
        // Cargar la escena del juego
        SceneManager.LoadScene(gameSceneName);
    }
}
