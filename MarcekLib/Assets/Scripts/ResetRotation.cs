using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRotation : MonoBehaviour {

    public float time = 1;

    Quaternion initialQuaternion;
    Vector3 initialEuler;

    Coroutine myCoroutine = null;

	void Start ()
    {
        myCoroutine = StartCoroutine(LerpResetRotation(time));
        initialQuaternion = transform.rotation;
        initialEuler = transform.eulerAngles;
	}

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
            myCoroutine = StartCoroutine(LerpResetRotation(time));
    }

    void OnMouseDown()
    {
        if(myCoroutine != null)
            StopCoroutine(myCoroutine);
    }

    public void ResetObjectRotation()
    {
        myCoroutine = StartCoroutine(LerpResetRotation(time));
    }

    IEnumerator LerpResetRotation(float t)
    {
        while (Mathf.Abs(Vector3.SqrMagnitude(transform.eulerAngles) - Vector3.SqrMagnitude(initialEuler)) > 10f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, initialQuaternion, 1/t * Time.deltaTime);
            yield return null;
        }
        transform.rotation = initialQuaternion;
    }
}
