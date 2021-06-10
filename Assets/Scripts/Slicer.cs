using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fruit.Scoring;

public class Slicer : MonoBehaviour
{
    #region Variables

    public Camera cam;
    public Vegetable currentVeg;
    public Spawner spawner;
    #endregion
    #region Slicer

    public void DestroyVeg()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        //Shoot out ray and get any veggies it hits
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Hit Veggie");
            GameObject currentObj = hit.transform.gameObject;
            currentVeg = currentObj.GetComponent<Vegetable>();


            //Destroy vegetable when clicked/touched
            if(currentVeg != null)
            {
                Debug.Log("hit");
                Scoring.currentScore++;
                spawner.veggieSource.Play();
                Destroy(currentObj);
            }

        }
    }
    #endregion
}
