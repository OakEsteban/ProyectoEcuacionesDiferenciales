using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeControler : MonoBehaviour
{

    void Start()
    {
        
    }

    double time = 0;
    double speed = 1;
    void Update()
    {
        time += 1 * Time.deltaTime * speed;
    }

    public double getTime()
    {
        return time;
    }

    public void setSpeed(double i)
    {
        speed = i;
    }

    public double getSpeed()
    {
        return speed;
    }

    public void resetTime()
    {
        time = 0;
    }
}
