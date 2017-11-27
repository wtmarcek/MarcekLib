using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalToWorld : MonoBehaviour {

    BoxCollider boxCollider;

    public Vector3 center;
    public Vector3 parameters;

	void Start ()
    {
        boxCollider = GetComponent<BoxCollider>();
    }
	
	void Update ()
    {
        center = boxCollider.center;
        
        parameters = transform.TransformPoint(boxCollider.size.x, boxCollider.size.y, boxCollider.size.z);
        print("LocalToWorld " + ToWorldCoord());
        print("Center " + center);

        Matrix4x4 cubeTransform = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);

        //transform.rotation *= cubeTransform.rotation;

    }

    private Vector3 ToWorldCoord()
    {
        return new Vector3(center.x + boxCollider.size.x, center.y + boxCollider.size.y, center.z + boxCollider.size.z);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.matrix *= Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);

        Gizmos.DrawCube(center, ToWorldCoord());
    }
}
