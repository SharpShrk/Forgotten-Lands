public class ExpBar : Bar
{
    private PlayerLevel _playerLevel;

    private void Start()
    {
        _playerLevel = Player.GetComponent<PlayerLevel>();
        Slider.fillAmount = 0;
        Points.text = $"{_playerLevel.ExperiencePoints} / {_playerLevel.ExperiencePointsForLvlUp}";
    }

    private void OnEnable()
    {       
        _playerLevel.ExpChanged += OnValueChanged;       
    }

    private void OnDisable()
    {
        _playerLevel.ExpChanged -= OnValueChanged;
    }
}
