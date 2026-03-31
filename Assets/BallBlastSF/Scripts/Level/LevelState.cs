using UnityEngine;
using UnityEngine.Events;

public class LevelState : MonoBehaviour
{

    [SerializeField] private Cart cart;
    [SerializeField] private StoneSpawner stoneSpawner;

    private int currentLevel = 1;
    public int CurrentLevel => currentLevel;

    [Space(5)]
    public UnityEvent Passed;
    public UnityEvent Defeat;
    public UnityEvent Restart;
    public UnityEvent OnNextLevel;
   

    private float timer;
    private bool isCheckPassed = false;

    private void Start()
    {
        stoneSpawner.Complete.AddListener(OnStoneSpawnerComplete);
        cart.CollisionStone.AddListener(OnCollisionStone);
    }

    private void OnDestroy()
    {
        stoneSpawner.Complete.RemoveListener(OnStoneSpawnerComplete);
        cart.CollisionStone.RemoveListener(OnCollisionStone);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.5f)
        {
            //All the stones've been destoryed
            if (isCheckPassed && FindObjectsByType<Stone>(FindObjectsSortMode.None).Length == 0)
            {
                Passed.Invoke();
                isCheckPassed = false;
            }

            timer = 0;
        }
    }

    private void OnCollisionStone()
    {
        Defeat.Invoke();
    }

    private void OnStoneSpawnerComplete()
    {
        isCheckPassed = true;
    }

    public void Reset()
    {
        Stone[] stones = FindObjectsByType<Stone>(FindObjectsSortMode.None);
        Projectile[] projectiles = FindObjectsByType<Projectile>(FindObjectsSortMode.None);
        isCheckPassed = false;

        foreach (var stone in stones)
        {
            Destroy(stone.gameObject);
        }

        foreach (var proj in projectiles)
        {
            Destroy(proj.gameObject);
        }

        Restart.Invoke();
    }

    public void NextLevel()
    {
        stoneSpawner.NextLevel();
        currentLevel++;
        isCheckPassed = false;
        OnNextLevel.Invoke();
    }
}