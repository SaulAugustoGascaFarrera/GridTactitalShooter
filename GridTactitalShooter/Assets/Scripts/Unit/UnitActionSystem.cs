using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    public event EventHandler OnSelectedUnit;

    public static UnitActionSystem Instance { get; private set; }

     [SerializeField] private Unit selectedUnit;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameInput.Instance.OnMove += Instance_OnMove;
    }

    private void Instance_OnMove(object sender, EventArgs e)
    {

        if (TryGetSelectedUnit() || !selectedUnit) return;

        GridPosition gridPosition = LevelGrid.Instance.GetGridPosition(MouseManager.Instance.GetMouseWorldPosition());

        if (selectedUnit.GetMoveAction().IsValidActionAtGridPosition(gridPosition))
        {
            selectedUnit.GetMoveAction().Move(gridPosition);
        }
        
        

        
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public bool TryGetSelectedUnit()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray,out RaycastHit hit,float.MaxValue,1 << 7))
        {
            if (hit.transform.gameObject.TryGetComponent(out Unit unit))
            {
                SetSelectedUnit(unit);

                return true;
            }
        }


        return false;
    }


    public void SetSelectedUnit(Unit newSelectedUnit)
    {
        this.selectedUnit = newSelectedUnit;

        OnSelectedUnit?.Invoke(this, EventArgs.Empty);
    }


    public Unit GetSelectedUnit()
    {
        return selectedUnit;
    }


}
