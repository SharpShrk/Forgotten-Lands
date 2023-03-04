using TMPro;
using UnityEngine;

public class ScoreBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _points;
    [SerializeField] private ScoreManager _scoreManager;

    private void OnEnable()
    {
        _scoreManager.ScoreChanged += OnValueChanged;
        _points.text = $"SCORE: {_scoreManager.Score}";
    }

    private void OnDisable()
    {
        _scoreManager.ScoreChanged -= OnValueChanged;
    }

    private void OnValueChanged(int value)
    {
        _points.text = $"SCORE: {value}";
    }
}
