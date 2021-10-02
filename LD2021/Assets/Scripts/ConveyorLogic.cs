using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorLogic : MonoBehaviour
{
    public GameObject conveyorTerminal;
    private SurfaceEffector2D surfaceEffector2D;
    private SpriteRenderer tiling;
    SpriteRenderer tilingChild;
    public float conveySpeed;
    public float powerLeft;
    public bool stopped;
    public bool offsetChildRightOfSprite;
    // Start is called before the first frame update
    
    void Start()
    {
        surfaceEffector2D = gameObject.GetComponent<SurfaceEffector2D>();
        tiling = GetComponent<SpriteRenderer>();
        tilingChild = GetComponentInChildren<SpriteRenderer>();
        setConveySpeed(conveySpeed);
        if (offsetChildRightOfSprite) { offsetFromSprite(); }

    }

    // Update is called once per frame
    void Update()
    {
        if (!stopped)
        {
            powerLeft -= Time.deltaTime;

            if (powerLeft <= 0)
            {
                powerLeft = 0;
                setConveySpeed(0);
                stopped = true;
            }
        }
    }

    public void setConveySpeed(float newSpeed)
    {
        surfaceEffector2D.speed = newSpeed;
    }

    private void offsetFromSprite()
    {
        //repositions terminal to rightmost of conveyor
        conveyorTerminal.transform.localPosition = new Vector3(tiling.size.x / 2 + tilingChild.sprite.bounds.extents.x, 0, 0);

    }

}
