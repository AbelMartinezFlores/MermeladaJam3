using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RellenarInformacion : MonoBehaviour{

    public Image imagenIngredienteSeleccionado;
    public Text descripcionIngredienteSeleccionado;
    public Text valorCombinacionSeleccionado;
    public Text nombreIngredienteSeleccioando;
    public GameObject vacaInvisible;
    public GameObject panelDescripcion;
    public GameObject panelPista;

    //Aquí se implementa la lógica de cuando le das click a un ingrediente rellenando el menu de la derecha de la enciclopedia
    public void SeleccionarIngrediente(){

        //El nombre del ingrediente que hacemos click es el texto donde hacemos click
        //Uso el this por que este script va en cada boton, es decir, que puedo saber que estoy en el boton que he hecho click
        Text nombreIngrediente = this.GetComponentInChildren<Text>();

        //Cargamos las combinaciones
        Combinacion [] combinaciones = Resources.LoadAll<Combinacion>("Combinaciones/");

        //Variable auxiliar para ahorrar unos cuantos ciclos
        bool encontrado = false;

        //Obtengo las cambinaciones desbloqueadas
        Vaca scriptVacaInvisible = vacaInvisible.GetComponent<Vaca>();
        List<Combinacion> combinacionesDesbloqueadas = scriptVacaInvisible.ObtenerCombinaciones();

        //Recorremos hasta encontrar nuestra combinacion
        for(int i = 0; i < combinaciones.Length && !encontrado; i++){

            //Si lo encontramos...
            if(combinaciones[i].nombre == this.name){
                encontrado = true;

                //Si esta desbloqueada
                if(combinacionesDesbloqueadas.Contains(combinaciones[i])){

                    //Variable auxiliar para el cálculo del valor
                    int valorTotal = 0;

                    //Obtengo el valor de la combinacion
                    if(combinaciones[i].ingrediente1 != null){
                        valorTotal += combinaciones[i].ingrediente1.valor;
                    }
                    
                    if(combinaciones[i].ingrediente2 != null){
                        valorTotal += combinaciones[i].ingrediente2.valor;
                    }

                    if(combinaciones[i].ingrediente3 != null){
                        valorTotal += combinaciones[i].ingrediente3.valor;
                    }
                    
                    //Rellenamos con la información pertinente nuestro panel
                    imagenIngredienteSeleccionado.sprite = combinaciones[i].sprite;
                    descripcionIngredienteSeleccionado.text = combinaciones[i].descripcion;
                    valorCombinacionSeleccionado.text = valorTotal.ToString();
                    nombreIngredienteSeleccioando.text = combinaciones[i].nombre;

                    //Activamos el panel informacion
                    panelDescripcion.SetActive(true);
                    panelPista.SetActive(false);

                    //Si no lo encontramos
                }else{
                    
                    //Guardamos la pista en el texto
                    panelPista.GetComponentInChildren<Text>().text = combinaciones[i].pista;

                    //Activamos el panel informacion
                    panelDescripcion.SetActive(false);
                    panelPista.SetActive(true);
                }
            }
        }

    }
}
