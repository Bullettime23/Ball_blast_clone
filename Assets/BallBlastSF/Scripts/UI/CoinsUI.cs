using UnityEngine;
using UnityEngine.UI;

public class CoinsUI : MonoBehaviour
{
    [SerializeField] private Bag bag;
    [SerializeField] private Text coinUI;

    private void Awake()
    {
        bag.ChangeAmountCoins.AddListener(OnAmountCoinsChange);    
    }

    private void OnDestroy()
    {
        bag.ChangeAmountCoins.RemoveListener(OnAmountCoinsChange);
    }

    private void OnAmountCoinsChange()
    {
        coinUI.text = bag.GetCoinsAmount().ToString();
    }
}
