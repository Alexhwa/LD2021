using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableBlock : MonoBehaviour
{
    public delegate void SelectableBlockDelegate(SelectableBlock block);
    public static SelectableBlockDelegate OnSelect;

    public bool isLoaded = false;
    private new Collider2D collider;

    private void Start() {
        collider = GetComponent<Collider2D>();
    }

    private void OnMouseDown() {
        if (isLoaded)
            return;

        OnSelect?.Invoke(this);
    }
}
