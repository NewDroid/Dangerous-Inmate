using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Personaje : MonoBehaviour {

    public KeyCode teclaNPC;
    public LayerMask NPCLayer;
    public Text pulsaTecla;
    public RectTransform crosshair;
    public InfoNPC infoNPC;
    Ray ray;
    RaycastHit hit;

    // Use this for initialization
    void Start ()
    {
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        ray = Camera.main.ScreenPointToRay(crosshair.position);

        if (infoNPC.panelActivo != null && Input.GetKeyDown(teclaNPC))
        {
            Cursor.visible = false;
            GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.XSensitivity = 2.0f;
            GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.YSensitivity = 2.0f;
            infoNPC.OcultarPanel();
            crosshair.gameObject.SetActive(true);
        }
        else
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, NPCLayer))
            {
                pulsaTecla.GetComponent<RectTransform>().anchoredPosition = new Vector2(58.4f, -207f);
                if (Input.GetKeyDown(teclaNPC))
                {
                    if (hit.transform.tag == "Presidiario")
                    {
                        Cursor.visible = true;
                        crosshair.gameObject.SetActive(false);
                        GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.XSensitivity = 0.0f;
                        GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.YSensitivity = 0.0f;
                        infoNPC.MostrarPanel(hit.collider.GetComponent<Presidiario>());
                    }
                }
            }
            else pulsaTecla.GetComponent<RectTransform>().anchoredPosition = new Vector2(500f, 500f);
        }
    }
}
