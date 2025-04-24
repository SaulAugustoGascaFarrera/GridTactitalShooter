using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : BaseAction
{
    private Unit unit;

    private void Awake()
    {
        unit = GetComponent<Unit>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override string GetActionName()
    {
        return "Move";
    }
}
