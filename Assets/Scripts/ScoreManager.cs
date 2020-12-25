using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int HighScore { get; set; }
    public double CurrentScore { get; set; }

    private Vector3 previousPosition;

    public void evaluateScore() {
        if (CurrentScore > HighScore) {
            HighScore = (int) Math.Round(CurrentScore);
        }
    }

    public void updateScore() {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        if (Math.Abs(player.position.z - previousPosition.z) >= 1) {
                CurrentScore += Math.Max(0, (player.position.z - previousPosition.z) / 10);
                previousPosition = player.position;
        }
    }
}
