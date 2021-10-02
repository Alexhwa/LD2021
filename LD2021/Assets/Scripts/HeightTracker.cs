using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HeightTracker : MonoBehaviour
{
    float raycastHeight;
    float baseHeight;
    float actualHeight;

    private void Start() {
        baseHeight = transform.position.y;
        raycastHeight = -0.5f;
    }

    private void FixedUpdate() {
        bool heightMaintained = true;
        RaycastHit2D[] hits;

        // raycast at the raycast height to see if the tower decreased in height
        do {
            hits = Physics2D.RaycastAll(new Vector2(transform.position.x, baseHeight + raycastHeight), Vector2.right, 30f, LayerMask.GetMask("Block"));
            if (hits.Length == 0) {
                // tower height decreased
                raycastHeight--;
                heightMaintained = false;
            }
            else {
                actualHeight = hits.Max(hit => hit.collider.bounds.max.y);
            }
        } while (hits.Length == 0);

        if (heightMaintained) {
            // raycast above the raycast height to see if the tower increased in height
            do {
                hits = Physics2D.RaycastAll(new Vector2(transform.position.x, baseHeight + raycastHeight + 1), Vector2.right, 30f, LayerMask.GetMask("Block"));
                if (hits.Length > 0) {
                    raycastHeight++;
                    actualHeight = hits.Max(hit => hit.collider.bounds.max.y);
                }
            } while (hits.Length > 0);
        }

        // move the indicator
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, actualHeight, 0), 0.1f);
    }
}
