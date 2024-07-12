using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentoUbre1 : MonoBehaviour
{
    public GameObject conectadoArriba, conectadoAbajo;
    public Ubre1 origen;

    void Start()
    {
        SpringJoint2D joint = GetComponent<SpringJoint2D>();
        SegmentoUbre1 segmentoSuperior = null;

        if (joint.connectedBody != null) {
            conectadoArriba = joint.connectedBody.gameObject;
            segmentoSuperior = conectadoArriba.GetComponent<SegmentoUbre1>();
        }

        float tamanyo = GetComponent<SpriteRenderer>().bounds.size.y;
        float pivote = tamanyo/4;

        joint.anchor = new Vector2(0, pivote);

        if (segmentoSuperior != null) {
            segmentoSuperior.conectadoAbajo = gameObject;

            joint.connectedAnchor = new Vector2(0, -pivote);
        } else {
            joint.connectedAnchor = transform.parent.position;
            GetComponent<DistanceJoint2D>().connectedAnchor = transform.parent.position;
        }
    }

    private void Update() {
        if (Input.GetMouseButton(0)) {
            if(conectadoArriba != null) {
                float distanciaConAnterior = (conectadoArriba.transform.position - transform.position).magnitude;
                if (distanciaConAnterior > .5f) {
                    gameObject.GetComponentInParent<Ubre1>().leche();
                } else {
                    gameObject.GetComponentInParent<Ubre1>().noLeche();
                }
            }
        }
    }
}
