using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UbreRender : MonoBehaviour
{
    public GameObject punta;

    LineRenderer lineRenderer;
    SpringJoint2D muelle;
    
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();       
        muelle = punta.GetComponent<SpringJoint2D>();
    }

    void Update()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, punta.transform.position);
        muelle.connectedAnchor = transform.position;
    }
}
