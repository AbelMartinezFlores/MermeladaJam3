using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tienda : MonoBehaviour
{

    public int compras_realizadas = 0;
    public GameObject[] todos_ingedientes;

    private void Start()
    {
        GameObject zona_ingredientes =  GameObject.Find("Zona ingredientes");

        //Restamos 1 para eliminar el objeto del fondo
        todos_ingedientes = new GameObject[zona_ingredientes.transform.childCount - 1];

        //Recogemos los hijos con el valor i + 1 para saltarnos el objeto fondo
        for(int i=0; i<todos_ingedientes.Length ; i++)
        {
            //Nos guardamos el gameobject y llamamos al método cargar de 'IngredienteTienda'
            todos_ingedientes[i] = zona_ingredientes.transform.GetChild(i + 1).gameObject;
            todos_ingedientes[i].GetComponent<IngredienteTienda>().cargar(compras_realizadas);
        }
    }

    public void comprarIngrediente(ScriptableObject ingrediente)
    {
        Debug.Log("Compras el ingrediente " + " con un precio de ");
        compras_realizadas++;
        //Restar el dinero//
        actualizarTienda();
    }

    private void actualizarTienda()
    {
        for (int i = 0; i < todos_ingedientes.Length; i++)
        {
            todos_ingedientes[i].GetComponent<IngredienteTienda>().cargar(compras_realizadas);
        }
    }
}
