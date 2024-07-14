using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[CreateAssetMenu(fileName = "Nueva_Combinacion", menuName = "Combinacion")]
public class Combinacion : ScriptableObject
{
    public string nombre;
    public int nIngredientes;
    public Ingrediente ingrediente1;
    public Ingrediente ingrediente2;
    public Ingrediente ingrediente3;
    public string descripcion;
    public string pista;
    public Sprite sprite;
    public Sprite spriteBlocked;

}
