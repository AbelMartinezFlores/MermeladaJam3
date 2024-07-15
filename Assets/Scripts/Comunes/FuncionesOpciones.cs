using UnityEngine;
using UnityEngine.UI;

public class FuncionesOpciones : MonoBehaviour{
    public Text textoMarcaBoton;

    //Cambia el estado inicial del boton segun como este la pantalla
    void Start(){
        if(Screen.fullScreen){
            textoMarcaBoton.text = "X";
        }else{
            textoMarcaBoton.text = "";
        }
    }

    //Cambia entre pantalla completa y ventana y actualiza el recuadro donde se muestra
    public void CambiarAPantallaCompleta(){
        if(Screen.fullScreen){
            textoMarcaBoton.text = "";
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, false);
        }else{
            textoMarcaBoton.text = "X";
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        }
    }
}
