using UnityEngine;
using UnityEngine.UI;

public class UIProgressPanel : MonoBehaviour
{
    [SerializeField] private LevelState levelState;
    [SerializeField] private StoneSpawner stoneSpawner;
    [SerializeField] private Image progressBar;

    [SerializeField] private Text currentLevelText;
    [SerializeField] private Text nextLevelText;

    private float progressBarStep;

    public void Start()
    {
        progressBar.fillAmount = 0;
        currentLevelText.text = levelState.CurrentLevel.ToString();
        nextLevelText.text = (levelState.CurrentLevel + 1).ToString();
        progressBarStep = 1f / stoneSpawner.StonesAmount;
    }

    public void AddProgress()
    {
        progressBar.fillAmount += progressBarStep;
    }
}