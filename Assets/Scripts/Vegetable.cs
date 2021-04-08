using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : MonoBehaviour
{
    Rigidbody rigi;
    public float throwForce;
    public void OnAwake()
    {
        rigi = GetComponent<Rigidbody>();
        rigi.AddForce(0, throwForce, 0, ForceMode.Impulse);
    }
}
