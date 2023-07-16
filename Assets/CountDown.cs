using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField] private Image fillimage;
    [SerializeField] private Text TimerText;
    [SerializeField] private int duration;

    private int RemainingDuration;
    void Start()
    {
        StartTimer(duration);
    }

    private void StartTimer(int seconds)
    {
        RemainingDuration = seconds;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (RemainingDuration >= 0)
        {
            TimerText.text = (RemainingDuration / 60) + ":" + (RemainingDuration % 60);
            fillimage.fillAmount = Mathf.InverseLerp(0, duration, RemainingDuration);
            RemainingDuration--;
            yield return new WaitForSeconds(1);
        }
    }
}

