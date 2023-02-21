using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class ImprovedParameters : MonoBehaviour
{
    [SerializeField] protected PlayerInventory PlayerInventory;
    [SerializeField] protected Image Slider;
    [SerializeField] protected TMP_Text CostText;
    [SerializeField] protected TMP_Text LevelText;
    [SerializeField] protected Button Button;

    protected float Level = 0;
    protected float MaxLevel = 10;
    protected int Cost = 30;

    void Start()
    {
        Button.onClick.AddListener(Upgrade);

        Slider.fillAmount = Level / MaxLevel;
        CostText.text = Cost.ToString();
        LevelText.text = $"{Level} / {MaxLevel}";
    }

    protected void Upgrade()
    {
        if (Level >= MaxLevel)
        {            
            return;
        }

        if (PlayerInventory.MoneyShop < Cost)
        {
            return;
        }

        Level++;
        Slider.fillAmount = Level/MaxLevel;

        PlayerInventory.SubtractTotalMoney(Cost);

        Cost += Cost / 2;

        CostText.text = Cost.ToString();
        LevelText.text = $"{Level} / {MaxLevel}";

        UpgradeParameter();
    }

    protected virtual void UpgradeParameter() { }
}
