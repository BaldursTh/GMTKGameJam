using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{
    public GameObject player;

    [Range(1, 50)] public float panSpeed = 10;

    int isDead = 0;
    int showDeathScreen = 0;

    float posX;
    float posY;
    Vector2 position;

    private void Start()
    {

    }

    void Update()
    {
        if (isDead == 0)
        {
            position = player.transform.position;
            posX = position.x;
            posY = position.y;

            posX = Mathf.Round(posX / 0.0625f) * 0.0625f;
            posY = Mathf.Round(posY / 0.0625f) * 0.0625f;
            transform.position = new Vector3(posX, posY, -10);
        }
        else
        {
            if (isDead == 1)
            {
                StartCoroutine(ZoomOut());
            }

            if (showDeathScreen == 1)
            {
                showDeathScreen++;
                print("Showing Death Scene");
                SceneManager.LoadScene("CameraPan", LoadSceneMode.Single);
            }

        }
    }

    public void SetDead()
    {
        isDead = 1;
    }

    IEnumerator ZoomOut()
    {
        isDead++;
        yield return new WaitForSeconds(3);
        showDeathScreen = 1;
    }
}
