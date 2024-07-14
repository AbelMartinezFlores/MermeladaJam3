using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour{
    
    //Numero de la escena
    public int numeroEscena;

    //1 Es la escena del juego, 0 es la escena del menu principal, 2 es la escena de ordeñar
    //Esto sirve para cambiar la escena del juego
    public void CambiarDeEscena(){
        SceneManager.LoadScene(numeroEscena);
    }
}
