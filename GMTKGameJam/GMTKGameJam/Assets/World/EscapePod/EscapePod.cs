using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapePod : MonoBehaviour
{
    public float moveTime;
    public float moveSpeed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Camera.main.GetComponent<CameraScript>().Finish();
            StartCoroutine(Move());
            
        }
        IEnumerator Move()
        {
            for (float i = 0; i < moveTime; i += moveSpeed * Time.deltaTime)
            {
                
                transform.position = new Vector2(transform.position.x + i, transform.position.y);
                yield return null;
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);

        }
    }
}
