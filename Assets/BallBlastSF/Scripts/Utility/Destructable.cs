using UnityEngine;
using UnityEngine.Events;

public class Destructable : MonoBehaviour
{
    public int maxHitPoints;

    [HideInInspector] public UnityEvent Die;
    [HideInInspector] public UnityEvent ChangeHitpoints;
    [SerializeField] private GameObject damageSound;
    
    private int hitPoints;
    private GameObject damageImpactEffect;

    private bool isDie = false;

    private void Start()
    {
        hitPoints = maxHitPoints;
        ChangeHitpoints.Invoke();
    }
    public void ApplyDamage(int damage)
    {
        hitPoints -= damage;
        ChangeHitpoints.Invoke();

        PlayPlayerHurtSound();

        if(hitPoints <= 0)
        {
            Kill();
        }
    }

    public void ApplyHealing(int healing)
    {
        if (healing + hitPoints > maxHitPoints) {
            hitPoints = maxHitPoints;
        } else
        {
            hitPoints += healing;
        }
            ChangeHitpoints.Invoke();

        if (hitPoints <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        if (isDie == true) return;
        PlayPlayerHurtSound();
        isDie = true;

        hitPoints = 0;
        Die.Invoke();
    }

    public int GetHitpoints()
    {
        return hitPoints;
    }

    public int GetMaxHitpoints()
    {
        return maxHitPoints;
    }

    private void PlayPlayerHurtSound()
    {
        if (damageSound != null && damageImpactEffect == null)
        {
            damageImpactEffect = Instantiate(damageSound);
        }
    }
}
