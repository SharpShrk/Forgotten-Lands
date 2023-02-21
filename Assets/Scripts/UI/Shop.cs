using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _shop;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    public event UnityAction GameRestarted;

    private void OnEnable()
    {
        DeactivateShop();

        _restartButton.onClick.AddListener(OnButtonRestartClick);
        _exitButton.onClick.AddListener(OnButtonExitClick);
        _player.GameOver += SetActiveShop;
    }

    private void OnDisable()
    {
        _player.GameOver -= SetActiveShop;
    }

    private void SetActiveShop()
    {
        _shop.SetActive(true);
        Time.timeScale = 0;
    }

    private void DeactivateShop()
    {
        _shop.SetActive(false);
        Time.timeScale = 1;      
    }

    private void OnButtonRestartClick()
    {
        DeactivateShop();
        GameRestarted?.Invoke();
    }

    private void OnButtonExitClick()
    {
        Application.Quit();
    }
}
