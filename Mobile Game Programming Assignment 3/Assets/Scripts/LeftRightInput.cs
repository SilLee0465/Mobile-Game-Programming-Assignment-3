using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightInput : MonoBehaviour
{
    [SerializeField] private LerpFoward LerpFoward;
    public bool gameStart, isGameOver = false;
    private float speedModifier;
    private Touch touch;
    [HideInInspector] public float multiplier;

    void Start()
    {
        speedModifier = 0.01f;
        multiplier = 0.6f;
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
        if (other.gameObject.tag == "HyperFastBeat")
        {
            LerpFoward.nxtPosition();
            LerpFoward.StartLerp();
            multiplier = 2.5f;
            //FindObjectOfType<AudioManager>().Play("Hit");

        }
        if (other.gameObject.tag == "FastBeat")
        {
            LerpFoward.nxtPosition();
            LerpFoward.StartLerp();
            multiplier = 1.25f;
            //FindObjectOfType<AudioManager>().Play("Hit");
        }
        if (other.gameObject.tag == "MediumBeat")
        {
            LerpFoward.nxtPosition();
            LerpFoward.StartLerp();
            multiplier = 1.10f;
            //FindObjectOfType<AudioManager>().Play("Hit");
        }
        #endregion

        if (other.gameObject.tag == "End")
        {
            //FindObjectOfType<AudioManager>().Play("Hit");
            isGameOver = true;
        }
        if(other.gameObject.tag == "Miss")
        {
            //FindObjectOfType<AudioManager>().Play("Miss");
            isGameOver = true;
        }
    }
}
