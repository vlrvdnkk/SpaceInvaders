using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MobSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> mobPrefabs; // Список префабов разных видов мобов
    [SerializeField] private int rows = 6; // Количество рядов мобов
    [SerializeField] private int columns = 11; // Количество мобов в ряду
    [SerializeField] private float stepDelay = 10.0f;
    [SerializeField] private float verticalStep = 1.0f;

    private List<GameObject> mobPool = new List<GameObject>();

    private void Start()
    {
        CreateMobPool();
        StartCoroutine(MoveMobsDown());
    }

    private void CreateMobPool()
    {
        int middleColumn = columns / 2; // Середина ряда

        for (int row = 0; row < rows; row++)
        {
            int randomMobIndex = Random.Range(0, mobPrefabs.Count);

            for (int col = 0; col < columns; col++)
            {
                int offset = col - middleColumn; // Расчет смещения от середины

                Vector3 spawnPosition = transform.position + Vector3.right * offset + Vector3.up * row * verticalStep;
                GameObject mob = Instantiate(mobPrefabs[randomMobIndex], spawnPosition, Quaternion.identity);
                mobPool.Add(mob);
            }
        }
    }

    private IEnumerator MoveMobsDown()
    {

        while (true) // Зацикливаем спуск мобов
        {
            for (int i = 0; i < mobPool.Count; i++)
            {
                mobPool[i].transform.position += Vector3.down * verticalStep;
            }

            yield return new WaitForSeconds(stepDelay); // Задержка перед следующим шагом
        }
    }
}