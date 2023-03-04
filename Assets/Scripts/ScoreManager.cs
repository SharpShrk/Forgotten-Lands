using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public int Score { get; private set; }

    public event UnityAction<int> ScoreChanged;

    private void Start()
    {
        Score = 0;
    }

    public void Restart()
    {
        Score = 0;
    }

    public void AddScore()
    {
        Score++;
        ScoreChanged?.Invoke(Score);
    }
}
