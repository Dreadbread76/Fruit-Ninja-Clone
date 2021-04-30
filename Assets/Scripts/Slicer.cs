using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fruit.Scoring;

public class Slicer : MonoBehaviour
{
  
    
    public Camera cam;
    public Vegetable currentVeg;
    public Spawner spawner;
   
    public void DestroyVeg()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Hit Veggie");
            GameObject currentObj = hit.transform.gameObject;
            currentVeg = currentObj.GetComponent<Vegetable>();

            if(currentVeg != null)
            {
                Debug.Log("hit");
                Scoring.currentScore++;
                spawner.veggieSource.Play();
                Destroy(currentObj);
            }

        }
    }
}
