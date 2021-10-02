using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPlacer : MonoBehaviour
{
    public new Camera camera;

    new Collider2D collider;
    SpriteRenderer ghostRenderer;
    SelectableBlock selectedBlock;

    private void Start() {
        ghostRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnEnable() {
        SelectableBlock.OnSelect += OnSelectBlock;
    }
    private void OnDisable() {
        SelectableBlock.OnSelect -= OnSelectBlock;
    }


    private void OnSelectBlock(SelectableBlock block) {
        selectedBlock = block;
        ghostRenderer.sprite = selectedBlock.GetComponent<SpriteRenderer>().sprite;
    }


    private void OnMouseDown() {
        if (selectedBlock != null) {
            selectedBlock.transform.position = ghostRenderer.transform.position;
            selectedBlock.isLoaded = true;
            selectedBlock = null;
            ghostRenderer.sprite = null;
        }
    }

    private void OnMouseOver() {
        ghostRenderer.transform.position = camera.ScreenToWorldPoint(Input.mousePosition);
        ghostRenderer.transform.position = new Vector3(Mathf.Round(ghostRenderer.transform.position.x), Mathf.Round(ghostRenderer.transform.position.y), 0);
    }

    private void OnMouseEnter() {
        ghostRenderer.enabled = true;
    }

    private void OnMouseExit() {
        ghostRenderer.enabled = false;
    }
}
