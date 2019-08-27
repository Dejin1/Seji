using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button endButton;
    [SerializeField] private Slider villagerSlider;
    [SerializeField] private Slider enemySlider;
    private float set_targetTime = 180.0f;
    private float targetTime;
    public bool timerStarted;
    public bool gameOver = false;

    private void Start()
    {
        timerReset();
        villagerSlider.value = VillagerController.spawnTimer / 5f;
        enemySlider.value = EnemyController.spawnTimer / 10f;
    }

    void Update()
    {
        if (timerStarted)
        {
            targetTime -= Time.deltaTime;


            if (targetTime <= 0.0f)
            {
                timerEnded();
            }
        }
    }

    public void StartTimer()
    {
        timerStarted = true;
        VillagerController.isSpawning = true;
        EnemyController.isSpawning = true;
        startButton.gameObject.SetActive(false);
    }

    public void EndDay()
    {
        SceneManager.LoadScene("Game");
    }

    void timerEnded()
    {
        VillagerController.isSpawning = false;
        EnemyController.isSpawning = false;
        gameOver = true;
        endButton.gameObject.SetActive(true);
    }

    void timerReset()
    {
        targetTime = set_targetTime;
        timerStarted = false;
    }


}
