using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin coinPrefab;
    [SerializeField][Range(0f, 1f)] private float spawnChanceIncreasePerStoneDestroyed;
    [SerializeField][Range(0f, 1f)] private float initialSpawnChance;

    public static CoinSpawner Instance;
    public static float spawnChanse;

    private void Awake()
    {
        spawnChanse = initialSpawnChance;

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void OnStoneDestroyed(Vector3 stonePosition)
    {
        spawnChanse += spawnChanceIncreasePerStoneDestroyed * Random.Range(0.1f, 2f);

        if (spawnChanse >= 1f)
        {
            SpawnCoin(stonePosition);
            spawnChanse = initialSpawnChance;
        }
    }

    private void SpawnCoin(Vector3 stonePosition)
    {
        Instantiate(coinPrefab, stonePosition, Quaternion.identity);
    }
}
