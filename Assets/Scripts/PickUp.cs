using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    HingeJoint2D dj=null;

    void OnMouseDown()
    {
        if(!dj){
            dj=gameObject.AddComponent(typeof(HingeJoint2D)) as HingeJoint2D;
            dj.connectedBody=GameObject.Find("Mouse").GetComponent<Rigidbody2D>();
            Vector2 mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dj.anchor=transform.InverseTransformPoint(mousePos);
            dj.enableCollision=false;
        }
    }

    void OnMouseUp()
    {
        Destroy(dj);
    }
}
