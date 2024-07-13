using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionObjetoMezclado : MonoBehaviour
{

    private Animator animator;


    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Aparecer();
        }
    }

    public void cambiarEscena()
    {

    }

    public void Aparecer()
    {
        animator.SetTrigger("Aparecer");
    }

    public void Desaparecer()
    {
        animator.SetTrigger("Desaparecer");
    }

}
