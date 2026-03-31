using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] public int projectileAmount;
    [SerializeField] private float projectileInterval;
    [SerializeField] public float fireRate;
    [SerializeField] public int projectileDamage;

    private float timer;

    public int ProjectileDamage => projectileDamage;
    public int ProjectileAmount => projectileAmount;
    public float FireRate => fireRate;

    void Update()
    {
        timer += Time.deltaTime;
    }

    private void CreateProjectile()
    {

        float summProjectileInterval = projectileInterval;
        float centerOfProjectiles = (projectileAmount - 1) / 2;
        for (int i = 0; i < projectileAmount; i++)
        {

            float projectileX = shootPoint.position.x - projectileInterval * (centerOfProjectiles - i);

            Vector3 calculeatedShootPosition = new Vector3(projectileX, shootPoint.position.y, shootPoint.position.z);
            Projectile projectile = Instantiate(projectilePrefab, calculeatedShootPosition, transform.rotation);
            projectile.SetDamage(projectileDamage);
        }
    }

    public void Fire()
    {
        if (timer >= fireRate)
        {
            CreateProjectile();

            timer = 0;
        }
    }
}
