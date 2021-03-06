﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class GameManager : MonoBehaviour
{
    public bool isGameOver { get; private set; }
    public AudioClip deathSaw;

    public void gameOver() {
        playDeath();
        isGameOver = true;
    }

    private void Update()
    {
        if (isGameOver) {
            if (Input.GetKey("space")) {
                restart();
                Time.timeScale = 1f;
            }
        }
    }

    private void restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void playDeath()
    {
        var movement = FindObjectOfType<PlayerMovement>();
        var scoreCounter = FindObjectOfType<ScoreCounter>();
        var deathLayer = FindObjectOfType<PostProcessLayer>();

        playDeathAudio();
        movement.enabled = false;
        scoreCounter.enabled = false;
        Time.timeScale = 0.3f;
        deathLayer.enabled = true;
    }

    private void playDeathAudio()
    {
        if (!isGameOver)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            AudioSource audioSource = player.GetComponent<AudioSource>();
            audioSource.clip = deathSaw;
            audioSource.Play();
        }
    }
}
