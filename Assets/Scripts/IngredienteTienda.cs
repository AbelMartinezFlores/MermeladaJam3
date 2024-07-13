using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredienteTienda : MonoBehaviour
{

    [SerializeField]private Tienda tienda;
    [SerializeField]private Ingrediente ingrediente;
    [SerializeField]private int nivel_desbloqueo;

    private bool activo = false;
    private bool comprable = false;

    public void comprar_Ingrediente()
    {
        tienda.comprarIngrediente(ingrediente);
    }

    public void ver_Ingrediente()
    {
        if(activo) tienda.verIngrediente(ingrediente);
    }

    public void cargar(int numero_compras, int dinero)
    {
        //Preguntamos si el objeto ha sido desbloqueado
        desbloqueado(numero_compras);
        //Preguntamos si tenemos dinero suficiente para comparlo
        dineroSuficiente(dinero);
        //Cargamos el ingrediente visualmente
        cargar_Ingrediente();
    }

    private void cargar_Ingrediente()
    {
        GameObject gameobject_imagen = gameObject.transform.Find("Zona Imagen Ingrediente").gameObject.transform.GetChild(0).gameObject;
        GameObject gameobject_boton_compra = gameObject.transform.Find("Boton Comprar Ingrediente").gameObject;
        Image imagen = gameobject_imagen.GetComponent<Image>();

        //Hacemos que la foto se vea o que el ingrediente se pueda comprar con su botón haciendo comprobaciones
        if (activo)
        {
            imagen.color = Color.white;
            if(comprable) gameobject_boton_compra.GetComponent<Button>().interactable = true;
            else gameobject_boton_compra.GetComponent<Button>().interactable = false;
        }
        else
        {
            imagen.color = Color.red;
            gameobject_boton_compra.GetComponent<Button>().interactable = false;
        }

        //Cambiamos la estructura por los datos reales del ingrediente
        if(ingrediente != null)
        {
            gameobject_boton_compra.transform.GetChild(0).gameObject.GetComponent<Text>().text = ingrediente.dinero.ToString() + " €";
            imagen.sprite = ingrediente.imagen;
        }
    }

    private void desbloqueado(int numero)
    {
        if (numero >= nivel_desbloqueo) activo = true;
        else activo = false;
    }

    private void dineroSuficiente(int dinero)
    {
        if (ingrediente != null && dinero >= ingrediente.dinero) comprable = true;
        else comprable = false;
    }

    public Ingrediente getIngrediente()
    {
        return ingrediente;
    }
}
