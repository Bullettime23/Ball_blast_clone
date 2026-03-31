using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private CartInputControl control;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject defeatScreen;

    private void Awake()
    {
        Pause();
    }

    public void Pause()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        control.enabled = false;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        control.enabled = true;
    }

    public void OnDefeat()
    {
        Time.timeScale = 0f;
        control.enabled = false;
        defeatScreen.SetActive(true);
    }
}
