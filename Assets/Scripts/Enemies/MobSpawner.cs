using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MobSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> mobPrefabs; // ������ �������� ������ ����� �����
    [SerializeField] private int rows = 6; // ���������� ����� �����
    [SerializeField] private int columns = 11; // ���������� ����� � ����
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
        int middleColumn = columns / 2; // �������� ����

        for (int row = 0; row < rows; row++)
        {
            int randomMobIndex = Random.Range(0, mobPrefabs.Count);

            for (int col = 0; col < columns; col++)
            {
                int offset = col - middleColumn; // ������ �������� �� ��������

                Vector3 spawnPosition = transform.position + Vector3.right * offset + Vector3.up * row * verticalStep;
                GameObject mob = Instantiate(mobPrefabs[randomMobIndex], spawnPosition, Quaternion.identity);
                mobPool.Add(mob);
            }
        }
    }

    private IEnumerator MoveMobsDown()
    {

        while (true) // ����������� ����� �����
        {
            for (int i = 0; i < mobPool.Count; i++)
            {
                mobPool[i].transform.position += Vector3.down * verticalStep;
            }

            yield return new WaitForSeconds(stepDelay); // �������� ����� ��������� �����
        }
    }
}