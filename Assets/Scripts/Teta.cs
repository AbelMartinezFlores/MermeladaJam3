using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Tupla
{
    public string nombre;
    public int id;
    public List<int> combos;
    public Tupla(string nom,int valor, List<int> comb)
    {
        nombre = nom;
        id = valor;
        combos = comb;
    }
}

public class Teta : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextAsset csvCombinaciones;
    private List<Tupla> IngreCombos = new List<Tupla>();

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            leerCombinaciones();
        }

    }

    //buscar los id correspondientes a los ingredientes para poder hacer busqueda directa en los arrays de combo
    public void mezclarLeche(Ingrediente primero, Ingrediente segundo, Ingrediente tercero)
    {
        int id1 = -1, id2 = -1, id3 = -1, coincidencias = 0;
        int lecheFinal;
        for (int i = 0; i < IngreCombos.Count; i += 1)
        {
            //RECUPERAMOS LOS ID DE LOS INGREDIENTES
            if (id1 > -1 && id2 > -1 && id3 > -1)
            {
                Tupla auxt = IngreCombos[i];
                if (primero.nombre == auxt.nombre)
                    id1 = i;
                else if (segundo.nombre == auxt.nombre)
                    id2 = i;
                else if (tercero.nombre == auxt.nombre)
                    id3 = i;
            }

        }

        if (IngreCombos[id1].combos[id2] == 1)
            coincidencias += 1;
        else if (IngreCombos[id1].combos[id2] == -1)
            coincidencias -= 5;
        if (IngreCombos[id1].combos[id3] == 1)
            coincidencias += 1;
        else if (IngreCombos[id1].combos[id2] == -1)
            coincidencias -= 5;
        if (IngreCombos[id2].combos[id3] == 1)
            coincidencias += 1;
        else if (IngreCombos[id1].combos[id2] == -1)
            coincidencias -= 5;


        //ahora a ver que hacemos para obtener los combos jijijijijijijiji

    }




    

    
    //LEEMOS EL CSV PARA SACAR LAS COMBINACIONES DE CADA INGREDIENTE
    public void leerCombinaciones()
    {
    

        if (csvCombinaciones == null)
        {
            Debug.Log("no hay nadaaaaa errrrooooor");
        }

        //SEPARAMOS LAS FILAS DEL CSV
        string[] filas = csvCombinaciones.text.Split("\n");    

        //IGNORAMOS LA PRIMERA FILA QUE SOLO TIENE NOMBRES
        for (int i = 1; i < filas.Length; i += 1)
        {
            Debug.Log(filas[i]);

            //SEPARAMOS CADA FILA POR COMAS PARA OBTENER LOS VALORES DE LAS CELDAS
            string[] ingres = filas[i].Split(",");
            List<int> combinaciones=new List<int>();

            //A PARTIR DE LA PRIMERA CELDA (0) TODAS SON VALORAS ASI QUE CREAMOS UNA LISTA DE INTS
            for(int j=1; j < ingres[i].Length; j++)
            {
                combinaciones.Add(int.Parse(ingres[j]));
            }

            //CREAMOS UNA TUPLA QUE GUARDA SU NOMBRE, SU ID NUMÉRICO(la columna de la tabla) Y SUS COMBINACIONES
            IngreCombos.Add(new Tupla(ingres[0], i-1,combinaciones));

        }
    }
}
