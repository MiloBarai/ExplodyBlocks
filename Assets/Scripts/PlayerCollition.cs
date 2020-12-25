using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class PlayerCollition : MonoBehaviour
{
    public PlayerMovement movement;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
    }

    private void OnCollisionEnter(Collision collision)
    {   

        if (collision.collider.tag == "Obstacle") {
            FindObjectOfType<GameManager>().gameOver();
        }
    }
}
