using UnityEngine;
using UnityEngine.Events;

public class Coin : PickUp
{
    [SerializeField] private float gravity;

    private Vector3 velocity;
    private bool isReachBottom = false;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (isReachBottom)
        {
            velocity = Vector3.zero;
            return;
        }

        velocity.y -= gravity * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {

        Bag bag = collision.transform.root.GetComponent<Bag>();
        LevelEdge levelEdge = collision.GetComponent<LevelEdge>();

        if (bag != null)
        {
            bag.AddCoins(1);
            base.OnTriggerEnter2D(collision);
        }

        if (levelEdge != null && levelEdge.Type == EdgeType.Bottom)
        {
            isReachBottom = true;
            velocity.y = 0;
        }
    }
}
