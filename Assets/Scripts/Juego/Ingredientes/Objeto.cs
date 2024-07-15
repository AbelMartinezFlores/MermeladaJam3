using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objeto : MonoBehaviour
{
    [SerializeField] public Image imagen;
    [SerializeField] public Text nombre;
    [SerializeField] public Text cantidad;
    public Ingrediente ingrediente;

    public void CrearIngrediente(Ingrediente ing, int cant)
    {
        ingrediente = ing;
        imagen.sprite = ing.sprite;
        nombre.text = ing.nombre;
        cantidad.text = cant.ToString();
    }

    public void UpdateIngrediente(int cant)
    {
        cantidad.text = cant.ToString();
    }
}
