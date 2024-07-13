
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

    private void Start()
    {
        Ingrediente i1 = ScriptableObject.CreateInstance<Ingrediente>();
        i1.nombre = "aa";
        i1.sprite = Resources.Load<Sprite>("Sprites/LaVacabeza");

        if (i1.sprite == null)
        {
            Debug.LogError("No se encontr� el sprite 'Sprites/LaVacabeza.png'. Aseg�rate de que el archivo est� en 'Assets/Resources/Sprites'.");
            return;
        }
 
        GameObject inventarioGO = GameObject.FindGameObjectWithTag("Inventario");
        if (inventarioGO == null)
        {
            Debug.LogError("No se encontr� un objeto con el tag 'Inventario'.");
            return;
        }

        GameObject inventario = GameObject.Instantiate(prefabInventario, Vector2.zero, Quaternion.identity, GameObject.FindGameObjectWithTag("Inventario").transform);
        obj = inventario.GetComponent<Objeto>();

        if (obj == null)
        {
            Debug.LogError("No se encontr� el componente 'Objeto' en el prefab de inventario.");
            return;
        }

        obj.CrearIngrediente(i1, 2);

        objetos.Add(obj);

        Ingrediente i2 = ScriptableObject.CreateInstance<Ingrediente>();
        i2.nombre = "bb";
        i2.sprite = Resources.Load<Sprite>("Sprites/LaVacacuerpo");
        
        GameObject inventario2 = GameObject.Instantiate(prefabInventario, Vector2.zero, Quaternion.identity, GameObject.FindGameObjectWithTag("Inventario").transform);
        obj = inventario2.GetComponent<Objeto>();
        obj.CrearIngrediente(i2, 5);

        objetos.Add(obj);
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
            objetos.Sort();
        }
        
    }

    public void MostrarObjetos()
    {
       // ScriptableObject objetoEncontrado = new Ingrediente();

        for (int i = 0; i < objetos.Count; i++)
        {
            
            /*GameObject obj = GameObject.Instantiate(prefabInventario, Vector2.zero, Quaternion.identity, GameObject.FindGameObjectWithTag("Inventario").transform);
            obj.GetComponent<SpriteRenderer>().sprite = objetoEncontrado.sprite;*/

            //Debug.Log(objetos[i].objeto + ": " + objetos[i].cantidad);
        }
    }



}
