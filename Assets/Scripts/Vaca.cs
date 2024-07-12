using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaca : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject cabeza;
    [SerializeField] private GameObject cuerpo;
    private Stack<Ingrediente> comida;

    public void comer(Ingrediente alimento)
    {
        int cantidad = comida.Count;
        if (cantidad < 3)
            comida.Push(alimento);
        else
        {
            Debug.Log("Muuuuu no me cabe mas");
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    }





