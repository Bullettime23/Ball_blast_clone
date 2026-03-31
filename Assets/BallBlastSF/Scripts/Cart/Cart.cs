using UnityEngine;
using UnityEngine.Events;

public class Cart : MonoBehaviour
{
    [HideInInspector] public UnityEvent CollisionStone;

    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float vehicleWidth;

    private Vector3 movementTarget;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movementTarget = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Stone stone = collision.transform.root.GetComponent<Stone>();

        if (stone != null)
        {
            CollisionStone.Invoke();
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, movementTarget, movementSpeed * Time.deltaTime);
    }

    public void SetMovementTarget(Vector3 target)
    {
        movementTarget = ClampMovementTarget(target);
    }

    private Vector3 ClampMovementTarget(Vector3 target)
    {
        float leftBorder = LevelBoundary.Instance.LeftBorder + vehicleWidth * 0.5f;
        float rightBorder = LevelBoundary.Instance.RightBorder - vehicleWidth * 0.5f;

        Vector3 newTarget = target;
        newTarget.z = transform.position.z;
        newTarget.y = transform.position.y;

        if (newTarget.x < leftBorder) newTarget.x = leftBorder;
        if (newTarget.x > rightBorder) newTarget.x = rightBorder;

        return newTarget;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position - new Vector3(vehicleWidth * 0.5f, 0.5f, 0), transform.position + new Vector3(vehicleWidth * 0.5f, -0.5f, 0));
    }
#endif
}
