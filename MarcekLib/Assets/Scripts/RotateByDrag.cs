using UnityEngine;
using System.Collections;


public class RotateByDrag : MonoBehaviour
{
    public float sensitivity = 1f;

    [Range(0,30)]
    public float smoothSensitivity = 10;

    //Mobile
    private Vector2 touchReference;
    private Vector2 touchOffset;    
    //Mouse API
    private Vector3 mouseReference;
    private Vector3 mouseOffset;

    private Vector3 rotation = Vector3.zero;
    private bool isRotating;

    private Touch touch = new Touch();

    void Update()
    {        
        if (isRotating)
        {
            touchOffset = (touch.position - touchReference);
            mouseOffset = (Input.mousePosition - mouseReference);

            rotation.x = (mouseOffset.y) * sensitivity;
            rotation.y = -(mouseOffset.x) * sensitivity;

            gameObject.transform.Rotate(rotation, Space.World);

            touchReference = touch.position;
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
        myRotation = Vector3.ClampMagnitude(myRotation, smoothSensitivity);

        for (int i = 30; i >= 0; i--)
        {
            myRotation *= .9f;
            transform.Rotate(myRotation, Space.World);

            yield return null;
        }
    }

}