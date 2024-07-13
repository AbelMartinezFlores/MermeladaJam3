using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[CreateAssetMenu(fileName = "Nueva_Combinacion", menuName = "Combinacion")]
public class Combinacion : ScriptableObject
{
    public string nombre;
    public int nIngredientes;
    public string ingrediente1;
    public string ingrediente2;
    public string ingrediente3;
    public string descripcion;
    public string pista;
    public Sprite sprite;

}
