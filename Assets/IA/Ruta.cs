using UnityEngine;
using System.Collections;

[System.Serializable]
public class Ruta
{
    public string nombre;
    public Transform[] puntos;
    public int[] orden;
    public bool loop;
}
