using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LeftRightInput LeftRightInput;
    [SerializeField] private AudioSource Music;
    private bool startPlaying;

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (LeftRightInput.gameStart == true)
            {
                startPlaying = true;

                Music.Play();
            }
        }
        if (LeftRightInput.isGameOver == true)
        {
            Music.Stop();
        }
    }
}
