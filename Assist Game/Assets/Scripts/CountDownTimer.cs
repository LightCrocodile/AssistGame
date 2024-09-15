using System.Collections;
using UnityEngine;
using TMPro;
using System;
using System.IO;

public class CountDownTimer : MonoBehaviour
{

    public event Action Levelend;
    public float StartTime;
    public float currentTime;
    public TMP_Text timertext;
    [SerializeField] public GameObject GameOver;

    private void OnEnable()
    {
        currentTime = StartTime;  // Set the current time to the start time
        StartCoroutine(HandleUpdate());  // Start the countdown coroutine
    }

    // Coroutine that handles the countdown logic by updating the timer every frame
    public IEnumerator HandleUpdate()
    {

        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;

            if (currentTime < 0)
            {
                currentTime = 0;
            }


            int min = Mathf.FloorToInt(currentTime / 60);
            int sec = Mathf.FloorToInt(currentTime % 60);


            timertext.text = string.Format("{0:00}:{1:00}", min, sec);


            yield return null;
        }


        GameOver.SetActive(true);


        yield return new WaitForSeconds(2f);
        Levelend?.Invoke();
    }


    // Method to set the starting time for the countdown programmatically
    public void SetStartTimer(float timer)
    {
        StartTime = timer;
    }

}
