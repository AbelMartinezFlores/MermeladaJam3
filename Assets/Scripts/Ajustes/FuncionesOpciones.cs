using UnityEngine;
using UnityEngine.UI;

public class FuncionesOpciones : MonoBehaviour{
    public Text textoMarcaBoton;
    public void CambiarAPantallaCompleta(){
        if(Screen.fullScreen){
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, false);
            textoMarcaBoton.text = "";
        }else{
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
            textoMarcaBoton.text = "X";
        }
    }
}
