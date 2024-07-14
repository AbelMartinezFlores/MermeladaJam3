using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class FuncionesEnciclopedia : MonoBehaviour{
    public GameObject contenidoEnciclopedia;
    public GameObject plantillaIngrediente;

    public GameObject vaca;


    //Al iniciarse por el boton la enciclopedia se rellena con esta función
    void Start(){
        //Carga todos los ingredientes del fiecho de ingredientes localizado en Resources
        Receta [] recetas = Resources.LoadAll<Receta>("Recetas/");

        foreach(Receta receta in recetas){
        //Creo una copia de la plantilla que he hecho en el editor
            GameObject objetoIngrediente = Instantiate(plantillaIngrediente);

            //Recorro los hijos para llenar la imagen y el texto
            for(int i = 0; i < objetoIngrediente.transform.childCount; i++){
                GameObject parteIngrediente = objetoIngrediente.transform.GetChild(i).gameObject;
                
                //Si es el nombre...
                if(parteIngrediente.name.Contains("Texto")){
                    Text nombreIngrediente = parteIngrediente.GetComponent<Text>();
                    nombreIngrediente.text = receta.nombre;
                }
                //Si es la imagen...
                else if(parteIngrediente.name.Contains("Imagen")){
                    Image imagenIngrediente = parteIngrediente.GetComponent<Image>();

                    if( vaca.GetComponent<Vaca>().TieneRecetaDesbloqueada(receta.nombre) ) imagenIngrediente.sprite = receta.imagenDesbloqueada;
                    else imagenIngrediente.sprite = receta.imagenBloqueada;

                }
            }

            //Le decimos que se quede dentro del area de la enciclopedia y lo iniciamos 
            //PD: El false es importante sino la funcion te manda a parla al hijo
            objetoIngrediente.transform.SetParent(contenidoEnciclopedia.transform, false);
            objetoIngrediente.SetActive(true);
        }
    }
}
