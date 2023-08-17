using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{

    [SerializeField] private GameObject _player;
    [SerializeField] private Button _continueButton;    
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

    public void ContinueButton(){
        AdManager.Instance.ShowAd(this);
        _continueButton.interactable = false;
    }

    public void ContinueGame(){
        _scoreSystem.enabled = true;
        _asteroidSpawner.enabled = true; 
        _gameOverDisplay.gameObject.SetActive(false);
        _player.transform.position = Vector3.zero;
        _player.SetActive(true);
        _player.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

}
