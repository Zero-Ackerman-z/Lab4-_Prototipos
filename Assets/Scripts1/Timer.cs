using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    private float timeElapsed = 0f;
    public TextMeshProUGUI timeText;

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        timeText.text = FormatTime(timeElapsed);
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return $"{minutes:D2}:{seconds:D2}";
    }

    public float GetFinalTime() => timeElapsed;
}
