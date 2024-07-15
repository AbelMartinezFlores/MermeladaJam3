using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanque : MonoBehaviour
{
    float litros = 50;
    public Color color = Color.white;
    public AnimacionObjetoMezclado final;
    public GameObject lecheCubo;
    Combinacion leche;
    

    private void Start() {
        //leche = GameObject.Find("La_Vaca").GetComponent<Vaca>().lecheResultado;
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

        final.Aparecer(leche.sprite,buena,leche.nombre,dinero);
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
