using UnityEngine;

[RequireComponent(typeof(StoneMovement))]
public class Stone : Destructable
{
    static private decimal stonesCounter = 0m;
    private StoneMovement movement;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private static string[] myPalette = { "#FA7755", "#FAB155", "#FA9455", "#FA5A55", "#FAC655", "#FAB185", "#FAB185" };
    private static Color[] colorPalette;


    public enum Size
    {
        Small,
        Normal,
        Big,
        Huge,
    }

    public int CounterId;

    [SerializeField] private Size size;
    [SerializeField] private float spawnUpForce;

    private void Awake()
    {
        stonesCounter++;
        StoneCounter.RegisterStoneInCollection(this);
        movement = GetComponent<StoneMovement>();

        Die.AddListener(OnStoneDestroyByProjectile);

        SetSize(size);

        if (Stone.colorPalette != null) return;

        colorPalette = new Color[myPalette.Length];
        for (int i = 0; i < myPalette.Length; i++){
            ColorUtility.TryParseHtmlString(Stone.myPalette[i], out Color newColor);
            colorPalette[i] = newColor;
        }
    }

    private void OnDestroy()
    {
        Die.RemoveListener(OnStoneDestroyByProjectile);
    }

    private void OnStoneDestroyByProjectile()
    {
        if (size != Size.Small)
        {
            SpawnStones();
        }

        CoinSpawner.Instance.OnStoneDestroyed(transform.position);
        StoneCounter.PopStoneFromColletcion(this);
        Destroy(gameObject);
    }

    private void SpawnStones()
    {
        for (int i = 0; i < 2; i++)
        {
            Vector3 stonePositon = new Vector3(transform.position.x, transform.position.y, transform.position.z + (float)(stonesCounter / 1000));
            Stone stone = Instantiate(this, stonePositon, Quaternion.identity);
            stone.SetSize(size - 1);
            stone.maxHitPoints = Mathf.Clamp(maxHitPoints / 2, 1, maxHitPoints);
            stone.movement.AddVerticalVelocity(spawnUpForce);
            stone.movement.SetHorizontalDirection(((i % 2 * 2) - 1));
            stone.SetColor(spriteRenderer.color);

            stone.CounterId = CounterId;
        }
    }

    public void SetRandomColor()
    {
        Color randomColor = colorPalette[Random.Range(0, colorPalette.Length)];
        spriteRenderer.color = randomColor;
    }

    private void SetColor(Color color)
    {
        spriteRenderer.color = color;
    }

    private Vector3 GetVectorFromSize(Size size)
    {
        if (size == Size.Huge) return new Vector3(1, 1, 1);
        if (size == Size.Big) return new Vector3(0.75f, 0.75f, 0.75f);
        if (size == Size.Normal) return new Vector3(0.6f, 0.6f, 0.6f);
        if (size == Size.Small) return new Vector3(0.4f, 0.4f, 0.4f);

        return Vector3.one;
    }


    public void SetSize(Size size)
    {
        if (size < 0) return;
        transform.localScale = GetVectorFromSize(size);
        this.size = size;
    }
}
