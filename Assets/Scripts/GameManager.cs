using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] public int enemiesAlive = 0;
    [SerializeField] private int round = 0;
    [SerializeField] public int zombiesKilled = 0;
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private TextMeshProUGUI roundNumber;
    [SerializeField] private TextMeshProUGUI roundsSurvived;
    [SerializeField] private TextMeshProUGUI zombiesKilledNumber;
    [SerializeField] private TextMeshProUGUI zombiesKilledNumberResult;
    [SerializeField] private GameObject endScreen;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesAlive == 0)
        {
            round++;
            NextWave(round);
            roundNumber.text = "Round: " + round.ToString();
        }
        zombiesKilledNumber.text = "Zombies killed: " + zombiesKilled.ToString();
    }

    public void NextWave(int round)
    {
        for (var x = 0; x < round; x++)
        {
            GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            GameObject enemySpawned = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);

            enemySpawned.GetComponent<EnemyManager>().gameManager = GetComponent<GameManager>();

            enemiesAlive++;
        }
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        endScreen.SetActive(true);
        roundsSurvived.text = round.ToString();
        zombiesKilledNumberResult.text = zombiesKilled.ToString();
    }

    public void LoadScene1(string scene)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    }
}
