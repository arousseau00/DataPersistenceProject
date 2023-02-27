using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public MainManager Manager;

    public Brick BrickPrefab;
    public int LineCount = 6;
    public int gm_Points;
    private Rigidbody ball;
    

    private bool gm_Started = false;

    // Start is called before the first frame update
    void Start()
    {
        gm_Started = false;
        gm_Points = 0;
        MainManager.Instance.mm_Points = 0;
        ball = GameObject.Find("Paddle/Ball").GetComponent<Rigidbody>();
        MainManager.Instance.scoreText = GameObject.Find("Canvas/ScoreText").GetComponent<Text>();

        LayBricks();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gm_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gm_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                ball.transform.SetParent(null);
                ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }

        
    }
    void LayBricks()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }
    public void AddPoint(int point)
    {
        gm_Points += point;
        MainManager.Instance.mm_Points = gm_Points;
    }

}
