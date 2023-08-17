using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{

    [SerializeField] private TMP_Text _gameOvertext;
    [SerializeField] private ScoreSystem _scoreSystem;
    [SerializeField] private GameObject _gameOverDisplay;
    [SerializeField] private AstroidSpawner _asteroidSpawner;

    public void EndGame()
    {
        _asteroidSpawner.enabled = false; //stop update method
        _scoreSystem.enabled = false; //stop update method
        int finalScore = _scoreSystem.getScore();
        _gameOvertext.text = $"Your Score:{finalScore}";
        _gameOverDisplay.gameObject.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);

    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);

    }

}
