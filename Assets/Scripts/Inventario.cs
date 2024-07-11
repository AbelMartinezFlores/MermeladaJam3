
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventario : MonoBehaviour
{

    public class ItemInventario: IComparable<ItemInventario>
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
    }

    private List<ItemInventario> objetos = new List<ItemInventario>();

    public List<ItemInventario> getObjetos() { return objetos; }

    public void QuitarObjeto(string newItem)
    {

        for (int i = 0; i < objetos.Count; i++)
        {
            if (objetos[i].objeto.CompareTo(newItem) == 0)
            {
                objetos[i].cantidad--;

                if (objetos[i].cantidad <= 0) objetos.RemoveAt(i);

                break;
            }
        }

    }

    public void AgregarObjeto(string newItem)
    {

        bool existe = false;


        for(int i = 0; i< objetos.Count; i++)
        {
            if( objetos[i].objeto.CompareTo(newItem) == 0)
            {
                objetos[i].cantidad++;
                existe = true;
                break;
            }
        }

        if( !existe)
        {
            objetos.Add(new ItemInventario(newItem, 1));
            objetos.Sort();
        }
        
    }

    public void MostrarObjetos()
    {
        for (int i = 0; i < objetos.Count; i++)
        {
            Debug.Log(objetos[i].objeto + ": " + objetos[i].cantidad);
        }
    }



}
