using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Presidiario : NPC {
    public Stats stats;

    // Use this for initialization
    protected override void Start ()
    {
        base.Start();
        CrearPresidiario();
	}
	
    public void CrearPresidiario()
    {
        stats.defensa = Random.Range(0, 50);

        stats.fuerza = Random.Range(10, 25);

        stats.irritabilidad = Random.Range(0, 100);
        stats.amigabilidad = Random.Range(0, 100);
    }

    // Update is called once per frame
    protected override void Update ()
    {
        base.Update();

        
	}

    [System.Serializable]
    public class Stats
    {
        public int defensa;

        public int fuerza;


        public int irritabilidad;
        public int amigabilidad;
    }
}
