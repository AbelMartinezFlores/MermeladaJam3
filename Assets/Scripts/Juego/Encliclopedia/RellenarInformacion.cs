using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class RellenarInformacion : MonoBehaviour{

    public Image imagenRecetaSeleccionado;
    public Text descripcionRecetaSeleccionado;
    public Text valorRecetaSeleccionado;
    public Text nombreRecetaSeleccioando;
    public List<Text> ingredientes = new List<Text>();

    public GameObject vaca;


    //Aquí se implementa la lógica de cuando le das click a un ingrediente rellenando el menu de la derecha de la enciclopedia
    public void SeleccionarIngrediente(){

        //El nombre del ingrediente que hacemos click es el texto donde hacemos click
        //Uso el this por que este script va en cada boton, es decir, que puedo saber que estoy en el boton que he hecho click
        Text nombreReceta = this.GetComponentInChildren<Text>();

        //Cargamos los ingredientes
        Receta [] recetas = Resources.LoadAll<Receta>("Recetas/");

        //Variable auxiliar para ahorrar unos cuantos ciclos
        bool encontrado = false;

        //Recorremos hasta encontrar nuestro ingrediente
        for(int i = 0; i < recetas.Length && !encontrado; i++){

            //Si lo encontramos...
            if(recetas[i].nombre == nombreReceta.text){
                encontrado = true;

                //Rellenamos con la información pertinente nuestro panel

                if (vaca.GetComponent<Vaca>().TieneRecetaDesbloqueada(recetas[i].nombre)) imagenRecetaSeleccionado.sprite = recetas[i].imagenDesbloqueada;
                else imagenRecetaSeleccionado.sprite = recetas[i].imagenBloqueada;

                imagenRecetaSeleccionado.sprite = recetas[i].imagenDesbloqueada;
                descripcionRecetaSeleccionado.text = recetas[i].descripcion;
                valorRecetaSeleccionado.text = recetas[i].precio.ToString();
                nombreRecetaSeleccioando.text = recetas[i].nombre;

                for( int j = 0; j < 3; j++){
                
                    if(recetas[i].ingredientes.Count > j  )
                    {
                        ingredientes[j].text = recetas[i].ingredientes[j].nombre;
                    }
                    else
                    {
                        ingredientes[j].text = "";
                    }
                
                }

            }
        }

    }
}
