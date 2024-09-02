using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Tienda : MonoBehaviour
{
    [SerializeField]private int compras_realizadas = 0;
    [SerializeField]private GameObject[] todos_ingedientes;
    [SerializeField]private Vaca laVaca;
    [SerializeField]private Inventario inventario;

    private void Start()
    {
        //Obtenemos el objeto de la zona donde se encuentran los ingredientes
        GameObject zona_ingredientes =  GameObject.Find("Zona ingredientes");
        //Restamos 1 para eliminar el objeto del fondo del n�mero total de hijos
        todos_ingedientes = new GameObject[zona_ingredientes.transform.childCount - 1];

        //Recogemos los hijos con el valor i + 1 para saltarnos el objeto fondo
        for(int i=0; i<todos_ingedientes.Length ; i++)
        {
            //Nos guardamos el gameobject y llamamos al m�todo cargar de 'IngredienteTienda'
            todos_ingedientes[i] = zona_ingredientes.transform.GetChild(i + 1).gameObject;
            todos_ingedientes[i].GetComponent<Ingrediente_Tienda>().cargar(compras_realizadas, laVaca.GetDinero());
        }
    }

    public void abrirTienda()
    {
        gameObject.SetActive(true);
        GameObject ingrediente_sel = gameObject.transform.Find("IngredienteSeleccionado").gameObject;
        ingrediente_sel.SetActive(false);
        actualizarTienda();
    }

    public void comprarIngrediente(Ingrediente ingrediente, int nivel)
    {
        //Al comprar un ingrediente restamos su valor del dinero total y actualizamos la tienda
        Debug.Log("Compras el ingrediente " + ingrediente.nombre + " con un precio de " + ingrediente.valor.ToString() );
        if(nivel == compras_realizadas) compras_realizadas++;
        laVaca.RestarDinero(ingrediente.valor);
        inventario.AgregarObjeto(ingrediente);
        actualizarTienda();
    }

    public void verIngrediente(Ingrediente ingrediente)
    {
        //Al clickar sobre un ingrediente sus datos se ver�n en la pesta�a grande
        Debug.Log("Ver el ingrediente " + ingrediente.nombre);
        GameObject ingrediente_sel = gameObject.transform.Find("IngredienteSeleccionado").gameObject;
        ingrediente_sel.SetActive(true);
        GameObject nombre = ingrediente_sel.transform.Find("NombreIngrediente").gameObject;
        GameObject descripcion = ingrediente_sel.transform.Find("DescripcionIngrediente").gameObject;
        GameObject imagen = ingrediente_sel.transform.Find("ImagenIngrediente").gameObject.transform.GetChild(0).gameObject;

        nombre.GetComponent<Text>().text = ingrediente.nombre;
        descripcion.GetComponent<Text>().text = ingrediente.descripcion;
        imagen.GetComponent<Image>().sprite = ingrediente.sprite;
    }

    private void actualizarTienda()
    {
        for (int i = 0; i < todos_ingedientes.Length; i++)
        {
            todos_ingedientes[i].GetComponent<Ingrediente_Tienda>().cargar(compras_realizadas, laVaca.GetDinero());
        }
    }
}
