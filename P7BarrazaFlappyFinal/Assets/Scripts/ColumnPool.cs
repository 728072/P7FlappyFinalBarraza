using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{

    public int ColumnPoolSize = 5;
    public GameObject ColumnPrefab;
    public float SpawnRate = 4f;
    public float ColumnMin = -2f;
    public float ColumnMax = 2f;

    private GameObject[] Columns;
    private Vector2 ObjectPoolPosition = new Vector2(-15f, -25f);
    private float LastSpawned;
    private float SpawnXPositon = 10f;
    private int currentColumn = 0;

    // Start is called before the first frame update
    void Start()
    {
        Columns = new GameObject[ColumnPoolSize];
        for (int i = 0; i < ColumnPoolSize; i++)
        {
            Columns[i] = (GameObject)Instantiate(ColumnPrefab, ObjectPoolPosition, Quaternion.identity);
        }
    }
    void Update()
    {
        LastSpawned += Time.deltaTime;

        if (GameController.instance.gameOver == false && LastSpawned >= SpawnRate)
        {
            {
                LastSpawned = 0;
                float SpawnYPosition = Random.Range(ColumnMin, ColumnMax);

                Columns[currentColumn].transform.position = new Vector2(SpawnXPositon, SpawnYPosition);
                currentColumn++;

                if (currentColumn >= ColumnPoolSize)
                {
                    currentColumn = 0;
                }
            }
        }
    }
}