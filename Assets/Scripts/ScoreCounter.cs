using System;
using UnityEngine;
using UnityEngine.UI;


namespace ExplodyBlocks.Assets.Scripts
{
    public class ScoreCounter : MonoBehaviour
    {

        public Transform player;
        public Text score;

        // Update is called once per frame
        void Update()
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.updateScore();

            score.text = $"{Math.Round(scoreManager.CurrentScore)}";
        }
    }
}
