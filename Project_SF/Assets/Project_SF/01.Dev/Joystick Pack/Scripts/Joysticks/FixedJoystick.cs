using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FixedJoystick : Joystick
{
    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        playerCtrl.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
}