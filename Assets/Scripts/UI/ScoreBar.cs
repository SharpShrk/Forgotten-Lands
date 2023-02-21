using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _points;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.ScoreChanged += OnValueChanged;
        _points.text = $"SCORE: {_player.Score}";
    }

    private void OnDisable()
    {
        _player.ScoreChanged -= OnValueChanged;
    }

    private void OnValueChanged(int value)
    {
        _points.text = $"SCORE: {value}";
    }
}
