using UnityEngine;
using UnityEngine.UI;

public class AjustarSonido : MonoBehaviour{

    //Los distintos slider que dan el valor para el sonido
    public Slider barraDeSonido;
    public Slider barraDeMusica;

    void Start(){
        barraDeMusica.value = PlayerPrefs.GetFloat("VolumenMusica");
        barraDeSonido.value = PlayerPrefs.GetFloat("VolumenSonido");
    }

    //Sirve para cambiar el valor de player pref de sonido
    public void modificarSonido(){
        PlayerPrefs.SetFloat("VolumenSonido", barraDeSonido.value);
    }

    //Sirve para cambiar el valor de player pref de musica
    public void modificarMusica(){
        PlayerPrefs.SetFloat("VolumenMusica", barraDeMusica.value);
    }
    
}
