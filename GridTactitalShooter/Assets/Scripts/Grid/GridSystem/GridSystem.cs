using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    private int width;
    private int height;
    private float cellSize;
    [SerializeField] private GridObject[,] gridObjectArray;
    public GridSystem(int width,int height,float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridObjectArray = new GridObject[width,height];

        for(int x=0;x<width;x++)
        {
            for(int z=0;z<height;z++)
            {
                GridPosition gridPosition = new GridPosition(x,z);

                gridObjectArray[x, z] = new GridObject(this, gridPosition);

                Debug.DrawLine(GetWorldPosition(gridPosition), GetWorldPosition(gridPosition) + Vector3.right * 0.5f,Color.green,9999f);
            }
        }
    }

    public Vector3 GetWorldPosition(GridPosition gridPosition)
    {
        return new Vector3(gridPosition.x, 0.0f, gridPosition.z) * cellSize;
    }

    public GridPosition GetGridPosition(Vector3 worldPositon)
    {
        return new GridPosition(Mathf.RoundToInt(worldPositon.x / cellSize),Mathf.RoundToInt(worldPositon.z / cellSize));
    }


    public int GetWidth()
    {
        return width;
    }

    public int GetHeight()
    {
        return height;
    }


    public GridObject GetGridObject(GridPosition gridPosition)
    {
        return gridObjectArray[gridPosition.x, gridPosition.z];
    }

    public void CreateGridDebugObject(Transform debugObjectPrefab)
    {

        for (int x = 0; x < GetWidth(); x++)
        {
            for (int z = 0; z < GetHeight(); z++)
            {
                GridPosition gridPosition = new GridPosition(x, z);

                Transform debugObjectTranform = Instantiate(debugObjectPrefab, GetWorldPosition(gridPosition), Quaternion.identity);

                GridDebugObject gridDebugObject = debugObjectTranform.GetComponent<GridDebugObject>();

                gridDebugObject.SetGridObject(GetGridObject(gridPosition));
                
            }
        }

        

    }
        

    public bool IsValidGridPosition(GridPosition gridPosition)
    {
        return gridPosition.x >= 0 && gridPosition.z >= 0 && gridPosition.x < width && gridPosition.z < height;
    }
    

}
