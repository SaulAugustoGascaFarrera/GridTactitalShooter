using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAction : MonoBehaviour
{

    private bool isActive;

    public abstract string GetActionName();
}
