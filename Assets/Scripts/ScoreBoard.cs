using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public MainManager Manager;

    public Text scoreText;
    public TMP_InputField inputName;
    public Button saveButton;
    public List<TextMeshProUGUI> highScoreTexts = new List<TextMeshProUGUI>();


    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = $"Your score : {MainManager.Instance.mm_Points}";
    }

    public void SaveNewScore()
    {
        
        highScoreTexts[0].text = $"{inputName.text} - {MainManager.Instance.mm_Points}";
        inputName.enabled = false;
        saveButton.enabled = false;
    }

 
    public void NewGame()
    {
        MainManager.Instance.NewGame();
    }
}
