using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public bool droppable = true;
    HingeJoint2D dj=null;
    public bool picked = false;

    void OnMouseDown()
    {
        if (!droppable) {
            destruir();
        } else {
            agarrar();
        }
    }

    public void destruir() {
        IngredienteFisico ing = gameObject.GetComponent<IngredienteFisico>();
        ing.abrir(false);
        ing.inv.AgregarObjeto(ing.ing);
        Destroy(gameObject);
    }

    void OnMouseUp()
    {
        //Debug.Log("UP");
        if (droppable) {
            separar();
        }
    }

    private void Update() {
        if (Input.GetMouseButton(0)) {
            picked = true;
        }
        if(!droppable && !Input.GetMouseButton(0) && picked == true) {
            destruir();
        }
    }

    public void agarrar() {
        //Debug.Log("CLICK");
        if (!dj) {
            dj = gameObject.AddComponent(typeof(HingeJoint2D)) as HingeJoint2D;
            dj.connectedBody = GameObject.Find("Mouse").GetComponent<Rigidbody2D>();
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dj.autoConfigureConnectedAnchor = false;
            dj.anchor = transform.InverseTransformPoint(mousePos);
            dj.enableCollision = false;
            //Debug.Log("LISTO");
        } else {
            //Debug.Log("YA CONECTADO");
        }
    }

    public void agarrarManual() {
        dj = gameObject.AddComponent(typeof(HingeJoint2D)) as HingeJoint2D;
        dj.connectedBody = GameObject.Find("Mouse").GetComponent<Rigidbody2D>();
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dj.autoConfigureConnectedAnchor = false;
        dj.anchor = Vector3.zero;
        dj.connectedAnchor = Vector3.zero;
        dj.enableCollision = false;
    }

    public void separar() {
        //Debug.Log("SEPARAR");
        Destroy(dj);
    }
}
