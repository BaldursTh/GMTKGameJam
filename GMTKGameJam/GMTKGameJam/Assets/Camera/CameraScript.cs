using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{
    GameObject player;
    GameObject pod;
    GameManager gm;


    bool isDead = false;
    int showDeathScreen = 0;
    float posX;
    float posY;
    public bool isShaking;
    Vector2 position;
    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>(); ;
        pod = GameObject.FindGameObjectWithTag("EscapePod");
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (!isDead)
        {
            position = player.transform.position;
            posX = position.x;
            posY = position.y;

            posX = Mathf.Round(posX / 0.0625f) * 0.0625f;
            posY = Mathf.Round(posY / 0.0625f) * 0.0625f;
            transform.position = new Vector3(posX, posY, -10);
        }
        else if (isDead)
        {
            StartCoroutine(Death());
        }

    }

    public void Kill()
    {
        
        isDead = true;
    }
    public void Finish()
    {
        gm.Finish();
        StartCoroutine(Fin());
    }

    IEnumerator Death()
    {
        
        showDeathScreen++;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
    bool isFin = true;
    IEnumerator Fin()
    {
        while(isFin)
        {
            position = pod.transform.position;
            posX = position.x;
            posY = position.y;

            posX = Mathf.Round(posX / 0.0625f) * 0.0625f;
            posY = Mathf.Round(posY / 0.0625f) * 0.0625f;
            transform.position = new Vector3(posX, posY, -10);
            yield return null;

        }
       
    }


}