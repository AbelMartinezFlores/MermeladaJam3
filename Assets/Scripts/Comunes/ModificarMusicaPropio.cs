using UnityEngine;

public class ModificarMusicaPropio : MonoBehaviour{
    
    //Modifica el volumen de la música
    void Update(){
        AudioSource audio = this.GetComponent<AudioSource>();
        audio.volume = PlayerPrefs.GetFloat("VolumenMusica");
    }
}
