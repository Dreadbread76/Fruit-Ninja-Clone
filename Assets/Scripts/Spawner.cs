using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public List<GameObject> Veggies = new List<GameObject>();

    [Header("Veggie Controls")]
    public float spawnDelay;
    public float throwYMin, throwYMax;
    public float throwXMin, throwXMax;
    public int veggieAmountMin, veggieAmountMax;
    public int veggieAmount;
    public int veggieCount;

    [Header("Wave Controls")]
    public float smallWaveDelay;
    public float largeWaveDelay;
    public int endWaveMin, endWaveMax;
    public int endWave;
    public int currentWave;

    [Header("UI Controls")]
    public Text waveCountText;
    public Text waveTypeText;
    public GameObject StartButton;



    //Start Wave 1 on button press
    public void StartWaves()
    {
        endWave = Random.Range(endWaveMin, endWaveMax);
        currentWave = 0;
        StartButton.SetActive(false);
        StartCoroutine(SpawnVeggies());
        
    }
    public void Update()
    {
        if (currentWave == endWave)
        {
            waveCountText.text = "Wave: " + currentWave + " (Final)";
        }
        else
        {
            waveCountText.text = "Wave: " + currentWave;
        }
    }
    IEnumerator SpawnVeggies()
    {
        Debug.Log("Ready to spawn");
        currentWave++;
        veggieCount = 0;
        int waveType = Random.Range(0, 2);

        StartCoroutine(Wave(waveType));
        if (waveType == 0)
        {
            waveTypeText.text = "Staggered";
        }
        else
        {
            waveTypeText.text = "Together";
        }

        yield return null;
        
    }
    IEnumerator Wave(int waveType)
    {
        Debug.Log("Wave Started");
       
        veggieAmount = Random.Range(veggieAmountMin, veggieAmountMax);

        while(veggieCount <= veggieAmount)
        {
            Vector3 throwX = new Vector3(Random.Range(throwXMin, throwXMax), Random.Range(throwYMin,throwYMax), 0);
            GameObject currentVeggie = Veggies[Random.Range(0,Veggies.Count)];

           
            Instantiate(currentVeggie, throwX, Quaternion.identity);

            if(waveType == 0)
            {
                yield return new WaitForSeconds(spawnDelay);
            }
            
            
            veggieCount++;
        }

        yield return new WaitForSeconds(smallWaveDelay);
        
        StartCoroutine(SpawnVeggies());
        

    }
    

}
