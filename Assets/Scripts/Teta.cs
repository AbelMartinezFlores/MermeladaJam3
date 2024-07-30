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
    [SerializeField] private TextAsset csvRelaciones;
    private List<Tupla> IngreCombos = new List<Tupla>();
    [SerializeField] private List<Combinacion> combolist;
    [SerializeField] private Combinacion lecheMala;

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
    public Combinacion mezclarLeche(Ingrediente primero, Ingrediente segundo, Ingrediente tercero)
    {

        if (primero == null)
            primero = ScriptableObject.CreateInstance<Ingrediente>();
        if (segundo == null)
            segundo = ScriptableObject.CreateInstance<Ingrediente>();
        if (tercero == null)
            tercero = ScriptableObject.CreateInstance<Ingrediente>();
        //Debug.Log("A VER LA TUPLA DE COMBOS");
        //Debug.Log(IngreCombos.Count);


        int id1 = -1, id2 = -1, id3 = -1, coincidencias = 0;
       // int lecheFinal;
        for (int i = 0; i < IngreCombos.Count; i += 1)
        {
            //RECUPERAMOS LOS ID DE LOS INGREDIENTES
           
            
                Tupla auxt = IngreCombos[i];

            //Debug.Log("A VER LOS NOMBRES");
            if (primero != null && id1 != -1) { }
           // Debug.Log(primero.nombre);
            if (segundo != null && id2 != -1) { }
            //Debug.Log(segundo.nombre);
            if (tercero != null  && id2 != -1) { }
            //Debug.Log(tercero.nombre );
           // Debug.Log(auxt.nombre);
           // Debug.Log("--------------------------");

            if (primero != null &&primero.nombre == auxt.nombre)
                    id1 = i;
            if (segundo != null && segundo.nombre == auxt.nombre)
                    id2 = i;
           if (tercero!= null && tercero.nombre == auxt.nombre)
                    id3 = i;
            

        }
        //Debug.Log(id1);
        // Debug.Log(id2);
        // Debug.Log(id3);

        /*
        Debug.Log("COMBOS DE EL SEGUNDO");
        for (int i=0; i<IngreCombos[id2].combos.Count; i++)
        {

            Debug.Log(IngreCombos[id2].combos[i]);
        }

        Debug.Log("COMBOS DEL TERCERO");
        Debug.Log(IngreCombos[id3].combos.Count);
        for (int i = 0; i < IngreCombos[id3].combos.Count; i++)
        {

            Debug.Log(IngreCombos[id3].combos[i]);
        }*/
        //comprobamos todas las posibilidades (debería haber hecho un buclecillo)
        // Debug.Log("cantidad de combos de el Ingrediente 1");
        //Debug.Log(IngreCombos[id1].combos.Count);
        if (id1 > -1 && id2 > -1 && IngreCombos[id1].combos[id2] == 1)
        {
            coincidencias++;
        }
        else if (id1 > -1 && id2 > -1 && IngreCombos[id1].combos[id2] == -1)
        {
            coincidencias = -5;
            Debug.Log("mal");
        }
        if (id1 > -1 && id3 > -1 && IngreCombos[id1].combos[id3] == 1)
        {
            coincidencias++;
        }
        else if (id1 > -1 && id3 > -1 && IngreCombos[id1].combos[id3] == -1)
        {
            coincidencias = -5;
            Debug.Log("mal");
        }
        if (id2 > -1 && id3 > -1 && IngreCombos[id2].combos[id3] == 1)
        {
            coincidencias++;
        }
        else if (id2 > -1 && id3 > -1 && IngreCombos[id2].combos[id3] == -1)
        {
            coincidencias = -5;
            Debug.Log("mal");
       
        }

        Debug.Log("A MEZCLAR");
        Debug.Log(coincidencias);
        //ahora a ver que hacemos para obtener los combos jijijijijijijiji
        if (coincidencias <= 0)
        {
            //devolver leche agria 
            Debug.Log("LECHE MALAAAAAAAAAAAAAAAAAAAAAAAAA");
            return lecheMala;
        }
        else if (coincidencias == 3) {
            Debug.Log("LECHE TRIPLE");
            foreach (Combinacion combo in combolist)
            {
                if (primero.nombre == combo.ingrediente1.nombre || primero.nombre == combo.ingrediente2.nombre || primero.nombre == combo.ingrediente3.nombre)
                {
                    if (segundo.nombre == combo.ingrediente1.nombre || segundo.nombre == combo.ingrediente2.nombre || segundo.nombre == combo.ingrediente3.nombre)
                    {
                        if (tercero.nombre == combo.ingrediente1.nombre || tercero.nombre == combo.ingrediente2.nombre || tercero.nombre == combo.ingrediente3.nombre)
                        {
                            //devolver el combo en cuestion
                            Debug.Log(combo.nombre);
                            return combo;
                        }
                    }
                }

            }

        }
        else if(coincidencias <3)
        {
            Debug.Log("LECHE DOBLE");
            foreach (Combinacion combo in combolist)
            {
                if (combo.nIngredientes < 3)
                {
                    /*if(primero.nombre== segundo.nombre)
                    {
                        return lechenormal
                    }*/
                    
                    if (primero.nombre == combo.ingrediente1.nombre || primero.nombre == combo.ingrediente2.nombre || primero.nombre == combo.ingrediente3.nombre)
                    {

                        if (segundo.nombre == combo.ingrediente1.nombre || segundo.nombre == combo.ingrediente2.nombre || segundo.nombre == combo.ingrediente3.nombre)
                        {
                            Debug.Log(combo.nombre);
                            return combo;
                        }
                    }

                    if (primero.nombre == combo.ingrediente1.nombre || primero.nombre == combo.ingrediente2.nombre || primero.nombre == combo.ingrediente3.nombre)
                    {
                        if (tercero.nombre == combo.ingrediente1.nombre || tercero.nombre == combo.ingrediente2.nombre || tercero.nombre == combo.ingrediente3.nombre)
                        {
                            Debug.Log(combo.nombre);
                            return combo;
                        }
                    }

                    if (segundo.nombre == combo.ingrediente1.nombre || segundo.nombre == combo.ingrediente2.nombre || segundo.nombre == combo.ingrediente3.nombre)
                    {
                        if (tercero.nombre == combo.ingrediente1.nombre || tercero.nombre == combo.ingrediente2.nombre || tercero.nombre == combo.ingrediente3.nombre)
                        {
                            Debug.Log(combo.nombre);
                            return combo;
                        }
                    }

                    
                }
            }
        }


        return lecheMala;


    }




    

    
    //LEEMOS EL CSV PARA SACAR LAS COMBINACIONES DE CADA INGREDIENTE
    public void leerCombinaciones()
    {
    

        if (csvRelaciones == null)
        {
            Debug.Log("no hay nadaaaaa errrrooooor");
        }

        //SEPARAMOS LAS FILAS DEL CSV
        string[] filas = csvRelaciones.text.Split("\n");    

        //IGNORAMOS LA PRIMERA FILA QUE SOLO TIENE NOMBRES
        for (int i = 1; i < filas.Length; i += 1)
        {
            //Debug.Log(filas[i]);

            //SEPARAMOS CADA FILA POR COMAS PARA OBTENER LOS VALORES DE LAS CELDAS
            string[] ingres = filas[i].Split(",");
            List<int> combinaciones=new List<int>();

            //A PARTIR DE LA PRIMERA CELDA (0) TODAS SON VALORAS ASI QUE CREAMOS UNA LISTA DE INTS
           // Debug.Log("Cantidad de combos de este ingrediente");
           // Debug.Log(ingres.Length);

            for (int j=1; j < ingres.Length; j++)
            {
                combinaciones.Add(int.Parse(ingres[j]));
            }

            //CREAMOS UNA TUPLA QUE GUARDA SU NOMBRE, SU ID NUMÉRICO(la columna de la tabla) Y SUS COMBINACIONES
            Debug.Log("AÑADIMOS ELEMENTO A LA TUPLA");
            IngreCombos.Add(new Tupla(ingres[0], i-1,combinaciones));
            Debug.Log(IngreCombos[i - 1].nombre);
            Debug.Log(IngreCombos.Count);

        }
    }

 
}
