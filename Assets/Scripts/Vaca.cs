using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaca : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject cabeza;
    [SerializeField] private GameObject cuerpo;
    [SerializeField] public List<Ingrediente> comida;
    private Teta tet;


    private void Start()
    {
        tet = GetComponent<Teta>();
        tet.leerCombinaciones();
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

        

        if (Input.GetKeyUp(KeyCode.C))
        {
            while (comida.Count < 3)
            {
                Ingrediente aux = new Ingrediente();
                comida.Add(aux);//cambiar null por una comida que se llame nada o algo asi
            }
            //Debug.Log(comida.Count);
            tet.mezclarLeche(comida[0], comida[1], comida[2]);
            comida.Clear();
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    }





