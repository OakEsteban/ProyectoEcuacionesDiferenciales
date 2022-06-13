/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */
//base code of graphs by codemonkey, thanks codemonkey <3

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;


public class Window_Graph : MonoBehaviour {

    [SerializeField] private Sprite circleSprite;
    private RectTransform graphContainer;
    
    public double yMaximum = 100;
    public double xSize = 35;


    List<double> valueList;
    List<double> valueListM;

    public graphController graphC;
    private void Awake() {
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        valueList = new List<double>();
        valueListM = new List<double>();



    }

    public void Update()
    {

    }

    private GameObject CreateCircle(Vector2 anchoredPosition) {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(11, 11);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;
    }

    GameObject lastCircleGameObject = null;
    private void ShowGraphDinamic(List<double> valueList)
    {
        double graphHeight = graphContainer.sizeDelta.y;


        for (int i = 0; i < valueList.Count; i++)
        {
            double xPosition = xSize + i * xSize;
            double yPosition = (valueList[i] / yMaximum) * graphHeight;
            if(i == valueList.Count - 1)
            {
                GameObject circleGameObject = CreateCircle(new Vector2((float)xPosition, (float)yPosition));
                if (lastCircleGameObject != null)
                {
                    CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
                }
                lastCircleGameObject = circleGameObject;
            }
        }
    }
    private void ShowGraph(List<double> valueList) {
        double graphHeight = graphContainer.sizeDelta.y;


        //GameObject lastCircleGameObject = null;
        lastCircleGameObject = null;
        for (int i = 0; i < valueList.Count; i++) {
            double xPosition = xSize + i * xSize;
            double yPosition = (valueList[i] / yMaximum) * graphHeight;

            GameObject circleGameObject = CreateCircle(new Vector2((float)xPosition, (float)yPosition));
            if (lastCircleGameObject != null) {
                CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
            }
            lastCircleGameObject = circleGameObject;
        }
    }

    private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB) {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = new Color(1,1,1, .5f);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 3f);
        rectTransform.anchoredPosition = dotPositionA + dir * distance * .5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(dir));
    }


    public void showInScreen(double a)
    {
        
        if (valueList.Count == 50)
        {
            
            destroyChilds();
            graphC.refreshGraph();


        }
        valueList.Add(a);
        
        ShowGraphDinamic(valueList);
        
        

    }

    public void destroyChilds()
    {
        int aux = graphContainer.childCount;
        for (int i = 0; i < aux; i++)
        {
            Destroy(graphContainer.GetChild(i).gameObject);
        }
        valueList.Clear();
        lastCircleGameObject = null;
        

    }


}
