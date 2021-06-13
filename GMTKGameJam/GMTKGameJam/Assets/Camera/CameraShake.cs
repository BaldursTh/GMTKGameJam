using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    CameraScript cam;
    public void Shake(float duration, float magnitude)
    {
        StartCoroutine(Shak(duration, magnitude));
    }
    public IEnumerator Shak(float duration, float magnitude)
    {
        cam = GetComponent<CameraScript>();
        cam.isShaking = true;
        
        float elapsed = 0;

        while (elapsed < duration)
        {
            float x = Random.Range(1f, -1f) * magnitude;
            float y = Random.Range(1f, -1f) * magnitude;

            transform.position = transform.position + new Vector3(x, y, -10);
            elapsed += Time.deltaTime;
            yield return null;
        }
        cam.isShaking = false;
        
    }
}
