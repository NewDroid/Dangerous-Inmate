using UnityEngine;
using System.Collections.Generic;

public class Rutas : MonoBehaviour
{
    public List<Ruta> rutas;
    [HideInInspector]public List<Vector3> pos = new List<Vector3>();

    void OnDrawGizmos()
    {
        for(int ruta = 0; ruta < rutas.Capacity; ruta++)
        {
            for (int num = 0; num < rutas[ruta].orden.Length; num++)
            {
                pos.Insert(num, rutas[ruta].puntos[rutas[ruta].orden[num]].position);
            }


            for (int num = 1; num < rutas[ruta].orden.Length; num++)
            {
                Gizmos.DrawLine(pos[num - 1], pos[num]);
            }

            if (rutas[ruta].loop)
            {
                Gizmos.DrawLine(pos[0], pos[rutas[ruta].orden.Length - 1]);
            }
            pos.Clear();
        }
        
    }
}
