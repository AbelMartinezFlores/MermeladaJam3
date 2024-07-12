using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredienteTienda : MonoBehaviour
{

    public int nivel_desbloqueo;
    private bool activo = false;
    public Color colorActivo;
    public Color colorNoActivo;

    public void cargar(int numero_compras)
    {
        if (numero_compras >= nivel_desbloqueo) activo = true;
        this.cargar_Ingrediente();
    }

    private void cargar_Ingrediente()
    {
        GameObject gameobject_imagen = gameObject.transform.Find("Zona Imagen Ingrediente").gameObject.transform.GetChild(0).gameObject;
        Image imagen = gameobject_imagen.GetComponent<Image>();

        if (activo) imagen.color = colorActivo;
        else imagen.color = colorNoActivo;
    }
}
