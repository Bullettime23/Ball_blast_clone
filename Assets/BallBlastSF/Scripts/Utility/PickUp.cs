using UnityEngine;

public class PickUp : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Bag cart = collision.transform.root.GetComponent<Bag>();

        if (cart != null)
        {
            Destroy(gameObject);
        }
    }
}
