using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorPower : MonoBehaviour
{
    private float powerOnTime;
    SurfaceEffector2D surfaceEffector2D;

    // Time in seconds the conveyor will run for at start
    public float initPower = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        surfaceEffector2D = GetComponent<SurfaceEffector2D>();
        powerOnTime = initPower;
    }

    // Update is called once per frame
    void Update()
    {
        if (powerOnTime >= 0)
        {
            powerOnTime -= Time.deltaTime;
        }
        else
        {
            powerOnTime = 0;
            surfaceEffector2D.speed = 0;
        }

        if (powerOnTime == 0)
        {

        }
        
    }
}
