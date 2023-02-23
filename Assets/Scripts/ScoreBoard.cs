using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public Text scoreText;
    public TextMeshProUGUI inputName;
    public List<TextMeshProUGUI> highScoreTexts = new List<TextMeshProUGUI>();


    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = $"Your score : {MainManager.Instance.m_Points}";
    }

    public void SaveNewScore()
    {
        highScoreTexts[0].text = $"{inputName.text} - {MainManager.Instance.m_Points}";
    }
}
