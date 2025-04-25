using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAction : BaseAction
{


    private float totalSpinAmount;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) return;


        float spinAddAmount = 360.0f * Time.deltaTime;

        transform.eulerAngles += new Vector3(0.0f,spinAddAmount,0.0f);

        totalSpinAmount += spinAddAmount;


        if(totalSpinAmount >= 360.0f)
        {
            isActive = false;
            totalSpinAmount = 0.0f;
        }

    }

    public void Spin()
    {
        isActive = true;
    }

    public override string GetActionName()
    {
        return "Spin";
    }
}
