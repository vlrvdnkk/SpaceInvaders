using UnityEngine;
using System.Collections.Generic;

public class MobSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> mobPrefabs;
    [SerializeField] private GameController gameController;
    [SerializeField] private int rows = 6;
    [SerializeField] private int columns = 11;
    [SerializeField] private float stepDelay = 10.0f;
    [SerializeField] private float verticalStep = 1.0f;

    private List<List<GameObject>> mobRows = new List<List<GameObject>>();
    private int counter = 4;
    private float timer;

    private void Start()
    {
        CreateMobPool();
        timer = stepDelay;
    }

    private void Update()
    {
        Debug.Log(counter);
        timer -= Time.deltaTime;

        if (timer <= 0 && counter >= 0)
        {
            MoveMobsDown();
            timer = stepDelay;
        }

        for (int row = mobRows.Count - 1; row >= 0; row--)
        {
            bool rowDestroyed = true;

            for (int col = 0; col < mobRows[row].Count; col++)
            {
                if (mobRows[row][col] != null)
                {
                    rowDestroyed = false;
                    break;
                }
            }

            if (rowDestroyed)
            {
                mobRows.RemoveAt(row);
                if (mobRows.Count == 0)
                {
                    gameController.GameWin();
                }
                else
                    counter++;

                if (counter <= 0)
                {
                    gameController.GameOver();
                }
            }
        }
    }

    private void CreateMobPool()
    {
        int middleColumn = columns / 2;

        for (int row = 0; row < rows; row++)
        {
            int randomMobIndex = Random.Range(0, mobPrefabs.Count);
            List<GameObject> rowList = new List<GameObject>();

            for (int col = 0; col < columns; col++)
            {
                int offset = col - middleColumn;

                Vector3 spawnPosition = transform.position + Vector3.right * offset + Vector3.up * row * verticalStep;
                GameObject mob = Instantiate(mobPrefabs[randomMobIndex], spawnPosition, Quaternion.identity);
                rowList.Add(mob);
            }

            mobRows.Add(rowList);
        }
    }

    private void MoveMobsDown()
    {
        for (int row = mobRows.Count - 1; row >= 0; row--)
        {
            for (int col = 0; col < mobRows[row].Count; col++)
            {
                if (mobRows[row][col] != null)
                {
                    mobRows[row][col].transform.position += Vector3.down * verticalStep;
                }
            }
        }
        counter--;
    }
}