using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuncionesEnciclopedia : MonoBehaviour{
    public GameObject contenidoEnciclopedia;
    public GameObject plantillaCombinacion;
    public GameObject vacaInvisible;

    //Al iniciarse por el boton la enciclopedia se rellena con esta función
    void OnEnable(){

        //Elimina todas las combinaciones anteriores
        for(int i = 0; i < contenidoEnciclopedia.transform.childCount; i++){
            Destroy(contenidoEnciclopedia.transform.GetChild(i).gameObject);
        }

        //Carga todas las combinaciones del fichero de combinaciones localizado en Resources
        Combinacion [] combinaciones = Resources.LoadAll<Combinacion>("Combinaciones/");

        foreach(Combinacion combinacion in combinaciones){
            //Creo una copia de la plantilla que he hecho en el editor
            GameObject objetoCombinacion = Instantiate(plantillaCombinacion);
            objetoCombinacion.name = combinacion.nombre;

            //Obtengo las cambinaciones desbloqueadas
            Vaca scriptVacaInvisible = vacaInvisible.GetComponent<Vaca>();
            List<Combinacion> combinacionesDesbloqueadas = scriptVacaInvisible.ObtenerCombinaciones();

            //Recorro los hijos para llenar la imagen y el texto
            for(int i = 0; i < objetoCombinacion.transform.childCount; i++){
                GameObject parteCombinacion = objetoCombinacion.transform.GetChild(i).gameObject;

                //Variable auxiliar para ahorrar ciclos
                bool encontrada = false;

                //Compruebo si se encuentra dentro de las combinaciones desbloqueadas
                if(combinacionesDesbloqueadas.Contains(combinacion)){
                    encontrada = true;
                }
                
                //Si el objeto esta bloqueado...
                if(!encontrada){

                    //Si es el nombre...
                    if(parteCombinacion.name.Contains("Texto")){
                        Text nombreIngrediente = parteCombinacion.GetComponent<Text>();
                        nombreIngrediente.text = "???";
                    }

                    //Si es la imagen...
                    else if(parteCombinacion.name.Contains("Imagen")){

                        //Cargo la imagen de bloqueada por defecto
                        Sprite spriteBloqueado = Resources.Load<Sprite>("Sprites/Foto Estandar de Bloqueado");

                        Image imagenIngrediente = parteCombinacion.GetComponent<Image>();
                        imagenIngrediente.sprite = spriteBloqueado;
                    }

                }else{

                    //Si es el nombre...
                    if(parteCombinacion.name.Contains("Texto")){
                        Text nombreIngrediente = parteCombinacion.GetComponent<Text>();
                        nombreIngrediente.text = combinacion.nombre;
                    }

                    //Si es la imagen...
                    else if(parteCombinacion.name.Contains("Imagen")){
                        Image imagenIngrediente = parteCombinacion.GetComponent<Image>();
                        imagenIngrediente.sprite = combinacion.sprite;
                    }
                }
            }

            //Le decimos que se quede dentro del area de la enciclopedia y lo iniciamos 
            //PD: El false es importante sino la funcion te manda a parla al hijo
            objetoCombinacion.transform.SetParent(contenidoEnciclopedia.transform, false);
            objetoCombinacion.SetActive(true);
        }
    }
}
