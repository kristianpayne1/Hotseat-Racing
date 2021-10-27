using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    public Transform lookTarget;

    private bool lookAtTarget = false;
    private bool touchEnabled = false;

    // Start is called before the first frame update
    void Start()
    {
         StartCoroutine(intro());
    }

    IEnumerator intro()
    {
        yield return new WaitForSeconds(2f);
        touchEnabled = true;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(touchEnabled && !lookAtTarget)
        {
            if(Input.touchCount > 0)
            {
                lookAtTarget = true;
            }
        }
        if(lookAtTarget)
        {
            Quaternion q = Quaternion.LookRotation(lookTarget.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 300f * Time.deltaTime);
        }
    }
}
