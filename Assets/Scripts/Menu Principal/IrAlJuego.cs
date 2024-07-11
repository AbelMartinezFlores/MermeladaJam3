using UnityEngine;
using UnityEngine.SceneManagement;

public class IrAlJuego : MonoBehaviour{

    //1 Es la escena del juego, 0 es la escena del menu principal
    //Esto sirve para cambiar la escena del juego
    public void CambiarDeEscena(){
        SceneManager.LoadScene(1);
    }
}
