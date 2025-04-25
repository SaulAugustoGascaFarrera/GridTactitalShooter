using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private MoveAction moveAction;
    private SpinAction spinAction;
    private BaseAction[] baseActions;

    private GridPosition gridPosition;

    private void Awake()
    {
        moveAction = GetComponent<MoveAction>();
        spinAction = GetComponent<SpinAction>();
        baseActions = GetComponents<BaseAction>();

    }

    // Start is called before the first frame update
    void Start()
    {
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.SetAddUnitAtGridPosition(this, gridPosition);
        
    }

    // Update is called once per frame
    void Update()
    {
        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);

        if(newGridPosition != gridPosition)
        {
            LevelGrid.Instance.UnitMovedAtGridPosition(this,gridPosition,newGridPosition);

            gridPosition = newGridPosition;
        }

    }

    public MoveAction GetMoveAction()
    { 
        return moveAction;
    }

    public SpinAction GetSpinAction()
    {
        return spinAction;
    }

}
