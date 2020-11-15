using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] int scoreIncrease = 5;

    public static GameManager Instance { get; private set; }

    public event System.Action<int> OnNextMission;
    public event System.Action<int> OnScoreChanged;
    public event System.Action OnStartAgain;

    private void Awake()
    {
        SingletonObject();
    }

    private void SingletonObject()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    [ContextMenu("Go Next Mission")]
    public void GoNextMission()
    {
        OnNextMission?.Invoke(1);
    }

    public void IncreaseScore()
    {
        score += scoreIncrease;
        OnScoreChanged?.Invoke(score);
    }

    public void StartAgain()
    {
        OnStartAgain?.Invoke();
    }
}
