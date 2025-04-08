using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Timer timer;

    private void OnEnable()
    {
        GameEvents.GameOver += OnGameOver;
        GameEvents.Victory += OnVictory;
    }

    private void OnDisable()
    {
        GameEvents.GameOver -= OnGameOver;
        GameEvents.Victory -= OnVictory;
    }

    private void OnGameOver()
    {
        PlayerPrefs.SetFloat("FinalTime", timer.GetFinalTime());
        PlayerPrefs.SetString("Result", "Perdiste");
        SceneManager.LoadScene("ResultadoScene");
    }

    private void OnVictory()
    {
        PlayerPrefs.SetFloat("FinalTime", timer.GetFinalTime());
        PlayerPrefs.SetString("Result", "Ganaste");
        SceneManager.LoadScene("ResultadoScene");
    }
}
