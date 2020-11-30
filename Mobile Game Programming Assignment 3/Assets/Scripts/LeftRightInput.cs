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
        if(Input.touchCount > 0 && !isGameOver)
        {
            gameStart = true;
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speedModifier, transform.position.y, transform.position.z);
            }
            //if (Input.GetTouch(0).phase == TouchPhase.Began)
            //{
            //    gameStart = true;
            //}
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Tile")
        {
            LerpFoward.nxtPosition();
            LerpFoward.StartLerp();
        }
        else if(other.gameObject.tag == "End")
        {
            isGameOver = true;
        }
        else if(other.gameObject.tag == "Miss")
        {
            isGameOver = true;
        }
    }
}
