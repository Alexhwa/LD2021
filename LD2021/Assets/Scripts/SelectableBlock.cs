using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableBlock : MonoBehaviour
{
    public delegate void SelectableBlockDelegate(SelectableBlock block);
    public static SelectableBlockDelegate OnSelect;

    private bool isLoaded = false;
    private new Collider2D collider;
    private new Rigidbody2D rigidbody;

    private void Start() {
        collider = GetComponent<Collider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
        
        gameObject.layer = LayerMask.NameToLayer("Default");
        collider.isTrigger = true;
        rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void OnMouseDown() {
        if (isLoaded)
            return;

        OnSelect?.Invoke(this);
    }


    public void Load() {
        isLoaded = true;
        gameObject.layer = LayerMask.NameToLayer("Block");
        collider.isTrigger = false;
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        transform.SetParent(null);
    }
}
