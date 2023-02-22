using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public Text ScoreText;
    public InputField inputName;


    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = $"Your score : {MainManager.Instance.m_Points}";
    }
    void SaveNewScore()
    {
        GameObject.Find("HighScore1");
    }
}
