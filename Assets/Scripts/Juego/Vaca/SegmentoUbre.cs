using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentoUbre : MonoBehaviour
{
    public GameObject conectadoArriba, conectadoAbajo;

    void Start()
    {
        conectadoArriba = GetComponent<HingeJoint2D>().connectedBody.gameObject;
        SegmentoUbre segmentoSuperior = conectadoArriba.GetComponent<SegmentoUbre>();

        float tamanyo = GetComponent<SpriteRenderer>().bounds.size.y;
        float pivote = tamanyo/4;
        GetComponent<HingeJoint2D>().anchor = new Vector2(0, pivote);

        if (segmentoSuperior != null) {
            segmentoSuperior.conectadoAbajo = gameObject;

            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, pivote*-1);
        } else {
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, 0);
        }
    }
}
