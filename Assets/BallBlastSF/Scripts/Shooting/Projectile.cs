using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifetime;

    private int damage;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destructable destructable = collision.transform.root.GetComponent<Destructable>();
        if (destructable != null)
        {
            destructable.ApplyDamage(damage);
        }
        
        Destroy(gameObject);
    }

    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }
}
