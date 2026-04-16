using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public TextMeshProUGUI timerText;
    public float timer = 120;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = timer.ToString();
        if (timer > 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {

    }
    
}
