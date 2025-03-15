using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private TargetSpawner targetSpawner;

    [Header("Menu")]
    public GameObject MainMenu;
    public Button Play;
    public Button Quit;
    public Slider sliderSpeed;
    public Toggle littleToggle;
    public Toggle mediumToggle;
    public Toggle LargeToggle;
    public Slider mouseSpeed;
    public TextMeshProUGUI mouseSpeedText;
    public TextMeshProUGUI spawnSpeed;

    [Header("Game Over")]
    public GameObject GameOver;
    public TextMeshProUGUI killsResult;
    public TextMeshProUGUI missesResult;
    public TextMeshProUGUI timeResult;
    public Button okButton;

    public bool GameStart = false;

    private void Awake()
    {
        targetSpawner = GetComponent<TargetSpawner>();
    }

    private void Start()
    {
        Play.onClick.AddListener(StartGame);
        Quit.onClick.AddListener(QuitGame);
        okButton.onClick.AddListener(BackToMainMenu);
    }

    private void Update()
    {
        if ((Score.instance.GetTotalSpawnedTargets() >= 30 && GameStart) || (Input.GetKeyDown(KeyCode.Escape) && GameStart))
        {
            GameStart = false;
            GameOver.SetActive(true);
            killsResult.text = "Kills : " + Score.instance.GetKillCount();
            missesResult.text = "Misses : " + Score.instance.GetMissCount();
            timeResult.text = "Time : " + Score.instance.GetTime();

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        spawnSpeed.text = (Mathf.Round(sliderSpeed.value * 10f) / 10f) + " sec";
        mouseSpeedText.text = (Mathf.Round(mouseSpeed.value * 10f) / 10f).ToString();
    }

    private void StartGame()
    {
        MainMenu.SetActive(false);
        GameStart = true;
        targetSpawner.startSpawn = true;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void BackToMainMenu()
    {
        GameOver.SetActive(false);
        MainMenu.SetActive(true);

        Score.instance.ClearAll();
    }

    public float SetTargetSize()
    {
        if (littleToggle.isOn)
        {
            return 1f;
        }
        else if (mediumToggle.isOn)
        {
            return 2f;
        }
        else
        {
            return 3f;
        }
    }

    public float GetSpawnSpeed()
    {
        return (Mathf.Round(sliderSpeed.value * 10f) / 10f);
    }
    public float GetMouseSpeed()
    {
        return (Mathf.Round(mouseSpeed.value * 10f) / 10f);
    }
}
