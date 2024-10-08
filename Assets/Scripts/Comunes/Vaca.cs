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

    [SerializeField] public Text textoDinero;
    [SerializeField] public Image cuerpoVaca;
    [SerializeField] public Image fondoVaca;
    [SerializeField] public List<Sprite> cuerpos;
    [SerializeField] public List<Sprite> fondos;

    private void Start()
    {
        textoDinero.text = dinero.ToString();
        tet = GetComponent<Teta>();
        tet.leerCombinaciones();
        ganado = false;
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
                
                bocadillo.transform.GetChild(i).gameObject.SetActive(true);
                bocadillo.transform.GetChild(i).gameObject.GetComponent<Image>().sprite = comida[i].sprite;
            }
            else
            {
                bocadillo.transform.GetChild(i).gameObject.SetActive(false);
            }
            
        }

        switch (comida.Count) {
            case 0: 
                bocadillo.transform.GetChild(0).gameObject.SetActive(false);
                goto case 1;
            case 1:
                bocadillo.transform.GetChild(1).gameObject.SetActive(false);
                goto case 2;
            case 2:
                bocadillo.transform.GetChild(2).gameObject.SetActive(false);
                break;
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

    }

    public bool getGanado()
    {
        return ganado;
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
        if (lotengo == false) AnyadirCombinaciones(lecheResultado);

        cuerpoVaca.sprite = cuerpos[combinacionesDesbloqueadas.Count / 4];
        fondoVaca.sprite = fondos[combinacionesDesbloqueadas.Count / 4];

        if(combinacionesDesbloqueadas.Count/4 >= 2)
        {

            cuerpo.GetComponent<RectTransform>().sizeDelta = new Vector2(cuerpo.GetComponent<RectTransform>().sizeDelta.x, 1090);
            cuerpo.GetComponent<RectTransform>().localPosition = new Vector3(0, 126.76f,0);
        }

    }

}

        

        
    
  

    





