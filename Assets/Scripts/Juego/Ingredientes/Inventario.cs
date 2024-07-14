
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventario : MonoBehaviour
{
    public GameObject prefabInventario;
    public List<Objeto> objetos = new List<Objeto>();

    private Objeto obj;

    public List<Objeto> getObjetos() { return objetos; }

    public void QuitarObjeto(string newItem)
    {
        for (int i = 0; i < objetos.Count; i++)
        {
            if (objetos[i].nombre.text == newItem)
            {
                int aux = int.Parse(objetos[i].cantidad.text) - 1;

                if (aux <= 0) objetos.RemoveAt(i);
                else objetos[i].UpdateIngrediente(aux);

                break;
            }
        }

    }

    public void AgregarObjeto(Ingrediente ing)
    {
        bool existe = false;

        for(int i = 0; i< objetos.Count; i++)
        {
            if (objetos[i].nombre.text == ing.nombre)
            {
                int aux = int.Parse(objetos[i].cantidad.text) + 1;
                objetos[i].UpdateIngrediente(aux);
                existe = true;

                break;
            }
        }

        if(!existe)
        {
            GameObject inventario = GameObject.Instantiate(prefabInventario, Vector2.zero, Quaternion.identity, GameObject.FindGameObjectWithTag("Inventario").transform);
            obj = inventario.GetComponent<Objeto>();
            obj.CrearIngrediente(ing, 1);

            objetos.Add(obj);
        }
        
    }
}
