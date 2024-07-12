using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredienteTienda : MonoBehaviour
{

    [SerializeField]private Tienda tienda;
    [SerializeField]private ScriptableObject ingrediente;
    [SerializeField]private int nivel_desbloqueo;

    private bool activo = false;
    private bool comprable = false;

    public Color colorActivo;
    public Color colorNoActivo;

    public void comprar_Ingrediente()
    {
        Debug.Log("Compras el ingrediente");
        tienda.comprarIngrediente(ingrediente);
    }

    public void cargar(int numero_compras)
    {
        //Preguntamos si el objeto ha sido desbloqueado
        desbloqueado(numero_compras);
        //Preguntamos si tenemos dinero suficiente
        dineroSuficiente(4);
        //Cargamos el ingrediente visualmente
        cargar_Ingrediente();
    }

    private void cargar_Ingrediente()
    {
        GameObject gameobject_imagen = gameObject.transform.Find("Zona Imagen Ingrediente").gameObject.transform.GetChild(0).gameObject;
        GameObject gameobject_boton_compra = gameObject.transform.Find("Boton Comprar Ingrediente").gameObject;
        Image imagen = gameobject_imagen.GetComponent<Image>();

        if (activo)
        {
            imagen.color = colorActivo;
            gameobject_boton_compra.GetComponent<Button>().interactable = true;
        }
        else
        {
            imagen.color = colorNoActivo;
            gameobject_boton_compra.GetComponent<Button>().interactable = false;
        }
    }

    private void desbloqueado(int numero)
    {
        if (numero >= nivel_desbloqueo) activo = true;
        else activo = false;
    }

    private void dineroSuficiente(int dinero)
    {

    }

}
