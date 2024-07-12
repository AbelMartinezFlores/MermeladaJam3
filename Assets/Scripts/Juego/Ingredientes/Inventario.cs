
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventario : MonoBehaviour
{
    public GameObject prefabInventario;
    public List<Objeto> objetos = new List<Objeto>();

    private Objeto obj;

    /*public class ItemInventario: IComparable<ItemInventario>
    {
        public string objeto;
        public int cantidad;

        public ItemInventario(string obj, int n)
        {
            objeto = obj;
            cantidad = n;
        }

        public int CompareTo(ItemInventario other)
        {
            return this.objeto.CompareTo(other.objeto);
        }
    }*/



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
        i1.nombre = "a";
        i1.sprite = Resources.Load<Sprite>("../../Sprites/LaVacabeza.png"); ;
        
        GameObject inventario = GameObject.Instantiate(prefabInventario, Vector2.zero, Quaternion.identity, GameObject.FindGameObjectWithTag("Inventario").transform);
        obj = inventario.GetComponent<Objeto>();
        obj.CrearIngrediente(i1, 2);

        objetos.Add(obj);

        Ingrediente i2 = ScriptableObject.CreateInstance<Ingrediente>();
        i2.nombre = "b";
        i2.sprite = Resources.Load<Sprite>("../../Sprites/LaVacacuerpo.png");
        
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
