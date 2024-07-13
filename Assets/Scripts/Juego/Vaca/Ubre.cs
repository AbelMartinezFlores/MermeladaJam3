using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ubre : MonoBehaviour
{
    public  Rigidbody2D gancho;
    public GameObject segmento;
    public int numSegmentos = 5;

    ParticleSystem dispensador;
    bool dispensando = false;

    void Start()
    {
        dispensador = transform.Find("Emisor").GetComponent<ParticleSystem>();
        GenerarUbre();
    }

    void GenerarUbre() {
        Rigidbody2D previoSegmento = gancho;
        for(int i = 0; i < numSegmentos; i++) {
            GameObject nuevoSegmento = Instantiate(segmento);

            nuevoSegmento.transform.parent = transform;
            nuevoSegmento.transform.position = gancho.transform.position;
            nuevoSegmento.transform.position += new Vector3(0.01f, 0, 0);

            SpringJoint2D conexion = nuevoSegmento.GetComponent<SpringJoint2D>();
            DistanceJoint2D distancia = nuevoSegmento.GetComponent<DistanceJoint2D>();

            if (previoSegmento) {
                conexion.connectedBody = previoSegmento;
                distancia.connectedBody = previoSegmento;
            }
            
            if(i == (numSegmentos - 1)) {
                float tamanyo = nuevoSegmento.GetComponent<SpriteRenderer>().bounds.size.y;
                float pivote = tamanyo / 4;
                dispensador.transform.position = nuevoSegmento.transform.position + new Vector3(0,pivote*-1,0);
                dispensador.transform.parent = nuevoSegmento.transform;
            } else {
                previoSegmento = nuevoSegmento.GetComponent<Rigidbody2D>();
            }
        }
    }

    public void leche() {
        if (!dispensando) {
            dispensador.Play();
            dispensando = true;
        }
    }

    public void noLeche() {
        dispensador.Stop();
        dispensando = false;
    }
}