using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    private int width;
    private int height;
    private float cellSize;
    private GridObject[,] gridObjectArray;
    
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

               Debug.DrawLine(GetWorldPosition(gridPosition),GetWorldPosition(gridPosition) + Vector3.right * 0.5f,Color.magenta,9999f);

                gridObjectArray[x,z] = new GridObject(this,gridPosition);

                //print("Grid Object: " + gridObjectArray[x, z]);
            }
        }

    }

    public int GetWidth()
    {
        return width;
    }

    public int GetHeight() 
    { 
        return height; 
    }

    public Vector3 GetWorldPosition(GridPosition gridPosition)
    {
        return new Vector3(gridPosition.x,0.0f,gridPosition.z) * cellSize;
    }

    public GridObject GetGridObject(GridPosition gridPosition)
    {
        return gridObjectArray[gridPosition.x,gridPosition.z];
    }

    public GridPosition GetGridPosition(Vector3 worldPosition)
    {
        return new GridPosition(Mathf.RoundToInt(worldPosition.x / cellSize), Mathf.RoundToInt(worldPosition.z / cellSize));
    }

    public void CreateDebugObject(Transform debugObjectPrefab)
    {
        for (int x=0;x<GetWidth();x++)
        {
            for(int z=0;z<GetHeight();z++)
            {
                GridPosition gridPosition = new GridPosition(x,z);
                Transform debugObjectTransform = Instantiate(debugObjectPrefab,GetWorldPosition(gridPosition),Quaternion.identity);
                GridDebugObject gridObject  = debugObjectTransform.GetComponent<GridDebugObject>();
                gridObject.SetGridObject(GetGridObject(gridPosition));
            }
        }
    }

    public bool IsValidGridPosition(GridPosition gridPosition)
    {
        return gridPosition.x >= 0 && gridPosition.x < GetWidth() && gridPosition.z >= 0 && gridPosition.z < GetHeight();
    }
    
   
}
