using System.Collections;
using System.Collections.Generic;
using static System.Int32;
using UnityEngine;
using UnityEngine.UI;

namespace ExplodyBlocks.Assets.Scripts
{
    public class HighScoreCount : MonoBehaviour
    {

        public PlayerCollition collition;
        public ScoreCounter scoreCounter;
        public Text highScoreText;


        void Start()
        {
            highScoreText.text = $"High Score: {ScoreManager.HighScore}";
        }

        // Update is called once per frame
        void Update()
        {
            if (FindObjectOfType<GameManager>().isGameOver)
            {
                ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
                scoreManager.evaluateScore();
                highScoreText.text = $"High Score: {ScoreManager.HighScore}";
            }
        }
    }
}