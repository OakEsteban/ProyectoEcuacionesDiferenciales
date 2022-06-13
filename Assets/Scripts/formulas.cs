using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class formulas : MonoBehaviour
{
    double ambienteT = 28;
    double objetoT = 200;
    double k = -0.005;
    int figura = 0; //0 = cubo, 1 = taza, 2 = cilindro
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public double getTemperature(double time)//obtener temperatura en un tiempo dado
    {
        double tem = ambienteT + ((objetoT - ambienteT) * Math.Pow(Math.E, k * time));
        return tem;
    }

    public double getK(double time,double TAmbiente, double Tobjeto, double c)//obtener constante k
    {
        double k = (Math.Log((Tobjeto-TAmbiente)/c)) / (time*60);
        return k;
    }

    public double getTiempo(double TAlcanzar)//obtener tiempo de una temperatura dada
    {
        //double t = Math.Log((TAlcanzar - TAmabiente) / (Tobjeto - TAmabiente)) / k;
        double t = Math.Log((TAlcanzar - ambienteT) / (objetoT - ambienteT)) / k;
        return t;
    }

    public double getTime(double temperature)//obtener el tiempo en una temperatura
    {

        return 0;
    }

    public double getAmbienteT()
    {
        return ambienteT;
    }

    public double getObjetoT()
    {
        return objetoT;
    }

    public int getFigura()
    {
        return figura;
    }

    public void setNew(double Ck, int obj)
    {
        k = Ck;
        figura = obj;
    }

    public void setTemperatura(double ambiente, double objeto)
    {
        ambienteT = ambiente;
        objetoT = objeto;
    }
}
