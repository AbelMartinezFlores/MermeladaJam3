using UnityEngine;
using UnityEngine.SceneManagement;

public class IrAlMenu : MonoBehaviour{
    
    //1 Es la escena del juego, 0 es la escena del menu principal
    //Esto sirve para cambiar la escena del juego
    public void VolverAlMenuPrincipal(){
        SceneManager.LoadScene(0);
    }
}
