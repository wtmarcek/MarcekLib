using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateByTime : MonoBehaviour
{
    [SerializeField] bool isDoRotation = false;
    Vector3 startLocalEuler = new Vector3(0, 0, 0);

    void Start()
    {
        startLocalEuler = transform.localEulerAngles;
    }

    private void Update()
    {
        if (isDoRotation)
        {
            DoRotation();
            print("executed");
        }
    }

    Vector3 direction = Vector3.zero;
    void DoRotation()
    {
        if (direction == Vector3.zero)
        {
            direction = Quaternion.Euler(startLocalEuler - transform.localEulerAngles) * transform.forward;            
        }
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(direction), 1f);

        if (Vector3.Angle(startLocalEuler, transform.forward) < 0.5f)
        {
            transform.localEulerAngles = startLocalEuler;
        }
            

    }



}
