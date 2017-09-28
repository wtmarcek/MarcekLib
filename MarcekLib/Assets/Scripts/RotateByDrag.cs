using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]

public class RotateByDrag : MonoBehaviour
{
    public float sensitivity = 1f;
    private Vector3 mouseReference;
    private Vector3 mouseOffset;
    private Vector3 rotation = Vector3.zero;
    private bool isRotating;


    void Update()
    {
        if (isRotating)
        {
            mouseOffset = (Input.mousePosition - mouseReference);

            rotation.x = (mouseOffset.y) * sensitivity;
            rotation.y = -(mouseOffset.x) * sensitivity;

            gameObject.transform.Rotate(rotation, Space.World);

            mouseReference = Input.mousePosition;
        }
    }

    void OnMouseDown()
    {
        isRotating = true;

        mouseReference = Input.mousePosition;
    }

    void OnMouseUp()
    {               
        isRotating = false;

        StartCoroutine(RotationSmooth());
    }

    IEnumerator RotationSmooth()
    {
        Vector3 myRotation = rotation;
        myRotation = Vector3.ClampMagnitude(myRotation, 10);

        for (int i = 30; i >= 0; i--)
        {
            myRotation *= .9f;
            transform.Rotate(myRotation, Space.World);

            yield return null;
        }
    }

}