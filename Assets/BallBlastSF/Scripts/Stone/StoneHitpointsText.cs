using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Destructable))]
public class StoneHitpointsText : MonoBehaviour
{
    [SerializeField] private Text hitpointsText;
    
    private Destructable destructable;

    private void Awake()
    {
        destructable = GetComponent<Destructable>();

        destructable.ChangeHitpoints.AddListener(OnChangeHitpoints);
    }

    private void OnDestroy()
    {
        destructable.ChangeHitpoints.RemoveListener(OnChangeHitpoints);
    }

    private void OnChangeHitpoints()
    {
        int hitpoints = destructable.GetHitpoints();

        if (hitpoints >= 1000)
        {
            hitpointsText.text = hitpoints / 1000 + "K";
        }
        else
        {
            hitpointsText.text = hitpoints.ToString();
        }
    }

}
