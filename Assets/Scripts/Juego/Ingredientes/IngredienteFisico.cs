using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredienteFisico : MonoBehaviour
{
    GameObject vacabeza;
    public Sprite cerrada;
    public Sprite abierta;
    public Ingrediente ing;
    public float distancia = 5;
    public float distanciaComer = 2;
    bool comible = true;

    public Inventario inv;

    // Start is called before the first frame update
    void Start()
    {
        vacabeza = GameObject.Find("Cabeza_Vaca");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().sprite = ing.sprite;
        Vector2 punto1 = vacabeza.transform.position;
        Vector2 punto2 = transform.position;
        float distanciaActual = (punto1 - punto2).magnitude;

        abrir(distanciaActual <= distancia);
        comer(distanciaActual <= distanciaComer);
    }

    public void comer(bool dis) {
        if (dis && comible) {
            if (GameObject.Find("La_Vaca").GetComponent<Vaca>().comer(ing)) {
                comible = false;
                abrir(false);
                Destroy(gameObject);
            }
        }
    }

    public void abrir(bool ab) {
        if (ab) {
            vacabeza.GetComponent<Image>().sprite = abierta;
        } else {
            vacabeza.GetComponent<Image>().sprite = cerrada;
        }
        
    }
}
