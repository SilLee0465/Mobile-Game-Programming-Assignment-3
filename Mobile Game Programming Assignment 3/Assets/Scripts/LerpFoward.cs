using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpFoward : MonoBehaviour
{
    [SerializeField] private LeftRightInput LeftRightInput;
    [SerializeField] private GameObject currentPos, nxtPos;
    public GameObject Tiles;    
    Vector3 current, nxt;
    private int i = 1;
    private float t;

    // Start is called before the first frame update
    void Start()
    {
        currentPos = Tiles.transform.GetChild(0).gameObject;
        current = currentPos.transform.localPosition;
        nxtPos = Tiles.transform.GetChild(1).gameObject;
        nxt = nxtPos.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (LeftRightInput.gameStart == true)
        {
            StartLerp();
        }
    }

    public void StartLerp()
    {
        if(t <= 1.0f)
        {
            t += 0.5f * Time.deltaTime;
            transform.localPosition = Vector3.LerpUnclamped(current, nxt, t);
        }
        else
        {
            EndLerp();
        }
    }

    void EndLerp()
    {
        transform.localPosition = nxt;
    }

    public void nxtPosition()
    {
        currentPos = Tiles.transform.GetChild(0 + i).gameObject;
        current = currentPos.transform.localPosition;
        nxtPos = Tiles.transform.GetChild(1 + i).gameObject;
        nxt = nxtPos.transform.localPosition;
        t = 0.0f;
        i++;
    }
}