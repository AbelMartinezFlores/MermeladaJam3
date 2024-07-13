using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Nuevo Ingrediente", menuName = "Nuevo Ingrediente")]
public class Ingrediente : ScriptableObject
{
    public string nombre;
    public int dinero;
    public string descripcion;
    public Sprite imagen;
}
