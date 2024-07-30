using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tanque : MonoBehaviour
{
    public float litros = 20;
    public Color color = Color.white;
    public GameObject final;
    public GameObject lecheCubo;

    public Image fondo;
    public Image objetoleche;
    [SerializeField] private Sprite buenaMezcla;
    [SerializeField] private Sprite malaMezcla;
    public Text diner;
    public Text nombre;
    [SerializeField] public CambiarEscena cambio;

    bool aparecido = false;
    Combinacion leche;
    

    void OnAwake() {
        //leche = GameObject.Find("La_Vaca").GetComponent<Vaca>().lecheResultado;
        aparecido = false;
        //color = leche.color;
        //lecheCubo.GetComponent<SpriteRenderer>().color = color;
    }

    private void Update() {
        if (vacio()) {
            terminarOrdenyo();
        } else {
            //Debug.Log(litros);
        }
    }

    public void SetLeche(Combinacion lechecita)
    {
        leche = lechecita;
        color = leche.color;
        lecheCubo.GetComponent<SpriteRenderer>().color = color;
    }

    public void vaciar() {
        litros--;
    }
    public bool vacio() {
        return litros <= 0;
    }

    public Color colorDeLeche() { return color; }

    private void terminarOrdenyo() {
        if (!aparecido) {
            aparecido = true;
            lecheCubo.active = true;

            bool buena = (leche.nIngredientes != 0);
            int dinero = 0;

            switch (leche.nIngredientes) {
                case 3:
                    dinero += leche.ingrediente3.valor;
                    goto case 2;
                case 2:
                    dinero += leche.ingrediente2.valor;
                    goto case 1;
                case 1:
                    dinero += leche.ingrediente1.valor;
                    break;
            }

            dinero *= leche.nIngredientes;


            /*
            if (buena) fondo.sprite = buenaMezcla;
            else fondo.sprite = malaMezcla;

            objetoleche.sprite = leche.sprite;

            nombre.text = leche.nombre;
            diner.text = dinero.ToString();*/

            //final.SetActive(true);

            //final.Aparecer(leche.sprite,buena,leche.nombre,dinero);
            final.GetComponent<AnimacionObjetoMezclado>().Aparecer(leche.sprite, buena, leche.nombre, dinero);
        }
    }

    public void salir()
    {
        aparecido = false;
        lecheCubo.SetActive(false);
        final.SetActive (false);
        cambio.CambiarDeEscenaLeche();
        Debug.Log("Buenas tardes");
    }
}

/*
    public string nombre;
    public int nIngredientes;
    public Ingrediente ingrediente1;
    public Ingrediente ingrediente2;
    public Ingrediente ingrediente3;
    public string descripcion;
    public string pista;
    public Sprite sprite;
    public Sprite spriteBlocked;
 */
