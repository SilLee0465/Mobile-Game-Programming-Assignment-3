using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightInput : MonoBehaviour
{
    [SerializeField] private LerpFoward LerpFoward;
    public bool gameStart, isGameOver = false;
    private float speedModifier;
    private Touch touch;

    void Start()
    {
        speedModifier = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && !isGameOver)
        {
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
            //FindObjectOfType<AudioManager>().Play("Hit");
        }
        if (other.gameObject.tag == "MediumBeat")
        {
            LerpFoward.nxtPosition();
            LerpFoward.StartLerp();
            Time.timeScale = 1.76f;
            //FindObjectOfType<AudioManager>().Play("Hit");
        }
        if (other.gameObject.tag == "SlowBeat")
        {
            LerpFoward.nxtPosition();
            LerpFoward.StartLerp();
            Time.timeScale = 0.4f;
            //FindObjectOfType<AudioManager>().Play("Hit");
        }
        #endregion

        if (other.gameObject.tag == "End")
        {
            //FindObjectOfType<AudioManager>().Play("Hit");
            isGameOver = true;
            Time.timeScale = 0.0f;
        }
        if(other.gameObject.tag == "Miss")
        {
            //FindObjectOfType<AudioManager>().Play("Miss");
            isGameOver = true;
        }
    }
}
