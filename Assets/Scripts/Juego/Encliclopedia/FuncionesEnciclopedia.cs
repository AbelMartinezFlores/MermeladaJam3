using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class FuncionesEnciclopedia : MonoBehaviour{
    public GameObject contenidoEnciclopedia;
    public GameObject plantillaIngrediente;


    //Al iniciarse por el boton la enciclopedia se rellena con esta función
    void Start(){
        //Carga todos los ingredientes del fiecho de ingredientes localizado en Resources
        Ingrediente [] ingredientes = Resources.LoadAll<Ingrediente>("Ingredientes/");

        foreach(Ingrediente ingrediente in ingredientes){
        //Creo una copia de la plantilla que he hecho en el editor
            GameObject objetoIngrediente = Instantiate(plantillaIngrediente);

            //Recorro los hijos para llenar la imagen y el texto
            for(int i = 0; i < objetoIngrediente.transform.childCount; i++){
                GameObject parteIngrediente = objetoIngrediente.transform.GetChild(i).gameObject;
                
                //Si es el nombre...
                if(parteIngrediente.name.Contains("Texto")){
                    Text nombreIngrediente = parteIngrediente.GetComponent<Text>();
                    nombreIngrediente.text = ingrediente.nombre;
                }
                //Si es la imagen...
                else if(parteIngrediente.name.Contains("Imagen")){
                    Image imagenIngrediente = parteIngrediente.GetComponent<Image>();
                    imagenIngrediente.sprite = ingrediente.sprite;
                }
            }

            //Le decimos que se quede dentro del area de la enciclopedia y lo iniciamos 
            //PD: El false es importante sino la funcion te manda a parla al hijo
            objetoIngrediente.transform.SetParent(contenidoEnciclopedia.transform, false);
            objetoIngrediente.SetActive(true);
        }
    }
}
