using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimacionObjetoMezclado : MonoBehaviour
{

    private Animator animator;
    [SerializeField] private Image fondo;
    [SerializeField] private Image objeto;
    [SerializeField] private Text nombre;
    [SerializeField] private Text dinero;



    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void cambiarEscena()
    {

    }

    public void Aparecer(Sprite obj, Sprite fon, string nom, int din)
    {
        nombre.text = nom;
        dinero.text = din.ToString();
        fondo.sprite = fon;
        objeto.sprite = obj;
        
        animator.SetTrigger("Aparecer");
    }

    public void Desaparecer()
    {
        animator.SetTrigger("Desaparecer");
    }

}
