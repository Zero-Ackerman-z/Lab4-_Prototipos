using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManagerResult : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI timeText;

    void Start()
    {
        resultText.text = PlayerPrefs.GetString("Result", "Sin Resultado");
        float finalTime = PlayerPrefs.GetFloat("FinalTime", 0);
        int minutes = Mathf.FloorToInt(finalTime / 60);
        int seconds = Mathf.FloorToInt(finalTime % 60);
        timeText.text = $"Tiempo: {minutes:D2}:{seconds:D2}";
    }
}
