using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private float _scoreMultipliers;

    private float _score;
    void Update(){
        _score += Time.deltaTime * _scoreMultipliers;
        _scoreText.text = Mathf.FloorToInt(_score).ToString();
    }

    public int getScore(){
        _scoreText.text = string.Empty;
        return Mathf.FloorToInt(_score);
    }
}
