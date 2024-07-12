using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ubre1 : MonoBehaviour
{
    public  Rigidbody2D gancho;
    public GameObject segmento;
    public int numSegmentos = 5;

    void Start()
    {
        GenerarUbre();
    }

    void GenerarUbre() {
        Rigidbody2D previoSegmento = null;
        for(int i = 0; i < numSegmentos; i++) {
            GameObject nuevoSegmento = Instantiate(segmento);

            nuevoSegmento.transform.parent = transform;
            nuevoSegmento.transform.position = transform.position;
            nuevoSegmento.transform.position += new Vector3(0.01f, 0, 0);

            SpringJoint2D conexion = nuevoSegmento.GetComponent<SpringJoint2D>();
            DistanceJoint2D distancia = nuevoSegmento.GetComponent<DistanceJoint2D>();

            if (previoSegmento) {
                conexion.connectedBody = previoSegmento;
                distancia.connectedBody = previoSegmento;
            }
            

            previoSegmento = nuevoSegmento.GetComponent<Rigidbody2D>();
        }
    }

    public void leche() {
        Debug.Log("LECHE");
    }

    public void noLeche() {

    }
}
