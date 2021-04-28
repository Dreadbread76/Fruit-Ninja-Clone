using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slicer : MonoBehaviour
{
    Rigidbody rigi;
    public static bool slicing;

    void Start()
    {
        rigi = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        rigi.position = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            slicing = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            slicing = false;
        }
    }
}
