using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Spawner : MonoBehaviour
{
    #region Variables
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
    public GameObject RestartButton;


    [Header("Sound")]
    public AudioMixer audioMixer;
    public AudioSource musicSource;
    public AudioSource veggieSource;
    #endregion
    #region Start
    private void Start()
    {
        StartButton.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(false);
    }
    #endregion
    #region Waves Starting
    //Start Wave 1 on button press
    public void StartWaves()
    {
        endWave = Random.Range(endWaveMin, endWaveMax);
        currentWave = 0;
        StartButton.SetActive(false);
        StartCoroutine(SpawnVeggies());
        
    }
    #endregion
    #region Update

    public void Update()
    {
        // Display to the player it is the final wave when on the final wave
        if (currentWave == endWave)
        {
            waveCountText.text = "Wave: " + currentWave + " (Final)";
        }

        // Reset game when final wave is passed
        else if(currentWave > endWave)
        {
            currentWave = 0;
            RestartButton.SetActive(true);

        }
        // Normal wave display
        else
        {
            waveCountText.text = "Wave: " + currentWave;
        }
    }
    #endregion
    #region Wave Type Setting
    IEnumerator SpawnVeggies()
    {
        //Set the wave type to either staggered spawning or spawn together
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
    #endregion
    #region Wave Spawning
    IEnumerator Wave(int waveType)
    {
        Debug.Log("Wave Started");
       
        //Randomise amount of veggies in wave
        veggieAmount = Random.Range(veggieAmountMin, veggieAmountMax);

        // end wave when all veggies are spawned
        while(veggieCount <= veggieAmount)
        {
            // Spawn on different places along the horizontal axis
            Vector3 throwX = new Vector3(Random.Range(throwXMin, throwXMax), Random.Range(throwYMin,throwYMax), 0);

            //Randomise Veggie types
            GameObject currentVeggie = Veggies[Random.Range(0,Veggies.Count)];

            // Spawn the veggie
            Instantiate(currentVeggie, throwX, Quaternion.identity);

            //Delay the next veggie spawn if wave is staggered
            if(waveType == 0)
            {
                yield return new WaitForSeconds(spawnDelay);
            }
            
            
            veggieCount++;
        }
        // Delay between next wave
        yield return new WaitForSeconds(smallWaveDelay);
        
        // Next Wave
        StartCoroutine(SpawnVeggies());
        

    }
    #endregion
    #region Restart Game
    // Get the current scene and reload
    public void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(currentScene.name);
        }


    }
    #endregion
}
