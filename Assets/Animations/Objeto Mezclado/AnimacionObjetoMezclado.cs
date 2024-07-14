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

    [SerializeField] private Sprite buenaMezcla;
    [SerializeField] private Sprite malaMezcla;



    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void cambiarEscena()
    {

    }

    public void Aparecer(Sprite obj, bool bueno, string nom, int din)
    {
        nombre.text = nom;
        dinero.text = din.ToString();

        if(bueno) fondo.sprite = buenaMezcla;
        else fondo.sprite = malaMezcla;

        objeto.sprite = obj;
        
        animator.SetTrigger("Aparecer");
    }

    public void Desaparecer()
    {
        animator.SetTrigger("Desaparecer");
    }

}
