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
    class SaveData
    {
        public int mm_Points;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.mm_Points = mm_Points;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            mm_Points = data.mm_Points;
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
