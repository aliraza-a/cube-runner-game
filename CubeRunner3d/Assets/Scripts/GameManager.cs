using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //obsticle object
    public GameObject Obsticle;
    public Transform spawnPoint;
    public float maxSpawnPointX;

    //startPanel object
    public GameObject startPanel;
    public GameObject gamePanel;

    //score object
    int score = 0;
    //high score object
    int highscore = 0;

    //scoreText object
    public Text scoreText;
    //highscore text
    public Text highscoreText;

    //start game object
    bool gameStarted = false;

    //game manager object to access from any script
    public static GameManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //check high score
        if (PlayerPrefs.HasKey("highscore"))
        {
            highscore = PlayerPrefs.GetInt("highscore");
            //set highscore on screen
            highscoreText.text = "high score: "+highscore.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //press any key to start game
        if (Input.anyKeyDown && !gameStarted)
        {
            //disable start panel
            startPanel.gameObject.SetActive(false);

            //show score text when game is started
            gamePanel.gameObject.SetActive(true);

            //start game and load obsticles
            StartCoroutine("SpawnObsticles");
            gameStarted = true;
        }
    }

    //co routine to create obsticles
    IEnumerator SpawnObsticles()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Spawn();
        }
    }

    //randomly create obsticles
    public void Spawn()
    {
        //random function
        float randomSpawnX = Random.Range(-maxSpawnPointX, maxSpawnPointX);

        Vector3 obsticleSpawnPos = spawnPoint.position;
        obsticleSpawnPos.x = randomSpawnX;

        Instantiate(Obsticle, obsticleSpawnPos, Quaternion.identity);
    }

    //restart game function
    public void Restart()
    {
        //check if current score is highscore
        if(score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
        }
        SceneManager.LoadScene(0);
    }
    
    //increase score function
    public void ScoreUp()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
