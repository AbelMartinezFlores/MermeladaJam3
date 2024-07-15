using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Vaca : MonoBehaviour
{
    [SerializeField] private GameObject cabeza;
    [SerializeField] private GameObject cuerpo;
    [SerializeField] public List<Ingrediente> comida =new List<Ingrediente>();
    [SerializeField] public Combinacion lecheResultado;
    [SerializeField] private GameObject bocadillo;

    //Lista de combinaciones para ir guardando las combinaciones desbloqueadas
    [SerializeField] public List<Combinacion> combinacionesDesbloqueadas = new List<Combinacion>();

    private Teta tet;

    private int dinero = 100;
    private bool ganado = false;
    private bool mostrarPanelFinal = false;

    [SerializeField] public Text textoDinero;
    [SerializeField] public Image cuerpoVaca;
    [SerializeField] public Image fondoVaca;
    [SerializeField] public List<Sprite> cuerpos;
    [SerializeField] public List<Sprite> fondos;
    [SerializeField] private GameObject panelVictoria;


    private void Start()
    {
        textoDinero.text = dinero.ToString();
        tet = GetComponent<Teta>();
        tet.leerCombinaciones();

        verComida();
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


    public bool comer(Ingrediente alimento)
    {
        int cantidad = comida.Count;
        if (cantidad < 3) {
            comida.Add(alimento);
        } else {
            Debug.Log("Muuuuu no me cabe mas");
        }

        verComida();
        return cantidad < 3;
    }

    private void verComida()
    {
        for(int i = 0; i<comida.Count; i++)
        {
            if (comida[i])
            {
                Debug.Log("hola");
                bocadillo.transform.GetChild(i).gameObject.SetActive(true);
                bocadillo.transform.GetChild(i).gameObject.GetComponent<Image>().sprite = comida[i].sprite;
            }
            else
            {
                bocadillo.transform.GetChild(i).gameObject.SetActive(false);
            }
            
        }
    }

    private void Update()
    {
        verComida();
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
            lecheResultado=tet.mezclarLeche(comida[0], comida[1], comida[2]);
            comida.Clear();
            
            bool lotengo = false;
            foreach(Combinacion combo in combinacionesDesbloqueadas)
            {
                
                if (combo.nombre == lecheResultado.nombre)
                {
                    lotengo = true;
                }

            }
            if (lotengo == false)
                combinacionesDesbloqueadas.Add(lecheResultado);

            cuerpoVaca.sprite = cuerpos[combinacionesDesbloqueadas.Count / 4];
            fondoVaca.sprite = fondos[combinacionesDesbloqueadas.Count / 4];
            // SceneManager.LoadScene(2); //2 es escena orde�ar
        }


        if( mostrarPanelFinal == false && ganado == true)
        {
            panelVictoria.SetActive(true);
        }

    }

    //Devuelve las combinaciones desbloqueadas
    public List<Combinacion> ObtenerCombinaciones(){
        return(combinacionesDesbloqueadas);
    }

    //Añade una nueva combinación a la lista de combinaciones
    public void AnyadirCombinaciones(Combinacion nuevaCombinacion){
        combinacionesDesbloqueadas.Add(nuevaCombinacion);

        if (combinacionesDesbloqueadas.Count >= 13) {
            ganado = true;
        }
        
    }

    public void MezclarLeche()
    {
        while (comida.Count <= 3)
        {
            Ingrediente aux = ScriptableObject.CreateInstance<Ingrediente>();
            comida.Add(aux);//cambiar null por una comida que se llame nada o algo asi
        }
        //Debug.Log(comida.Count);
        lecheResultado = tet.mezclarLeche(comida[0], comida[1], comida[2]);
       

        bool lotengo = false;
        foreach (Combinacion combo in combinacionesDesbloqueadas)
        {

            if (combo.nombre == lecheResultado.nombre)
            {
                lotengo = true;
            }

        }
        if (lotengo == false)
            combinacionesDesbloqueadas.Add(lecheResultado);

        cuerpoVaca.sprite = cuerpos[combinacionesDesbloqueadas.Count / 4];
        fondoVaca.sprite = fondos[combinacionesDesbloqueadas.Count / 4];
    }

}

        

        
    
  

    





