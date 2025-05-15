using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : BaseAction
{
    [Header("Movement Props")]
    [SerializeField] private float rotationSpeed = 7.0f;
    [SerializeField] private float movementSpeed = 6.5f;
    [SerializeField] private float stoppingDistance = 0.1f;
    [SerializeField] private int maxMoveDistance = 1;
    private Vector3 targetPosition;
    public override void Awake()
    {
        base.Awake();
        targetPosition = transform.position;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        Vector3 moveDirection = (targetPosition - transform.position).normalized;

        if (Vector3.Distance(targetPosition,transform.position) > stoppingDistance)
        {
           
            transform.position += moveDirection * movementSpeed * Time.deltaTime;


        }
       

        transform.forward += Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotationSpeed);
    }

    public void Move(GridPosition gridPosition)
    {
        targetPosition = LevelGrid.Instance.GetWorldPosition(gridPosition);
    }

    public bool IsValidActionAtGridPosition(GridPosition gridPosition)
    {
        List<GridPosition> validGridPosition = GetValidActionAtGridPosition();
        return validGridPosition.Contains(gridPosition);
    }

    public List<GridPosition> GetValidActionAtGridPosition()
    {
        List<GridPosition> validGridPositionList = new List<GridPosition>();

        GridPosition unitGridPosition = unit.GetGridPosition();

        for(int x = -maxMoveDistance; x <= maxMoveDistance; x++)
        {
            for(int z = -maxMoveDistance; z <= maxMoveDistance; z++)
            {
                GridPosition offsetGridPosition = new GridPosition(x,z);

                GridPosition testGridPosition = unitGridPosition + offsetGridPosition;

                if (!LevelGrid.Instance.IsValidGridPosition(testGridPosition))
                {
                    continue;
                }

                if(LevelGrid.Instance.HasAnyUnitAtGridPosition(testGridPosition))
                {
                    continue;
                }

                if(testGridPosition ==  unitGridPosition)
                {
                    continue;
                }

                //Debug.Log(testGridPosition);

                validGridPositionList.Add(testGridPosition);
            }
        }

        return validGridPositionList;
    }

    public override string GetActionName()
    {
        return "Move";
    }
}
