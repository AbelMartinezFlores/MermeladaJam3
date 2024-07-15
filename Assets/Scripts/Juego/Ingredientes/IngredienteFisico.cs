using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredienteFisico : MonoBehaviour
{
    GameObject vacabeza;
    public Sprite cerrada;
    public Sprite abierta;
    public float distancia = 5;

    // Start is called before the first frame update
    void Start()
    {
        vacabeza = GameObject.Find("Cabeza_Vaca");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 punto1 = vacabeza.transform.position;
        Vector2 punto2 = transform.position;
        float distanciaActual = (punto1 - punto2).magnitude;

        if (distanciaActual <= distancia) {
            vacabeza.GetComponent<Image>().sprite = abierta;
        } else {
            vacabeza.GetComponent<Image>().sprite = cerrada;
        }
    }
}
