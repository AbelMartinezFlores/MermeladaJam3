using UnityEngine;
using UnityEngine.UI;

public class FuncionesEnciclopedia : MonoBehaviour{
    public GameObject contenidoEnciclopedia;
    public GameObject plantillaCombinacion;


    //Al iniciarse por el boton la enciclopedia se rellena con esta función
    void Start(){
        //Carga todas las combinaciones del fichero de combinaciones localizado en Resources
        Combinacion [] combinaciones = Resources.LoadAll<Combinacion>("Combinaciones/");

        foreach(Combinacion combinacion in combinaciones){
        //Creo una copia de la plantilla que he hecho en el editor
            GameObject objetoCombinacion = Instantiate(plantillaCombinacion);

            //Recorro los hijos para llenar la imagen y el texto
            for(int i = 0; i < objetoCombinacion.transform.childCount; i++){
                GameObject parteCombinacion = objetoCombinacion.transform.GetChild(i).gameObject;
                
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

            //Le decimos que se quede dentro del area de la enciclopedia y lo iniciamos 
            //PD: El false es importante sino la funcion te manda a parla al hijo
            objetoCombinacion.transform.SetParent(contenidoEnciclopedia.transform, false);
            objetoCombinacion.SetActive(true);
        }
    }
}
