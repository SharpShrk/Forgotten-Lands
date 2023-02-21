using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField] private float _startExperiencePointsForLvlUp;
    [SerializeField] private TMP_Text _levelUI;
    [SerializeField] private WeaponLevelUpPanel _weaponLevelUpPanel;
    [SerializeField] private ExpImprove _expImprove;

    private float _experiencePointsForLvlUp;
    private float _experiencePonts;
    private float _expMultiplierForLvlUp;
    private float _experienceBonus;
    private int _level;

    public float ExperiencePoints => _experiencePonts;
    public float ExperiencePointsForLvlUp => _experiencePointsForLvlUp;
    public int Level => _level;

    public event UnityAction<float, float> ExpChanged;
    public event UnityAction<int> LevelRaised;

    private void Awake()
    {
        _experiencePonts = 0;
        _experienceBonus = _expImprove.ExpBonus;
        _experiencePointsForLvlUp = _startExperiencePointsForLvlUp;
        _expMultiplierForLvlUp = 1.5f;
        _level = 0;
        _levelUI.text = _level.ToString(); 
    }

    public void Restart()
    {
        _level = 0;
        _levelUI.text = _level.ToString();
        _experiencePonts = 0;
        _experiencePointsForLvlUp = _startExperiencePointsForLvlUp;
        _experienceBonus = _expImprove.ExpBonus;
        ExpChanged?.Invoke(_experiencePonts, _experiencePointsForLvlUp);
    }

    private void LevelUp()
    {
        _level++;
        _experiencePointsForLvlUp *= _expMultiplierForLvlUp;
        _experiencePointsForLvlUp = (int)Math.Round(_experiencePointsForLvlUp);
        _levelUI.text = _level.ToString();
        _weaponLevelUpPanel.OpenPanel();
    }

    public void AddExperincePoint()
    {
        _experiencePonts += _experienceBonus;
        
        if (_experiencePonts >= _experiencePointsForLvlUp)
        {
            LevelUp();
            _experiencePonts = 0;
            LevelRaised?.Invoke(_level);
        }

        ExpChanged?.Invoke(_experiencePonts, _experiencePointsForLvlUp);       
    }
}
