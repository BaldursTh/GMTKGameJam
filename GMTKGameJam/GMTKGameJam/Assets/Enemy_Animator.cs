using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy_Animator : MonoBehaviour
{
    public AIPath aiPath;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            animator.SetInteger("Angle", 1);
        }
        if (aiPath.desiredVelocity.x <= -0.01f)
        {
            animator.SetInteger("Angle", 0);
        }
        if (aiPath.desiredVelocity.y >= 0.01f)
        {
            animator.SetInteger("Angle", 3);
        }
        if (aiPath.desiredVelocity.y <= -0.01f)
        {
            animator.SetInteger("Angle", 1);
        }
        print(aiPath.desiredVelocity.y + "     " + aiPath.desiredVelocity.x);
    }
}
