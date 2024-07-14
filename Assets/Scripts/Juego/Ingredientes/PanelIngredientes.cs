using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelIngredientes : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private RectTransform rectTransformPanel;
    private Animator animator;

    [SerializeField] private float posAbiertoX;
    [SerializeField] private float posCerradoX;

    [SerializeField] private float duracion;

    private bool abierto = false;

    void Start()
    {
        rectTransformPanel = panel.GetComponent<RectTransform>();
        animator = gameObject.GetComponent<Animator>();
        Vector3 posFinal = rectTransformPanel.position;
        posFinal.x = posCerradoX;
        rectTransformPanel.position = posFinal;
    }



    public void AbrirPanel()
    {
        abierto = true;
        animator.SetBool("abierto", abierto);
    }

    public void CerrarPanel()
    {
        abierto = false;
        animator.SetBool("abierto", abierto);
    }


}
