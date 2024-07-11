using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ubre : MonoBehaviour
{
    public  Rigidbody2D gancho;
    public GameObject segmento;
    public int numSegmentos = 5;

    void Start()
    {
        GenerarUbre();
    }

    void GenerarUbre() {
        Rigidbody2D previoSegmento = gancho;
        for(int i = 0; i < numSegmentos; i++) {
            GameObject nuevoSegmento = Instantiate(segmento);

            nuevoSegmento.transform.parent = transform;
            nuevoSegmento.transform.position = transform.position;

            HingeJoint2D conexion = nuevoSegmento.GetComponent<HingeJoint2D>();
            conexion.connectedBody = previoSegmento;

            previoSegmento = nuevoSegmento.GetComponent<Rigidbody2D>();
        }
    }
}
