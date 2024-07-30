using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour{
    
    //Numero de la escena
    public int numeroEscena;
    [SerializeField] private GameObject mensajeError;
    [SerializeField] private float tiempoMostrarError = 2f;
    [SerializeField] private GameObject canvasJuego;

    [SerializeField] private GameObject canvasOrdenyar;
    [SerializeField] private GameObject canvasTeta;

    [SerializeField] private Vaca vaca;
    [SerializeField] private Tanque tanque;

    //1 Es la escena del juego, 0 es la escena del menu principal, 2 es la escena de ordeñar
    //Esto sirve para cambiar la escena del juego

    private void Start()
    {
        if (mensajeError != null) mensajeError.SetActive(false);
    }

    public void CambiarDeEscena(){
        SceneManager.LoadScene(numeroEscena);
    }

    public void CambiarDeEscenaCubo()
    {

        int cantidadIngredientes = vaca.comida.Count;

        if (cantidadIngredientes > 1) {

            //hay que mezclar la leche
            vaca.MezclarLeche();

            tanque.SetLeche(vaca.lecheResultado);
            tanque.litros = 20;
            tanque.color = vaca.lecheResultado.color;
            tanque.lecheCubo.GetComponent<SpriteRenderer>().color = tanque.color;

            canvasJuego.SetActive(false);
            canvasOrdenyar.SetActive(true);
            canvasTeta.SetActive(true);
            //tanque.final.Reseteo();
        }
        else { MostrarError(); }

    }

    public void CambiarDeEscenaLeche()
    {
        canvasJuego.SetActive(true);
        canvasOrdenyar.SetActive(false);
        canvasTeta.SetActive(false);
        vaca.comida.Clear();
        Debug.Log("saludos");
    }

    private void MostrarError()
    {
        mensajeError.SetActive(true);
        StartCoroutine(RetardoError());
    }

    private void OcultarError()
    {
        mensajeError.SetActive(false);
    }

    IEnumerator RetardoError()
    {
        yield return new WaitForSeconds(tiempoMostrarError);
        OcultarError();
    }
}
