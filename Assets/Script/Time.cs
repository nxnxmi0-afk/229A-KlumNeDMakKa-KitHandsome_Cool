using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField]private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
      
        if (timer >= 5)
        {
            timer -= Time.deltaTime;
            timeText.text = timer.ToString("00");
        }

        else if (timer < 5 && timer > 3)
        {
            timer -= Time.deltaTime;
            timeText.color = Color.yellow;
            timeText.text = timer.ToString("00");
        }
        else if (timer < 3 && timer > 1)
        {
            timer -= Time.deltaTime;
            timeText.color = Color.red;
            timeText.text = timer.ToString("00" + "!!!!!");
        }
        else if (timer < 1)
        {
            timer -= Time.deltaTime;
            timeText.color = Color.black;
            timeText.text = timer.ToString("Game Over");
            SceneManager.LoadScene("End_time");
        }
        else if (timer < 0)
        {
            timer = 0;
            SceneManager.LoadScene("End_time");
        }
    }

   
}
