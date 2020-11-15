using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace KibibyteGamesPrototype1.Uis
{
    public class DisplayScore : MonoBehaviour
    {
        TextMeshProUGUI _scoreText;

        private void Awake()
        {
            _scoreText = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            GameManager.Instance.OnScoreChanged += HandleScoreChanged;
        }

        private void Start()
        {
            _scoreText.text = "Score: 0";
        }

        private void OnDisable()
        {
            GameManager.Instance.OnScoreChanged -= HandleScoreChanged;
        }

        private void HandleScoreChanged(int score)
        {
            _scoreText.text = "Score: " + score;
        }
    }
}

