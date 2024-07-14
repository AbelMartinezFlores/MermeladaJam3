using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    HingeJoint2D dj=null;

    void OnMouseDown()
    {
        //Debug.Log("CLICK");
        if(!dj){
            dj=gameObject.AddComponent(typeof(HingeJoint2D)) as HingeJoint2D;
            dj.connectedBody=GameObject.Find("Mouse").GetComponent<Rigidbody2D>();
            Vector2 mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dj.anchor=transform.InverseTransformPoint(mousePos);
            dj.enableCollision=false;
            //Debug.Log("LISTO");
        } else {
            //Debug.Log("YA CONECTADO");
        }
    }

    void OnMouseUp()
    {
        //Debug.Log("UP");
        separar();
    }

    public void separar() {
        //Debug.Log("SEPARAR");
        Destroy(dj);
    }
}
