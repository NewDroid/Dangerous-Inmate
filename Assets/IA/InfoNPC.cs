using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InfoNPC : MonoBehaviour {

    public Text textoFuerza, textoDefensa, textoIrritabilidad;
    public GameObject panelStats, panelGeneral, panelMisiones, panelTradeo;
    public GameObject panelActivo;

    public GameObject botones;

    Presidiario _presidiario;

    public void MostrarPanel(Presidiario presidiario)
    {
        _presidiario = presidiario;
        panelGeneral.SetActive(true);
        panelActivo = panelGeneral;
        botones.SetActive(true);
        Inicializar();
    }

    void Inicializar()
    {
        //Stats
        textoFuerza.text = _presidiario.stats.fuerza.ToString();

        textoDefensa.text = _presidiario.stats.defensa.ToString();

        textoIrritabilidad.text = _presidiario.stats.irritabilidad.ToString();

        //TODO Tradeo, todo el sistema y las variables.

        //TODO Pestaña inicial, diseño y funciones

        //TODO Misiones y randomización
    }

    public void CambiarSeccion(GameObject panelSeleccionado)
    {

        panelActivo.SetActive(false);

        panelActivo = panelSeleccionado;

        panelActivo.SetActive(true);
    }

    public void OcultarPanel()
    {
        panelActivo.SetActive(false);
        _presidiario = null;
        panelActivo = null;
        botones.SetActive(false);
    }
}
