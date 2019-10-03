using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    // public ScoreManager scoreManager;

    // public GameObject ScoreValue;
    public Text showScore;
    // Start is called before the first frame update

    public void UpdateScore()
    {
        showScore.text = "YOUR SCORE : " + (ScoreManager.instance.score).ToString();
    }
}
