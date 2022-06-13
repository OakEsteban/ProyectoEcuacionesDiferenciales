using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomColor : MonoBehaviour
{
    public int vel = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0,vel*Time.deltaTime,0);
    }
}
