using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    [SerializeField] public CambiarEscena cambio;

    [SerializeField] private GameObject tanque;
    [SerializeField] private Vaca vaca;

    public void Aparecer(Sprite obj, bool bueno, string nom, int din)
    {
        gameObject.SetActive(true);
        animator = gameObject.GetComponent<Animator>();
        nombre.text = nom;
        dinero.text = din.ToString();
        vaca.SumarDinero(din);

        if(bueno) fondo.sprite = buenaMezcla;
        else fondo.sprite = malaMezcla;

        objeto.sprite = obj;
        
        if( animator != null)
        {
            Debug.Log("funcionaaaaa");
            animator.SetTrigger("Aparecer");

        }
        else
        {
            Debug.Log("No lo pilla");
        }

    }

    public void Desaparecer()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.SetTrigger("Desaparecer");
        
    }


    public void CambiarEscena()
    {
        if (vaca.getGanado()) SceneManager.LoadScene(3);
        else tanque.GetComponent<Tanque>().salir();
    }

    public void Reseteo()
    {
        //animator.SetTrigger("Reset");
    }

}
