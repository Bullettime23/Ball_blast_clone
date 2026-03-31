using UnityEngine;
using UnityEngine.Events;

public class Bag : MonoBehaviour
{
    private int coinsAmount;
    [HideInInspector]
    
    public UnityEvent ChangeAmountCoins;

    public void AddCoins(int amount)
    {
        coinsAmount += amount;
        ChangeAmountCoins.Invoke();
    }

    public bool DrawCoins(int amount)
    {
        if (amount <= coinsAmount)
        {
            coinsAmount -= amount;
            ChangeAmountCoins.Invoke();

            return true;
        }

        ChangeAmountCoins.Invoke();
        return false;
    }

    public int GetCoinsAmount()
    {
        return coinsAmount;
    }
}
