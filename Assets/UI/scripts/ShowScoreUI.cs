using TMPro;
using UnityEngine;

public class ShowScoreUI : MonoBehaviour
{
    public TextMeshProUGUI killsText;
    public TextMeshProUGUI missesText;
    public TextMeshProUGUI timerText;

    private void Update()
    {
        killsText.text = Score.instance.GetKillCount().ToString();
        missesText.text = Score.instance.GetMissCount().ToString();
        timerText.text = Score.instance.GetTime();
    }

}
