
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour
{
    void OnDrawGizmosSelected()
    {
        Camera camera = GetComponent<Camera>();
        Vector3 p = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.farClipPlane));
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(p, 1.0F);
    }
}
