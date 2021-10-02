using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Inflate : MonoBehaviour
{
    public float growSpeed;
    private SpriteRenderer spriteRenderer;
    private bool hasInflated;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!hasInflated && Input.GetKeyDown(KeyCode.Space))
        {
            hasInflated = true;
            DOTween.To(() => spriteRenderer.size, size => spriteRenderer.size = size, new Vector2(2, 2), growSpeed)
                .SetEase(Ease.OutSine).SetTarget(spriteRenderer);
            transform.DOLocalMove(new Vector3(0.5f, 0.5f), growSpeed).SetEase(Ease.OutSine);
        }
    }

}
