using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject : MonoBehaviour
{

    private GridSystem gridSystem;
    private GridPosition gridPosition;
    private List<Unit> unitList;

    public GridObject(GridSystem gridSystem, GridPosition gridPosition)
    {
        unitList = new List<Unit>();
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
    }

    public override string ToString()
    {
        string unitString = "";

        if (HasAnyUnitAtGridPosition())
        {
            
            foreach(Unit unit in unitList)
            {
                unitString += unit.ToString() + "\n";  
            }

        }

        return gridPosition.ToString() + "\n" + unitString;
    }


    public void AddUnitAtGridPosition(Unit unit)
    {
        unitList.Add(unit);
    }

    public void RemoveUnitAtGridPosition(Unit unit)
    {
        unitList.Remove(unit);
    }

    public bool HasAnyUnitAtGridPosition()
    {
        return unitList.Count > 0;
    }

    public List<Unit> GetUnitList()
    {
        return unitList;
    }


}
