using UnityEngine;
using UnityEngine.SceneManagement;

public class SalirCreditos : MonoBehaviour{

    private int numeroEscenaMenuPrincipal = 0;

    //Permite salir al menu principal cuando se presiona el ESC
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene(numeroEscenaMenuPrincipal);
        }
    }
}
