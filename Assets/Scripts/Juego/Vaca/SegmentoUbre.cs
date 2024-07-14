using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentoUbre : MonoBehaviour
{
    public float distanciaParaOrdenyar = .5f;
    public float distanciaParaSoltar = .7f;

    [System.NonSerialized]
    public GameObject conectadoArriba, conectadoAbajo;
    [System.NonSerialized]
    public Ubre origen;
    float distanciaAnterior;

    private float pivote = 0;

    LineRenderer linea;

    private bool click = false;

    void Start()
    {
        linea = GetComponent<LineRenderer>();
        origen = GetComponentInParent<Ubre>();
        SpringJoint2D joint = GetComponent<SpringJoint2D>();
        DistanceJoint2D distancia = GetComponent<DistanceJoint2D>();
        SegmentoUbre segmentoSuperior = null;

        float tamanyo = GetComponent<SpriteRenderer>().bounds.size.y;
        pivote = tamanyo / 3.5f;

        if (joint != null) {
            if (joint.connectedBody != null) {
                conectadoArriba = joint.connectedBody.gameObject;
                segmentoSuperior = conectadoArriba.GetComponent<SegmentoUbre>();
            }

            joint.anchor = new Vector2(0, pivote);
            distancia.anchor = new Vector2(0, pivote);

            if (segmentoSuperior != null) {
                segmentoSuperior.conectadoAbajo = gameObject;

                joint.connectedAnchor = new Vector2(0, -pivote);
                distancia.connectedAnchor = new Vector2(0, -pivote);
            } else {
                joint.connectedAnchor = transform.parent.position;
                distancia.connectedAnchor = transform.parent.position;
            }
        }
    }

    private void OnMouseDown() {
        click = true;
    }
    private void OnMouseUp() {
        click = false;
        origen.noLeche();
    }

    private void Update() {
        if (conectadoAbajo) {
            linea.SetPosition(0, transform.TransformPoint(0,-pivote,-5));
            linea.SetPosition(1, conectadoAbajo.transform.TransformPoint(0,pivote,-5));
        } else {
            if (conectadoArriba) 
                conectadoArriba.GetComponent<LineRenderer>().SetPosition(1,transform.TransformPoint(0, 0.04f, -5));
            SpringJoint2D joint = GetComponent<SpringJoint2D>();
            DistanceJoint2D distancia = GetComponent<DistanceJoint2D>();

            joint.anchor = new Vector2(0, 0.1f);
            joint.connectedAnchor = new Vector2(0, -1);
            distancia.anchor = new Vector2(0, 0.1f);
            distancia.connectedAnchor = new Vector2(0, -1);
        }
        
        if (click) {
            if(conectadoArriba != null) {
                float distanciaConAnterior = (conectadoArriba.transform.position - transform.position).magnitude;
                float diferencia = distanciaConAnterior - distanciaAnterior;
                if (distanciaConAnterior >= distanciaParaSoltar) {
                    GetComponent<PickUp>().separar();
                } else if( diferencia >= distanciaParaOrdenyar/10 && diferencia < distanciaParaOrdenyar/5 && distanciaConAnterior >= distanciaParaOrdenyar) {
                    origen.leche();
                } else {
                    origen.noLeche();
                }
                distanciaAnterior = distanciaConAnterior;
            }
        }
    }
}
