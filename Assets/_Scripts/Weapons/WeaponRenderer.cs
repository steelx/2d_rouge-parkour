using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRenderer : MonoBehaviour
{
    [field: SerializeField]
    protected const int agentSortingOrder = 0;
    // weapons sprite renderer
    protected SpriteRenderer weaponRenderer;

    void Awake()
    {
        weaponRenderer = GetComponent<SpriteRenderer>();
    }

    public void FlipSprite(bool flip)
    {
        var flipModifier = flip ? -1 : 1;
        transform.localScale = new Vector3(transform.localScale.x, Mathf.Abs(transform.localScale.y) * flipModifier, transform.localScale.z);
    }

    public void RenderBehindAgent(bool val)
    {
        if (val)
        {
            weaponRenderer.sortingOrder = agentSortingOrder - 1;
        }
        else
        {
            weaponRenderer.sortingOrder = agentSortingOrder + 1;
        }
    }
    
}
