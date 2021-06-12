using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    float angle;
    public float dir;
    void Update()
    {
        angle = transform.GetMouseAngle();
        angle = Mathf.Round(angle / 30f) * 30f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        
    }
}
