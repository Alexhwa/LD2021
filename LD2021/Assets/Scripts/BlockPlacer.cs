using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPlacer : MonoBehaviour
{
    public new Camera camera;
    public SpriteRenderer ghostRenderer;
    public float gridSize;

    SelectableBlock selectedBlock;


    private void OnEnable() {
        SelectableBlock.OnSelect += OnSelectBlock;
    }
    private void OnDisable() {
        SelectableBlock.OnSelect -= OnSelectBlock;
    }


    private void OnSelectBlock(SelectableBlock block) {
        selectedBlock = block;
        ghostRenderer.sprite = selectedBlock.GetComponent<SpriteRenderer>().sprite;
        ghostRenderer.transform.rotation = Quaternion.identity;
    }


    private void OnMouseOver() {
        ghostRenderer.transform.position = camera.ScreenToWorldPoint(Input.mousePosition);
        ghostRenderer.transform.position = new Vector3(Mathf.Round(ghostRenderer.transform.position.x / gridSize) * gridSize, Mathf.Round(ghostRenderer.transform.position.y / gridSize) * gridSize, 0);
    
        if (Input.GetMouseButtonDown(1) && selectedBlock != null) {
            ghostRenderer.transform.Rotate(0, 0, 90);
        }

        if (Input.GetMouseButtonDown(0) && selectedBlock != null) {
            selectedBlock.transform.rotation = ghostRenderer.transform.rotation;
            selectedBlock.transform.position = ghostRenderer.transform.position;
            selectedBlock.Load();
            
            selectedBlock = null;
            ghostRenderer.sprite = null;
            ghostRenderer.transform.rotation = Quaternion.identity;
        }
    }

    private void OnMouseEnter() {
        ghostRenderer.enabled = true;
    }

    private void OnMouseExit() {
        ghostRenderer.enabled = false;
    }
}
