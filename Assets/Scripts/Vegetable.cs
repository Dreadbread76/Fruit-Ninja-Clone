using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : MonoBehaviour
{
    Rigidbody rigi;
    public float throwForceMin;
    public float throwForceMax;

    public void OnEnable()
    {

        Vector3 launchVector = new Vector3(0,Random.Range(throwForceMin,throwForceMax), 0);
        rigi = GetComponent<Rigidbody>();
        rigi.AddForce(launchVector, ForceMode.Impulse );

    }

}
