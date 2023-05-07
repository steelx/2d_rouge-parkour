using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// AgentWeapon is a base class for all weapons
public class AgentWeapon : MonoBehaviour
{
    protected float desiredAngle;
    protected WeaponRenderer weaponRenderer;

    protected virtual void Awake()
    {
        weaponRenderer = GetComponentInChildren<WeaponRenderer>();
    }

    public virtual void AimWeapon(Vector2 pointerPosition)
    {
        var aimDirection = (Vector3)pointerPosition - this.transform.position;
        this.desiredAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        this.RenderWeapon();
        this.transform.rotation = Quaternion.AngleAxis(this.desiredAngle, Vector3.forward);
    }

    private void RenderWeapon()
    {
        var isOnLeftSide = this.desiredAngle > 90 || this.desiredAngle < -90;
        weaponRenderer.FlipSprite(isOnLeftSide);
        weaponRenderer.RenderBehindAgent(isOnLeftSide);
    }
}
