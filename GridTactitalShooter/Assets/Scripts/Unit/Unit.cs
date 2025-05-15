using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

   

    private GridPosition gridPosition;
    private MoveAction moveAction;
    private SpinAction spinAction;
    private BaseAction[] baseActions;

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
       LevelGrid.Instance.AddUnitAtGridPosition(this, gridPosition);    
    }

    // Update is called once per frame
    void Update()
    {
        GridPosition updateGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);

        if(updateGridPosition != gridPosition)
        {
            LevelGrid.Instance.UpdateUnitAtGridPosition(this,gridPosition,updateGridPosition);

            gridPosition = updateGridPosition;
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

    public GridPosition GetGridPosition()
    {
        return gridPosition;
    }



}
