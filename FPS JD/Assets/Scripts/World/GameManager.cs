using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    public GameObject winPanel;

    public GameObject missionPanel;

    public Text ammoText;

    public Text healthText;

    public Text scoreText;



    public static GameManager Instance { get; private set; }

    public int gunAmmo = 10;

    public int health = 100;

    public int score = 0;

    public int bossHealth = 20;

    private bool minionsDefeated = false;

    private void Awake()
    {
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = gunAmmo.ToString();
        healthText.text = health.ToString();
        scoreText.text = score.ToString();
        CheckScore();
        CheckBossHealth();
        if (health <= 0 && Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
        if (bossHealth <= 0 && Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        CheckHealth();
    }

    public void CheckHealth()
    {
        if (health <= 0)
        {
            // Debug.Log("You are dead");
            Time.timeScale = 0f;
            gameOverPanel.SetActive(true);
        }
    }

    public void CheckScore()
    {
        if (score >= 10 && !minionsDefeated)
        {
            minionsDefeated = true;
            missionPanel.SetActive(true);
            Destroy(missionPanel, 3);
        }
    }

    public void BossDamaged(int damage)
    {
        bossHealth -= damage;
    }

    public void CheckBossHealth()
    {
        if (bossHealth <= 0)
        {
            GameObject boss = GameObject.FindGameObjectWithTag("Boss");
            Destroy(boss);
            winPanel.SetActive(true);
        }
    }

    public void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;

    }
}
