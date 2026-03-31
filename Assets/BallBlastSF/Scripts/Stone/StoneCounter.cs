using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class StoneCounter : MonoBehaviour
{
    // Нужна единственная сущность, к которой будет иметь доступ каждый камень и ui panel

    private static Dictionary<int, List<Stone>> stones = new();
    public static StoneCounter Instance;

    public UnityEvent StoneDestroyed;

    private void Awake()
    {
        // Singletone
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    public static void RegisterStoneInCollection(Stone stone)
    {
        if (stones.ContainsKey(stone.CounterId))
        {
            stones[stone.CounterId].Add(stone);
            return;
        }
        stones.Add(stone.CounterId, new List<Stone> { stone });
    }

    public static void PopStoneFromColletcion(Stone stone)
    {
        if (!stones.ContainsKey(stone.CounterId)) return;

        if (stones[stone.CounterId].Exists((Stone stoneFormColletcion) => stone == stoneFormColletcion))
        {
            stones[stone.CounterId].Remove(stone);
        }

        if (stones[stone.CounterId].Count == 0)
        {
            stones.Remove(stone.CounterId);
            Instance.StoneDestroyed.Invoke();
        }
    }

    public static int GetRemainedStonesCount()
    {
        return stones.Count;
    }
}
