using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Nuevo_Ingrediente",menuName ="Ingrediente")]
public class Ingrediente : ScriptableObject
{
    public string nombre;
    public int valor;
    public Sprite sprite;

}
