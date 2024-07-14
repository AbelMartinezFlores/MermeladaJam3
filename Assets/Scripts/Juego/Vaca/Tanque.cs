using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanque : MonoBehaviour
{
    float litros = 50;
    public Color color = Color.white;

    private void Update() {
        if (vacio()) {
            terminarOrdenyo();
        } else {
            Debug.Log(litros);
        }
    }

    public void vaciar() {
        litros--;
    }
    public bool vacio() {
        return litros <= 0;
    }

    public Color colorDeLeche() { return color; }

    private void terminarOrdenyo() {
        Debug.Log("TERMINADO");
    }
}
