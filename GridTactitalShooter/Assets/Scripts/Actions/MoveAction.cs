using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : BaseAction
{
    public static MoveAction Instance { get; private set; }


    [Header("Movement Props")]
    [SerializeField] private float movementSpeed = 6.0f;
    [SerializeField] private float rotationSpeed = 7.5f;

    float stoppingDistance = 0.1f;

    private Vector3 targetPosition;

    private void Awake()
    {
        targetPosition = transform.position;
    }

   
    
    // Update is called once per frame
    void Update()
    {

        if (!isActive) return;

        Vector3 moveDirection = (targetPosition - transform.position).normalized;

        if(Vector3.Distance(targetPosition,transform.position) > stoppingDistance)
        {
            transform.position += moveDirection * movementSpeed * Time.deltaTime;

            transform.forward = Vector3.Slerp(transform.forward, moveDirection, rotationSpeed * Time.deltaTime);
        }
        

    }

    public void Move(GridPosition gridPosition)
    {
        isActive = true;

        targetPosition = LevelGrid.Instance.GetWorldPosition(gridPosition);
    }


 
    public override string GetActionName()
    {
        return "Move";
    }
}
