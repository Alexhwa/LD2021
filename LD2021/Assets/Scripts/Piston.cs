using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Piston : MonoBehaviour
{

    public float pushInterval;
    public float pushDistance;
    public float pushSpeed;
    public float pullSpeed;
    public float pullDelay;
    private float originalY;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Push(pushInterval));
        originalY = transform.localPosition.y;
    }

    private IEnumerator Push(float delay)
    {
        yield return new WaitForSeconds(delay);
        transform.DOLocalMoveY(pushDistance, pushSpeed).SetEase(Ease.OutElastic);
        StartCoroutine(Reset(pushSpeed + pullDelay));
    }

    private IEnumerator Reset(float delay)
    {
        yield return new WaitForSeconds(delay);
        transform.DOLocalMoveY(originalY, pullSpeed).SetEase(Ease.OutCubic);
        StartCoroutine(Push(pushInterval + pushSpeed));
    }
}
