using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nueva_receta", menuName = "Receta")]
public class Receta : ScriptableObject
{
    public string nombre;
    public string descripcion;
    public string pista;
    public int precio;
    public List<Ingrediente> ingredientes = new List<Ingrediente>();
    public Sprite imagenDesbloqueada;
    public Sprite imagenBloqueada;

}
