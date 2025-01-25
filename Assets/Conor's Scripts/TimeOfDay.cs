using UnityEngine;
using TMPro;
public class TimeOfDay : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    public int StartHour = 9;
    public int StartMinute = 0;
    public int EndHour = 17;
    public int MinitueMod = 1;
    int currentHour;
    int currentMinute;

    float realTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHour = StartHour;
        currentMinute = StartMinute;
    }

    // Update is called once per frame
    void Update()
    {
        realTime += Time.deltaTime;
        currentMinute = (int)realTime/MinitueMod;

        string minitueString = (currentMinute < 10 ? "0" + currentMinute : "" + currentMinute);

        if(currentMinute >= 60)
        {
            realTime = 0;
            currentMinute = 0;
            currentHour += 1;
        }

        TimerText.text = currentHour + ":" + minitueString;
    }
}
