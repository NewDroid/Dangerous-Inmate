using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

    public Rutas scriptRutas;
    public string rutaInicial;
    public float velocidad;

    protected bool EnRuta;

    protected int puntoActual;

    protected Ruta rutaSeleccionada;
    protected bool rutaEncontrada;
    protected float mag;
    protected Vector3 vectorRecorrido, vectorNormalizado;
    [Range(0.1f, 2f)]public float damping;
    protected Transform objetivoARotar;

    [Range(0.01f, 0.5f)]public float margenEngancharse;

    protected virtual void Start()
    {
        if(rutaInicial != "")
        Engancharse(rutaInicial, 0);
    }

    protected virtual void RutaTerminada(string ruta)
    {
        switch (ruta)
        {
            default:
                Debug.LogError("Ruta terminada erronea");
                break;
            case "prueba":
                Engancharse("ano", 1);
                break;
        }
    }

    protected virtual void IrAPunto(Vector3 punto)
    {
        vectorRecorrido = punto - transform.position;
	Debug.Log("Lol");
        mag = Mathf.Sqrt(vectorRecorrido.x * vectorRecorrido.x + vectorRecorrido.y * vectorRecorrido.y + vectorRecorrido.z * vectorRecorrido.z);
        vectorNormalizado = vectorRecorrido / mag;
        GetComponent<Rigidbody>().velocity = vectorNormalizado * velocidad;

        EnRuta = true;
    }

    public virtual void Engancharse(string nombreRuta, int puntoParaEngancharse)
    {
        foreach(Ruta ruta in scriptRutas.rutas)
        {
            if(ruta.nombre == nombreRuta)
            {
                rutaSeleccionada = ruta;
                rutaEncontrada = true;
            }
        }
        if (!rutaEncontrada)
        {
            Debug.LogError("Ruta con nombre " + nombreRuta + " no encontrada");
        }
        rutaEncontrada = false;
        puntoActual = puntoParaEngancharse;

        IrAPunto(rutaSeleccionada.puntos[rutaSeleccionada.orden[puntoActual]].position);
        //transform.LookAt(rutaSeleccionada.puntos[rutaSeleccionada.orden[puntoActual]]);
        Rotar(rutaSeleccionada.puntos[rutaSeleccionada.orden[puntoActual]]);
    }

    protected virtual void Update ()
    {

        if (EnRuta && Vector3.Distance(transform.position, rutaSeleccionada.puntos[rutaSeleccionada.orden[puntoActual]].position) < margenEngancharse)
        {
            Debug.Log("Punto " + puntoActual + " alcanzado");
            if(puntoActual < rutaSeleccionada.orden.Length - 1)
            {
                puntoActual++;
                IrAPunto(rutaSeleccionada.puntos[rutaSeleccionada.orden[puntoActual]].position);
                //transform.LookAt(rutaSeleccionada.puntos[rutaSeleccionada.orden[puntoActual]]);
                Rotar(rutaSeleccionada.puntos[rutaSeleccionada.orden[puntoActual]]);
            }
            else
            {
                if (rutaSeleccionada.loop)
                {
                    puntoActual = 0;
                    IrAPunto(rutaSeleccionada.puntos[rutaSeleccionada.orden[puntoActual]].position);
                    //transform.LookAt(rutaSeleccionada.puntos[rutaSeleccionada.orden[puntoActual]]);
                    Rotar(rutaSeleccionada.puntos[rutaSeleccionada.orden[puntoActual]]);
                }
                else
                { 
                    Debug.Log("Ruta Terminada");
                    puntoActual = 0;
                    EnRuta = false;
                    GetComponent<Rigidbody>().velocity = Vector3.zero;
                    RutaTerminada(rutaSeleccionada.nombre);
                }
            }
        }
        if (objetivoARotar != null)
        {
            Quaternion rotacion = Quaternion.LookRotation(objetivoARotar.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacion, Time.deltaTime / damping);
        }
    }

    protected virtual void Rotar(Transform punto)
    {
        objetivoARotar = punto;
    }
}

