using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gradiente : MonoBehaviour
{
    public Gradient mainGradient;
    Renderer pRender;
    public Color color;
    public float change = 0;
    public timeControler time;
    public formulas formula;
    void Start()
    {
        pRender = gameObject.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        changeColor(time.getTime());
    }

    public void changeColor(double time)
    {
        double t = formula.getTemperature(time);

        if (formula.getObjetoT() > 200) t = (t + 20) / (formula.getObjetoT() + 20);
        else t = (t + 20) / 200;

        pRender.material.color = mainGradient.Evaluate((float)(t));
    }
}
