using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeftRightInput : MonoBehaviour
{
    [SerializeField] private GameObject Instructions;
    [SerializeField] private LerpFoward LerpFoward;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private GameObject gameOver;
    public bool gameStart, isGameOver = false;
    private float speedModifier;
    private Touch touch;
    private int score;

    void Start()
    {
        speedModifier = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score " + score.ToString("0");
        if (Input.touchCount > 0 && !isGameOver)
        {
            Instructions.SetActive(false);
            gameStart = true;
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speedModifier, transform.position.y, transform.position.z);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        #region beat speed
        if (other.gameObject.tag == "FastBeat")
        {
            LerpFoward.nxtPosition();
            LerpFoward.StartLerp();
            Time.timeScale = 3.5f;
            score += 100;
        }
        if (other.gameObject.tag == "MediumBeat")
        {
            LerpFoward.nxtPosition();
            LerpFoward.StartLerp();
            Time.timeScale = 1.77f;
            score += 100;
        }
        if (other.gameObject.tag == "SlowBeat")
        {
            LerpFoward.nxtPosition();
            LerpFoward.StartLerp();
            Time.timeScale = 0.4f;
            score += 100;
        }
        #endregion

        if (other.gameObject.tag == "End")
        {
            isGameOver = true;
            Time.timeScale = 0.0f;
        }
        if(other.gameObject.tag == "Miss")
        {
            //FindObjectOfType<AudioManager>().Play("Miss");
            isGameOver = true;
            gameOver.SetActive(true);
            if(isGameOver == true && score > PlayerPrefs.GetInt("FatRatUnityHighScore", 0))
            {
                PlayerPrefs.SetInt("FatRatUnityHighScore", score);
                highScoreText.text = "New High Score! " + PlayerPrefs.GetInt("FatRatUnityHighScore", 0).ToString();
            }
            else
            {
                highScoreText.text = "High Score " + PlayerPrefs.GetInt("FatRatUnityHighScore", 0).ToString();
            }
        }
    }
}
