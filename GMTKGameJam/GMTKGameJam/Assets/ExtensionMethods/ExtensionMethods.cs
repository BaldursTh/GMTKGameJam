using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    public static Vector2 GetMouseDirection(this Transform transform)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector2 direction = (mousePos - transform.position).normalized;
        return direction;
    }
    public static float GetMouseAngle(this Transform transform)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector2 direction = (mousePos - transform.position).normalized;
        float mouseAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return mouseAngle;
    }
    public static Vector2 GetDirection(this Transform transform, Vector2 otherPoisition)
    {
        Vector2 direction = (otherPoisition - (new Vector2(transform.position.x, transform.position.y))).normalized;
            return direction;
    }

}
