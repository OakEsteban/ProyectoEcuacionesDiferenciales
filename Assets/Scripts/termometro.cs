using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class termometro : MonoBehaviour
{
    public timeControler time;
    public formulas formula;
    void Start()
    {
        
    }

    double temperature = 0;
    float localtime = 0;
    void Update()
    {
        if(localtime > 0.05)
        {
            temperature = formula.getTemperature(time.getTime());
            gameObject.GetComponent<Text>().text = string.Format("{0:0.##}", temperature) + "°C";
            localtime = 0;
        }
        localtime += Time.deltaTime;
    }
}
