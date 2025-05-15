using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GridDebugObject : MonoBehaviour
{
    private GridObject gridObject;
    [SerializeField] private TextMeshPro txtMeshPro;

    public void SetGridObject(GridObject newGridObject)
    {
        this.gridObject = newGridObject;
    }

    private void Start()
    {
        //txtMeshPro.text = gridObject.ToString();
    }

    private void Update()
    {
        txtMeshPro.text = gridObject.ToString();
    }
}
