using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AgentRenderer : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    /*
     * FaceDirection called from AgentInputController's OnPointerPositionChange event
     * */
    public void FaceDirection(Vector2 pointerPosition)
    {
        var direction = (Vector3)pointerPosition - transform.position;
        var result = Vector3.Cross(Vector2.up, direction);
        spriteRenderer.flipX = result.z > 0;
    }
}
