using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Teta : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextAsset RutaTablaCombinaciones;

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

    public void mezclarLeche(Ingrediente primero ,Ingrediente segundo, Ingrediente tercero)
    {

    }

    

    public void leerCombinaciones()
    {
        //TextAsset csv = Resources.Load<TextAsset>(RutaTablaCombinaciones);

        if (RutaTablaCombinaciones == null)
        {
            Debug.Log("no hay nadaaaaa errrrooooor");
        }

        string[] texto = RutaTablaCombinaciones.text.Split("\n");
        
        for(int i = 0; i < texto.Length; i += 1)
        {
            Debug.Log(texto[i]);
        }
    }
}
