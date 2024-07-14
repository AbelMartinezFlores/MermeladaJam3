using UnityEngine;
using UnityEngine.UI;

public class RellenarInformacion : MonoBehaviour{

    public Image imagenIngredienteSeleccionado;
    public Text descripcionIngredienteSeleccionado;
    public Text valorIngredineteSeleccionado;
    public Text nombreIngredienteSeleccioando;

    //Aquí se implementa la lógica de cuando le das click a un ingrediente rellenando el menu de la derecha de la enciclopedia
    public void SeleccionarIngrediente(){

        //El nombre del ingrediente que hacemos click es el texto donde hacemos click
        //Uso el this por que este script va en cada boton, es decir, que puedo saber que estoy en el boton que he hecho click
        Text nombreIngrediente = this.GetComponentInChildren<Text>();

        //Cargamos los ingredientes
        Ingrediente [] ingredientes = Resources.LoadAll<Ingrediente>("Ingredientes/");

        //Variable auxiliar para ahorrar unos cuantos ciclos
        bool encontrado = false;

        //Recorremos hasta encontrar nuestro ingrediente
        for(int i = 0; i < ingredientes.Length && !encontrado; i++){

            //Si lo encontramos...
            if(ingredientes[i].nombre == nombreIngrediente.text){
                encontrado = true;

                //Rellenamos con la información pertinente nuestro panel
                imagenIngredienteSeleccionado.sprite = ingredientes[i].sprite;
                descripcionIngredienteSeleccionado.text = ingredientes[i].descripcion;
                valorIngredineteSeleccionado.text = ingredientes[i].valor.ToString();
                nombreIngredienteSeleccioando.text = ingredientes[i].nombre;
            }
        }

    }
}
