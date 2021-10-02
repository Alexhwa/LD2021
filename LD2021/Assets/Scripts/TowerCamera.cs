using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCamera : MonoBehaviour
{
    public float scrollMargin;
    public float minScrollSpeed;
    public float maxScrollSpeed;
    public Rect scrollBounds;
    
    private new Camera camera;

    private void Start() {
        camera = GetComponent<Camera>();
    }

    private void FixedUpdate() {
        float scrollSpeed = 0f;

        var mouseY = camera.ScreenToViewportPoint(Input.mousePosition).y;
        if (mouseY < scrollMargin) {
            scrollSpeed = -Mathf.Lerp(maxScrollSpeed, minScrollSpeed, Mathf.Pow(mouseY / scrollMargin, 2));
        }
        else if (mouseY > 1 - scrollMargin) {
            scrollSpeed = Mathf.Lerp(maxScrollSpeed, minScrollSpeed, Mathf.Pow((1 - mouseY) / scrollMargin, 2));
        }

        var position = transform.position;
        position.y += scrollSpeed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, scrollBounds.min.y, scrollBounds.max.y);
        transform.position = position; 
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(scrollBounds.center, scrollBounds.size);
    }
}
