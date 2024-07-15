using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModificarSonido : MonoBehaviour{

    //Modifica el volumen del sonido
    void Update(){
        AudioSource audio = this.GetComponent<AudioSource>();
        audio.volume = PlayerPrefs.GetFloat("VolumenSonido");
    }
}
