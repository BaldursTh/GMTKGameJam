using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;

   float posX;
       float  posY;
    Vector2 position;
    void Update()
    {
        position = player.transform.position;
        posX = position.x;
        posY = position.y;

        posX = Mathf.Round(posX / 0.0625f) * 0.0625f;
        posY = Mathf.Round(posY / 0.0625f) * 0.0625f;
        transform.position = new Vector3(posX, posY, -10); 
    }
}
