using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Fruit.Scoring
{
    public class Scoring : MonoBehaviour
    {
        
        public static int currentScore;
        public Text scoreText;
        void Start()
        {
            currentScore = 0;
            
        }
        private void Update()
        {
            scoreText.text = "Score = " + currentScore;
        }



    }

}


