using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vaca : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject cabeza;
    [SerializeField] private GameObject cuerpo;
    private Stack<Ingrediente> comida;


    //lista de recetas desbloqueadas
    private List<string> recetasDesbloqueadas = new List<string>();

    private int dinero = 100;
    [SerializeField] private Text textoDinero;

    private void Start()
    {
        textoDinero.text = dinero.ToString();

        recetasDesbloqueadas.Add("Leche mermelada");
        DontDestroyOnLoad(gameObject);
    }


    public bool TieneRecetaDesbloqueada(string nombre)
    {
        return recetasDesbloqueadas.Contains(nombre);
    }

    public void SumarDinero(int c)
    {
        dinero += c;
        textoDinero.text = dinero.ToString();
    }

    public void RestarDinero(int c)
    {
        dinero -= c;
        if (dinero < 0) dinero = 0;
        textoDinero.text = dinero.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SumarDinero(100);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            RestarDinero(20);
        }
    }


}
