using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int rows = 4;
    [SerializeField] private int columns = 4;
    [SerializeField] private float tileSize = 1;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid(); 
    }

    private void GenerateGrid()
    {
        GameObject referenceTile = (GameObject)Instantiate(Resources.Load("Tile"));

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                GameObject tile = (GameObject)Instantiate(referenceTile, transform);

                float posX = j * tileSize;
                float posY = i * -tileSize;

                tile.transform.position = new Vector2(posX,posY);
            }
        }

        Destroy(referenceTile);

        float gridWidth = columns * tileSize;
        float gridHeight = rows * tileSize;
        transform.position = new Vector2(-gridWidth / 2 + tileSize / 2, gridHeight / 2 - tileSize / 2);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
