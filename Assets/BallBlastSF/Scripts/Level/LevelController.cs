using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelState state;
    [SerializeField] private CartInputControl control;

    public void ResetLevel()
    {
        state.Reset();
        control.enabled = true;
        Time.timeScale = 1f;
    }

    public void PassLevel()
    {
        control.enabled = false;
        Time.timeScale = 0f;
    }

    public void NextLevel()
    {
        state.NextLevel();
        control.enabled = true;
        Time.timeScale = 1f;
    }
}
