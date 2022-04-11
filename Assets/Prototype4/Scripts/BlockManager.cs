using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : GameBehaviour<BlockManager>
{
    
    public Vector3 bounds;
    public float leftBound;
    public float rightBound;
    public float bottomBound;

    [Header("Grid")]
    public int gridWidth = 6;
    public int gridHeight = 8;
    public GameObject gridBack;
    public GameObject stageArea;
    public List<GridSpot> gridSpots;
    // Start is called before the first frame update
    void Start()
    {
        BuildBack();
    }

    void BuildBack()
    {
        for(int i = 0; i < gridHeight; i++)
        {
            for(int j = 0; j < gridWidth; j++)
            {
                GameObject go = Instantiate(gridBack, new Vector3(j, i, 1), transform.rotation);
                go.name = "(" + j + "," + i + ")";
                go.transform.SetParent(stageArea.transform);
                gridSpots.Add(new GridSpot(new Vector2(j, i), false, 0));
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class GridSpot
{
    public Vector2 coordinates;
    public bool occupied = false;
    public int number = 0;

    public GridSpot(Vector2 _coordinates, bool _occupied, int _number)
    {
        coordinates = _coordinates;
        occupied = _occupied;
        number = _number;
    }
}
