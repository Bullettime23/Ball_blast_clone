using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] Turret turret;
    [SerializeField] Bag bag;
    [SerializeField] Text[] costLabels;

    [SerializeField] private float fireRateBoost = 0.5f;
    [SerializeField] private int projectilesAmountBoost = 2;
    [SerializeField] private int damageBoost = 2;
    [SerializeField] private int purchaiseCost = 2;

    public GameObject lastActiveScreen;

    public void setLastActiveScreen (GameObject screen)
    {
        this.lastActiveScreen = screen;
    }

    /*
     Карточка должна показывать белый текст, когда хватает денег
      Серый - если нет. (Или полностью прокачано. Третий уровень - максимальный)
      
        При нажатии на карточку, когда есть деньги, увеличиается характеристика, снимаются деньги
        Если денег недостаточно, показывает надпись "Недостаточно денег"
     */

    private void Awake()
    {
        foreach (Text label in costLabels)
        {
            label.text = purchaiseCost.ToString();
        } 
    }


    public void IncreaseFireRate()
    {
        if (bag.DrawCoins(purchaiseCost))
        {
            turret.fireRate *= 1f - fireRateBoost;
        }
    }

    public void IncreaseProjectileAmount()
    {
        if (bag.DrawCoins(purchaiseCost))
        {
            turret.projectileAmount += projectilesAmountBoost;
        }
    }

    public void IncreaseDamage()
    {
        if (bag.DrawCoins(purchaiseCost))
        {
            turret.projectileDamage += damageBoost;
        }
    }

    public void OnExit()
    {
        gameObject.SetActive(false);
        lastActiveScreen.SetActive(true);
    }
}
