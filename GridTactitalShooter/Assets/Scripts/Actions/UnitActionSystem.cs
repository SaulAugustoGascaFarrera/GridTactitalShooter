using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class UnitActionSystem : MonoBehaviour
{
    public static UnitActionSystem Instance { get; private set; }

    public event EventHandler OnSelectedUnit;

    [SerializeField] private Unit selectedUnit;


    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

   
    void Start()
    {
        GameInput.Instance.OnMove += Instance_OnMove;
    }

    private void Instance_OnMove(object sender, EventArgs e)
    {

       
        if (TryGetSelectedUnit() || !selectedUnit) return;

       
        GridPosition gridPosition = LevelGrid.Instance.GetGridPosition(MouseManager.Instance.GetMouseWorldPosition());


        if (!LevelGrid.Instance.IsValidGridPosition(gridPosition)) return;

        selectedUnit.GetMoveAction().Move(gridPosition);
    }

   
    void Update()
    {
        

        if(Input.GetMouseButtonDown(1))
        {
            if (!selectedUnit) return;

            selectedUnit.GetSpinAction().Spin();

        }
    }

    public bool TryGetSelectedUnit()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, 1 << 7))
        {
            if (hit.transform.gameObject.TryGetComponent(out Unit unit))
            {
                SetSelectedUnit(unit);

                return true;
            }
           
        }
       
        return false;
        


    }


    private void SetSelectedUnit(Unit newSelectedUnit)
    {
        selectedUnit = newSelectedUnit;

        OnSelectedUnit?.Invoke(this, EventArgs.Empty);
    }


    public Unit GetSelectedUnit()
    {
        return selectedUnit;
    }
}
