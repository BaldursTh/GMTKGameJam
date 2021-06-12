using UnityEngine;

public class ShootGrapple : MonoBehaviour
{
    [SerializeField] Rigidbody2D grappleRB;
    [SerializeField] GameObject grapple;

    [SerializeField] float throwSpeed = 20;
    [SerializeField] float pullSpeed;

    private bool isThrowing = false;
    private bool isRetrieving = false;
    private bool isPulling = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            print(isThrowing);
            if(!isThrowing)
            {
                grapple.SetActive(true);
                
            }
            ThrowGrapple();
        }
        /*else
        {
            isThrowing = false;
            RetrieveGrapple();
        }*/
    }

    void HideCheck()
    {
        if (Vector3.Distance(grapple.transform.position, transform.position) < 1)
        {
            Freeze(grappleRB);
            grapple.SetActive(false);
        }
    }

    void PulledCheck()
    {

    }

    void ThrowGrapple()
    {
        isThrowing = true;
        grappleRB.AddForce(transform.up * throwSpeed);
    }

    void RetrieveGrapple()
    {
        isRetrieving = true;
        grappleRB.AddForce((transform.position - grapple.transform.position) * throwSpeed);
    }

    void PullPlayer()
    {

    }

    void Freeze(Rigidbody2D obj)
    {
        obj.velocity = Vector3.zero;
    }
}
