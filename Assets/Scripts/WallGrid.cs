using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGrid : MonoBehaviour
{
     [SerializeField] private int rows = 10;
    [SerializeField] private int columns = 10;
    [SerializeField] private float tileSize = 1;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid(); 
    }

    private void GenerateGrid()
    {
        GameObject referenceTile = (GameObject)Instantiate(Resources.Load("Wall"));

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (i > 0 && i < 9)
                {
                    if (j == 0 || j == 9)
                    {
                        GameObject tile = (GameObject)Instantiate(referenceTile, transform);

                        float posX = j * tileSize;
                        float posY = i * -tileSize;

                        tile.transform.position = new Vector2(posX,posY); 
                    }
                }
                else 
                {
                    GameObject tile = (GameObject)Instantiate(referenceTile, transform);

                    float posX = j * tileSize;
                    float posY = i * -tileSize;

                    tile.transform.position = new Vector2(posX,posY);
                }

                
            }
        }

        Destroy(referenceTile);

        float gridWidth = columns * tileSize;
        float gridHeight = rows * tileSize;
        transform.position = new Vector2(-gridWidth / 2 + tileSize / 2, gridHeight / 2 - tileSize / 2);
        
    }
}
