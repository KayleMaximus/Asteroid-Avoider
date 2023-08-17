using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverDisplay;
    [SerializeField] private AstroidSpawner _asteroidSpawner;

    public void EndGame()
    {
        _asteroidSpawner.enabled = false; //stop update method
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
