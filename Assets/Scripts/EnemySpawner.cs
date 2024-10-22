using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnTime = 2f;
    public float spawnRadius = 10f; // Radio alrededor del jugador para generar enemigos
    public float minDistanceFromPlayer = 5f; // Distancia m�nima permitida del jugador

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("SpawnEnemy", spawnTime, spawnTime);
    }

    void SpawnEnemy()
    {
        Vector2 spawnPosition;
        float distanceFromPlayer;

        // Continuar generando hasta que el punto est� a una distancia segura del jugador
        do
        {
            // Generar una posici�n aleatoria dentro de un radio alrededor del jugador
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            spawnPosition = (Vector2)player.position + randomDirection * spawnRadius;

            // Calcular la distancia del jugador
            distanceFromPlayer = Vector2.Distance(spawnPosition, player.position);

        } while (distanceFromPlayer < minDistanceFromPlayer); // Asegurar que no est� demasiado cerca

        // Generar enemigo en la posici�n seleccionada
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
