using UnityEngine;
using UnityEngine.SceneManagement;

public class IrAlJuego : MonoBehaviour{

    //1 Es la escena del juego, 0 es la escena del menu principal
    public void CambiarDeEscena(){
        SceneManager.LoadScene(1);
    }
}
