using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{
    public GameObject player;


    int isDead = 0;
    int showDeathScreen = 0;
    float posX;
    float  posY;
    Vector2 position;
    void Update()
    {
        if(isDead == 0)
        {
            position = player.transform.position;
            posX = position.x;
            posY = position.y;

            posX = Mathf.Round(posX / 0.0625f) * 0.0625f;
            posY = Mathf.Round(posY / 0.0625f) * 0.0625f;
            transform.position = new Vector3(posX, posY, -10);
        } else if(isDead == 1)
        {
            Death();
        }
        
    }

    public void Kill()
    {
        isDead = 1;
    }

    IEnumerator Death()
    {
        showDeathScreen++;
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("CameraPan", LoadSceneMode.Single);
    }


}
