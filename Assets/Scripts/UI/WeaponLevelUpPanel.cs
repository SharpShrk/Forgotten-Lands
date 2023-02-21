using UnityEngine;

public class WeaponLevelUpPanel : MonoBehaviour
{
    [SerializeField] private GameObject weaponCardPanel;
    [SerializeField] private CardUI _card1;
    [SerializeField] private CardUI _card2;
    [SerializeField] private CardWiev _cardWiev;

    private void Start()
    {
        OpenPanel();
    }

    private void OnEnable()
    {
        _card1.WeaponLevelButtonClicked += ClosePanel;
        _card2.WeaponLevelButtonClicked += ClosePanel;
    }

    private void OnDisable()
    {
        _card1.WeaponLevelButtonClicked -= ClosePanel;
        _card2.WeaponLevelButtonClicked -= ClosePanel;
    }

    public void OpenPanel()
    {
        weaponCardPanel.SetActive(true);
        _cardWiev.RandomCardsSelection();
        Time.timeScale = 0;
    }

    private void ClosePanel()
    {
        weaponCardPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
