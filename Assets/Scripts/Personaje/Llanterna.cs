using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Light))]
public class llanterna : MonoBehaviour
{
    [Header("Seguiment")]
    public Transform camaraJugador;               // càmera del jugador
    public bool ferFillaDeLaCamara = true;        
    public Vector3 offsetPosicio = new Vector3(0f, -0.1f, 0.2f); 
    public Vector3 offsetRotacio = Vector3.zero;  
    public bool seguirRotacio = true;             

    [Header("Parpelleig")]
    public bool activarParpelleig = true;         // activar/desactivar l’efecte
    public float tempsMinEntreParpelleigs = 8f;   // temps mínim entre episodis
    public float tempsMaxEntreParpelleigs = 20f;  // temps màxim entre episodis
    public int minImpulsos = 2;                   // mínim d’impulsos dins un episodi
    public int maxImpulsos = 6;                   // màxim d’impulsos dins un episodi
    public float minDuradaImpuls = 0.03f;         // durada mínima de cada impuls
    public float maxDuradaImpuls = 0.3f;          // durada màxima de cada impuls
    public float minFactorIntensitat = 0f;        // 0 = s’apaga completament
    public float maxFactorIntensitat = 0.8f;      // percentatge de la intensitat base
    public bool efecteSuau = true;                // suavitzar el canvi d’intensitat
    public float tempsSuavitzat = 0.05f;          // temps de suavitzat

    private Light llum;                            // referència al component Light
    private float intensitatBase;                 

    void Awake()
    {
        llum = GetComponent<Light>();             // agafa el component Light

        if (llum == null)
        {
            enabled = false;
            return;
        }

        intensitatBase = llum.intensity;          // guarda la intensitat original

        if (camaraJugador == null && Camera.main != null)
            camaraJugador = Camera.main.transform;
    }

    void Start()
    {
        
        if (camaraJugador != null && ferFillaDeLaCamara)
        {
            transform.SetParent(camaraJugador, false);     // fer-la filla
            transform.localPosition = offsetPosicio;        // posició local
            transform.localEulerAngles = offsetRotacio;     // rotació local
        }

        // Iniciar el parpelleig automàtic
        if (activarParpelleig)
            StartCoroutine(Parpelleig());
    }

    void LateUpdate()
    {
        // Si no hi ha càmera o ja és filla, no cal fer res aquí
        if (camaraJugador == null || ferFillaDeLaCamara)
            return;

        // Manté la llanterna davant de la càmera
        transform.position = camaraJugador.position + camaraJugador.TransformDirection(offsetPosicio);

        // Segueix la rotació de la càmera si està activat
        if (seguirRotacio)
            transform.rotation = camaraJugador.rotation * Quaternion.Euler(offsetRotacio);
    }

    IEnumerator Parpelleig()
    {
        // Bucle infinit que crea episodis de parpelleig de forma aleatòria
        while (true)
        {
            // Espera un temps aleatori
            float espera = Random.Range(tempsMinEntreParpelleigs, tempsMaxEntreParpelleigs);
            yield return new WaitForSeconds(espera);

            // Quants impulsos hi haurà en aquest episodi
            int impulsos = Random.Range(minImpulsos, maxImpulsos + 1);

            for (int i = 0; i < impulsos; i++)
            {
                // Intensitat i durada aleatòries
                float factor = Random.Range(minFactorIntensitat, maxFactorIntensitat);
                float durada = Random.Range(minDuradaImpuls, maxDuradaImpuls);

                // Si volem un efecte suau, interpolar la intensitat
                if (efecteSuau)
                {
                    float inici = llum.intensity;
                    float desti = intensitatBase * factor;
                    float temps = 0f;

                    while (temps < durada)
                    {
                        temps += Time.deltaTime;
                        llum.intensity = Mathf.Lerp(inici, desti, temps / durada);
                        yield return null;
                    }
                }
                else
                {
                    // Canvi directe sense suavitzat
                    llum.intensity = intensitatBase * factor;
                    yield return new WaitForSeconds(durada);
                }

                // Tornar a la intensitat base
                float t = 0f;
                float inici2 = llum.intensity;

                while (t < tempsSuavitzat)
                {
                    t += Time.deltaTime;
                    llum.intensity = Mathf.Lerp(inici2, intensitatBase, t / tempsSuavitzat);
                    yield return null;
                }

                // Petit retard entre impulsos
                yield return new WaitForSeconds(Random.Range(0.02f, 0.25f));
            }

            // Assegura la intensitat base al final de l’episodi
            llum.intensity = intensitatBase;
        }
    }

    void Update()
    {
   
    }

    // Funció pública per forçar un parpelleig manual (des d'un altre script)
    public void ParpelleigManual()
    {
        if (activarParpelleig)
            StartCoroutine(ParpelleigRapid());
    }

    IEnumerator ParpelleigRapid()
    {
        // Petit parpelleig ràpid manual
        int impulsos = Random.Range(1, 4);

        for (int i = 0; i < impulsos; i++)
        {
            float factor = Random.Range(minFactorIntensitat, maxFactorIntensitat);
            float durada = Random.Range(minDuradaImpuls, maxDuradaImpuls);

            float inici = llum.intensity;
            float desti = intensitatBase * factor;
            float temps = 0f;

            while (temps < durada)
            {
                temps += Time.deltaTime;
                llum.intensity = Mathf.Lerp(inici, desti, temps / durada);
                yield return null;
            }

            temps = 0f;

            while (temps < tempsSuavitzat)
            {
                temps += Time.deltaTime;
                llum.intensity = Mathf.Lerp(desti, intensitatBase, temps / tempsSuavitzat);
                yield return null;
            }
        }

        llum.intensity = intensitatBase;
    }
}
