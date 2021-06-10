using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fruit.Scoring;


public class Vegetable : MonoBehaviour
{
    #region Variable
    Rigidbody rigi;
    public float throwForceMin;
    public float throwForceMax;
    #endregion
    #region Veggie Launch
    public void OnEnable()
    {
        // Launch veggies up in the air when they spawn

        Vector3 launchVector = new Vector3(0,Random.Range(throwForceMin,throwForceMax), 0);
        rigi = GetComponent<Rigidbody>();
        rigi.AddForce(launchVector, ForceMode.Impulse );

    }
    #endregion
    #region Collisions
    public void OnCollisionEnter(Collision collision)
    {
        // Destroy when hitting a death wall

        if (collision.gameObject.CompareTag("Death"))
        {
            Destroy(this.gameObject);
        }
    }
    #endregion
}
