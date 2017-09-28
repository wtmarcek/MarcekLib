using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRotation : MonoBehaviour {

    Quaternion initialQuaternion;
    Vector3 initialEuler;

	// Use this for initialization
	void Start ()
    {
        initialQuaternion = transform.rotation;
        initialEuler = transform.eulerAngles;
	}

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            StartCoroutine(LerpResetRotation(1));
        }
    }

    IEnumerator LerpResetRotation(float speed)
    {
        while (Mathf.Abs(Vector3.SqrMagnitude(transform.eulerAngles) - Vector3.SqrMagnitude(initialEuler)) > 5f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, initialQuaternion, speed * Time.deltaTime);
            yield return null;
        }

        transform.rotation = initialQuaternion;
    }
}
