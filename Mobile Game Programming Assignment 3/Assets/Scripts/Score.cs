using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI FatRatUnityHighScore;
    // Start is called before the first frame update
    void Start()
    {
        FatRatUnityHighScore.text = "High Score " + PlayerPrefs.GetInt("FatRatUnityHighScore", 0).ToString();
    }
}
