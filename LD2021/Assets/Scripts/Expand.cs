using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using DG.Tweening;
using Vector2 = UnityEngine.Vector2;

public class Expand : MonoBehaviour
{
    public float growSpeed;
    private float growDistance;
    private SpriteRenderer sprtRnd;
    
    // Start is called before the first frame update
    void Start()
    {
        sprtRnd = GetComponent<SpriteRenderer>();
        growDistance = sprtRnd.size.x;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Grow());
        }
    }

    private IEnumerator Grow()
    {
        Vector2 startSize = sprtRnd.size;
        Vector2 endSize = startSize;
        endSize.x += growDistance * 2;
        int counter = 0;
        float t = 0;
        while (counter < 10000 && t < 1)
        {
            yield return null;
            sprtRnd.size = Vector2.Lerp(startSize, endSize, t);
            t += Time.deltaTime * growSpeed;
            counter++;
        }
        print("lerp done");
    }
}
