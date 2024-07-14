using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicializacionMusica : MonoBehaviour{
    void Start(){
        if(!PlayerPrefs.HasKey("VolumenSonido")){
            PlayerPrefs.SetFloat("VolumenSonido", 1);
            PlayerPrefs.SetFloat("VolumenMusica", 1);
        }
    }

}
