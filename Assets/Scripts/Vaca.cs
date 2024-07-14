using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vaca : MonoBehaviour
{
    [SerializeField] private GameObject cabeza;
    [SerializeField] private GameObject cuerpo;

    //Lista de combinaciones para ir guardando las combinaciones desbloqueadas
    [SerializeField] public List<Combinacion> combinacionesDesbloqueadas = new List<Combinacion>();

    [SerializeField] public List<Ingrediente> comida =new List<Ingrediente>();
    private Teta tet;

    private int dinero = 100;
    [SerializeField] private Text textoDinero;

    private void Start()
    {
        textoDinero.text = dinero.ToString();
        tet = GetComponent<Teta>();
        tet.leerCombinaciones();
    }

      void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
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

  
    public int GetDinero()
    {
        return dinero;
    }


    public void comer(Ingrediente alimento)
    {
        int cantidad = comida.Count;
        if (cantidad < 3)
            comida.Add(alimento);
        else
        {
            Debug.Log("Muuuuu no me cabe mas");
        }

   
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
        if (Input.GetKeyUp(KeyCode.C))
        {
            while (comida.Count <= 3)
            {
                Ingrediente aux = ScriptableObject.CreateInstance<Ingrediente>();
                comida.Add(aux);//cambiar null por una comida que se llame nada o algo asi
            }
            //Debug.Log(comida.Count);
            tet.mezclarLeche(comida[0], comida[1], comida[2]);
            comida.Clear();
        }
    }

    //Devuelve las combinaciones desbloqueadas
    public List<Combinacion> ObtenerCombinaciones(){
        return(combinacionesDesbloqueadas);
    }

    //Añade una nueva combinación a la lista de combinaciones
    public void AnyadirCombinaciones(Combinacion nuevaCombinacion){
        combinacionesDesbloqueadas.Add(nuevaCombinacion);
    }



}

        

        
    
  

    





