using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinBlock : MonoBehaviour
{
    public Transform block1;
    public Transform block2;
    LineRenderer lineRenderer;

    private void Start() {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update() {
        lineRenderer.SetPosition(0, block1.localPosition);
        lineRenderer.SetPosition(1, block2.localPosition);   
    }
}
