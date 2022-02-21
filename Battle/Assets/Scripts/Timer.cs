using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI _timer;

    float time = 0f;

    private void Start()
    {
        StartCoroutine(StartTimer());
    }

    public void StopTimer()
    {
        StopAllCoroutines();
    }

    private IEnumerator StartTimer()
    {
        while (true)
        {
            yield return null;
            time += Time.deltaTime;
            _timer.text = $"Timer: { Math.Round(time, 2)}";
        }
    }
}
