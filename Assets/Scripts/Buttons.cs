using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Buttons : MonoBehaviour
{
    public GameObject submenu;
    public GameObject graph;
    public GameObject stadistics;
    public GameObject set;
    public GameObject plantilla;
    public GameObject stadB;
    public GameObject[] select;
    public timeControler time;
    public GameObject[] speedButton;
    public Text vel;
    public formulas formula;
    public Window_Graph windowsgraph;
    public graphController graphCont;
    public GameObject pause;
    public GameObject creditos;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool first = true;
    public void centralButtonAction(bool aux)
    {
        if (first) initial();
        else subMenu(aux);
    }

    public void initial()
    {
        setW(true);
    }

    public void subMenu(bool aux)
    {
        submenu.SetActive(aux);
    }

    public void graphW(bool aux)
    {
        graph.GetComponent<Animator>().SetBool("entrada", aux);
        subMenu(false);
    }

    public void stadisticsW(bool aux)
    {
        stadistics.SetActive(aux);
        subMenu(false);
    }

    public void setW(bool aux)
    {
        set.SetActive(aux);
        subMenu(false);
    }

    public void stadbW(bool aux)
    {
        stadB.SetActive(aux);
    }

    public void plantillaW(bool aux)
    {
        plantilla.SetActive(aux);

    }

    public void selectButtons(int aux)
    {
        Color selectC = new Color(128, 56, 79);
    }

    public void changeSpeedT(int i)
    {
        switch (i)
        {
            case 0: time.setSpeed(1); hideAllSpeedButtons(0); vel.text = "x 1seg"; break;
            case 1: time.setSpeed(5); hideAllSpeedButtons(1); vel.text = "x 5seg"; break;
            case 2: time.setSpeed(30); hideAllSpeedButtons(2); vel.text = "x 30seg"; break;
        }

        
    }
    public void hideAllSpeedButtons(int j)
    {
        for (int i = 0; i < 3; i++) speedButton[i].SetActive(false);
        speedButton[j].SetActive(true);
    }

    
    public void seleccionarObjeto(int i)
    {
        switch (i)
        {
            case 1: formula.setNew(-0.0007550921, 1); break; //Taza de cafe
            case 2: formula.setNew(-0.0003899999, 2); break; //Agua
            case 3: formula.setNew(-0.01, 0); break; //hierro
            case 4: set.SetActive(false); plantilla.SetActive(true); break; //personalizado
        }


    }

    public GameObject[] figuras3D;
    public GameObject addSimbol;
    public GameObject termometro;
    public InputField[] temperaturas;
    public void iniciarSimulacion()
    {
        for (int j = 0; j < 3; j++) figuras3D[j].SetActive(false);
        figuras3D[formula.getFigura()].SetActive(true);
        first = false;
        addSimbol.SetActive(false);
        termometro.SetActive(true);
        time.resetTime();
        windowsgraph.destroyChilds();
        formula.setTemperatura(double.Parse(temperaturas[0].text), double.Parse(temperaturas[1].text));
        graphCont.resetLastFrom();
        stadisticsW(false);
        stadB.SetActive(true);
        setW(false);
    }

    public InputField[] inputF;//objetoInicial, tiempofinal, objetoFinal, ambiente
    public void plantillaEnter()
    {
         
        double TobjetoI = (double.Parse(inputF[0].text));
        double tiempo = double.Parse(inputF[1].text);
        double Tobjetof = double.Parse(inputF[2].text);
        double Tambiente = double.Parse(inputF[3].text);
        double c = TobjetoI - Tambiente;
        double k = formula.getK(tiempo, Tambiente, Tobjetof, c);
        Debug.Log(k);
        formula.setNew(k, figuraActual);
        temperaturas[0].text = Tambiente+"";
        temperaturas[1].text = TobjetoI + "";
        setW(true);
        plantillaW(false);
    }

    int figuraActual = 0;//0 cubo, 1 taza, 2 cubo
    public GameObject[] figuras;
    public void cambiarFiguras(bool i)//true derecha, false izquierda
    {
        for (int j = 0; j < 3; j++) figuras[j].SetActive(false);
        if (i)
        {
            figuraActual++;
            if (figuraActual == 3) figuraActual = 0;
        }
        else
        {
            figuraActual--;
            if (figuraActual == -1) figuraActual = 2;
        }

        figuras[figuraActual].SetActive(true);
    }

    public void appearPause(bool aux)
    {
        pause.SetActive(aux);
    }

    public void appearCreditos(bool aux)
    {
        creditos.SetActive(aux);
    }

    public void closeApplication()
    {
        Application.Quit();
    }

}
