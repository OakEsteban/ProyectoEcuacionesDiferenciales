using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class estadisticas : MonoBehaviour
{
    public Text[] text;
    public InputField input;
    public timeControler time;
    public formulas formula;
    double TAlcanzar = 0;
    void Start()
    {

        

    }

    private void Awake()
    {
        text[0].text = "Objeto Inicial: " + formula.getObjetoT() + "°C";
        text[1].text = "Ambiente: " + formula.getAmbienteT() + "°C";

        temperaturaAlcanzar();

    }

    // Update is called once per frame
    float localTime = 0;
    void Update()
    {
        
        if(localTime > 1)
        {
            if (TAlcanzar != double.Parse(input.text)) temperaturaAlcanzar();

            text[0].text = "Objeto Inicial: " + formula.getObjetoT() + "°C"; //no hubo de otra :/
            text[1].text = "Ambiente: " + formula.getAmbienteT() + "°C";

            if (time.getTime() > 60)
            {
                text[2].text = "Transcurrido: " + string.Format("{0:0.##}", (time.getTime() / 60)) + "Min";
            }
            else
            {
                text[2].text = "Transcurrido: " + ((int) time.getTime()) + "Seg";
            }
            localTime = 0;
        }
        localTime += 1 * Time.deltaTime;
    }

    private void temperaturaAlcanzar()
    {
        TAlcanzar = double.Parse(input.text);
        
        if (TAlcanzar < formula.getAmbienteT()) text[4].text = "error";

        else 
        {
            if (TAlcanzar == formula.getAmbienteT()) TAlcanzar += 0.01;//para que no salga infinito

            double tiempoT = formula.getTiempo(TAlcanzar);
            text[4].text =  string.Format("{0:0.##}", tiempoT/60) + "Min"; 
        }
    }
}
