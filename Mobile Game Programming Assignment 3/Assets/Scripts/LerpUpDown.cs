﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpUpDown : MonoBehaviour
{
    [SerializeField] private LeftRightInput LeftRightInput;
    public Transform tUp, tDown;
    private Vector3 up, down;
    private float t;
    // Start is called before the first frame update
    void Start()
    {
        up = tUp.transform.localPosition;
        down = tDown.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(LeftRightInput.gameStart == true)
        {
            t += Time.deltaTime;
            transform.localPosition = Vector3.LerpUnclamped(down, up, t);
            if (t >= 1.0f)
            {
                transform.localPosition = up;
                t = 0;
                Vector3 temp = up;
                up = down;
                down = temp;
            }
        }
    }
}
