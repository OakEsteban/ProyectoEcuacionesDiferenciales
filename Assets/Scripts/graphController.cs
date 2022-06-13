using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class graphController : MonoBehaviour
{
    public Window_Graph window;
    public timeControler time;
    public formulas formula;
    public GameObject timeText;
    public Text medidaT;
    int graph = 1;
    int lastFrom = 0;

    void Start()
    {
        changeTimeText(0, 1);
    }

    float localTime = 0;
    void Update()
    {
        if (localTime > (60 / time.getSpeed()) || localTime == 0)
        {

            
            window.showInScreen(formula.getTemperature(time.getTime()));
            localTime = 0;
            
        }
        localTime += 1 * Time.deltaTime;
    }

    public void changeTimeText(int from, int intervalo)
    {
        
        int space = ((50 * intervalo) + from + "").Length-1;

        for(int i = 0; i < 50; i++)
        {
            if (i % space != 0) timeText.transform.GetChild(i).GetComponent<Text>().text = "";
            else timeText.transform.GetChild(i).GetComponent<Text>().text = (i * intervalo) + from + "";
        }
        lastFrom = (49 * intervalo) + from + 1;
    }

    public void refreshGraph()
    {
        switch (graph)
        {
            case 1: changeTimeText(lastFrom, 1); break;
        }
    }

    public void resetLastFrom()
    {
        lastFrom = 0;
        localTime = 0;
    }


}
