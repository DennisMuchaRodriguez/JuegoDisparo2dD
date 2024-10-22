using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text scoreText;
    public Text bestScoreText; // Texto para mostrar el mejor puntaje en la pantalla
    public int score = 0;
    public float timer = 0f;

    private int bestScore = 0; // Variable para almacenar el mejor puntaje

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        LoadGame(); // Cargar los datos al inicio del juego
        UpdateScore();
        UpdateBestScoreText(); // Actualizar el texto del mejor puntaje
    }

    private void Update()
    {
        // Actualizar el temporizador
        timer += Time.deltaTime;
    }

    public void IncreaseScore()
    {
        score++;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    private void UpdateBestScoreText()
    {
        bestScoreText.text = "Best Score: " + bestScore; // Mostrar el mejor puntaje en la UI
    }

    public void GameOver()
    {
        // Verificar si el puntaje actual es el mejor
        if (score > bestScore)
        {
            bestScore = score;
            SaveGame(); // Guardar el nuevo mejor puntaje
        }

        PlayerPrefs.SetInt("FinalScore", score); // Guardar el puntaje final
        SceneManager.LoadScene("GameOver"); // Cargar la escena de Game Over
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();
        data.score = score;
        data.time = timer;
        data.bestScore = bestScore; 

        SaveSystem.SaveGame(data); 
    }

    public void LoadGame()
    {
        SaveData data = SaveSystem.LoadGame();

        if (data != null)
        {
            
            bestScore = data.bestScore;

            
            score = 0;

            UpdateScore();
        }
    }
}
