using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Fruit.Scoring
{
    public class Scoring : MonoBehaviour
    {
        #region Variables
        public static int currentScore;
        public Text scoreText;

        #endregion

        void Start()
        {
            currentScore = 0;
            
        }
        private void Update()
        {
            //Update score (in hindsight this could have been done better)
            scoreText.text = "Score = " + currentScore;
        }



    }

}


