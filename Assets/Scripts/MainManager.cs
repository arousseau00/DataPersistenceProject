using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    private GameManager gManager;
    public int mm_Points;
    public Text scoreText;
    public HighScore[] scoreArray = new HighScore[6];

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        LoadScore();
    }

    private void Update()
    {
        scoreText.text = $"Score : {mm_Points}";
    }


    [System.Serializable]
    public class HighScore
    {
        public string hsName;
        public int hsPoints;
    }

    public void SaveScore()
    {
        HighScore data = new HighScore();
        data.hsPoints = mm_Points;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScore data = JsonUtility.FromJson<HighScore>(json);

            mm_Points = data.hsPoints;
        }
    }
    

    public void NewGame()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            SceneManager.LoadScene(0);
        }
        

    }
    public void GameOver()
    {
        SceneManager.LoadScene(1);
    }
}
