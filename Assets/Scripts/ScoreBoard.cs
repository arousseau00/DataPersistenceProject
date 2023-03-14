using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        MainManager.Instance.scoreArray[5].hsName = inputName.text;
        MainManager.Instance.scoreArray[5].hsPoints = MainManager.Instance.mm_Points;
        inputName.enabled = false;
        saveButton.enabled = false;

        //Array.Sort(MainManager.Instance.scoreArray);

        MainManager.Instance.highScoreSet.Add(new MainManager.HighScore {hsName = "asdf",hsPoints = 10});
        //SortedSet<Player> players = players.OrderBy(c => c.PlayerName);
        MainManager.Instance.highScoreSet = SortedSet<HighScore> MainManager.Instance.highScoreSet.OrderBy(c => c.hsPoints);


       // Debug.Log(MainManager.Instance.scoreArray);
    }

 
    public void NewGame()
    {
        MainManager.Instance.NewGame();
    }
}
