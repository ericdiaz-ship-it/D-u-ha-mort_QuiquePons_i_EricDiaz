using UnityEngine;

public class GestorJumpscare : MonoBehaviour
{
    public Transform jugador;
    public Transform monstre;
    public AudioSource soJumpscare;
    public Light llumEscena;
    public Camera cameraJugador;

    public float tempsMinim = 600f;  // 10 minuts
    public float duradaJoc = 1800f; // 30 minuts
    public float cooldownSusto = 90f; // per a que passi molt de tant en tant

    private float properSusto = 0f;
    private bool estaSust = false;

    void Start()
    {
        properSusto = tempsMinim;
    }

    void Update()
    {
        float t = Time.time;

        if (t > duradaJoc) return; // fi del joc
        if (t < tempsMinim) return; // encara no pot passar

        if (!estaSust && t >= properSusto)
        {
            float probabilitat = Random.value;
            if (probabilitat < 0.15f)  // 15% de probabilitat → molt poc freqüent
            {
                StartCoroutine(FerJumpscare());
            }
            properSusto = t + cooldownSusto;
        }
    }

    private System.Collections.IEnumerator FerJumpscare()
    {
        estaSust = true;

        // 1) Col·locar el monstre a prop del jugador
        Vector3 offset = Random.insideUnitSphere * 2f;
        offset.y = 0;
        monstre.position = jugador.position + offset;
        monstre.gameObject.SetActive(true);

        // 2) So
        if (soJumpscare != null)
            soJumpscare.Play();

        // 3) Llum negra parpellejant
        for (int i = 0; i < 10; i++)
        {
            llumEscena.intensity = 0;
            yield return new WaitForSeconds(0.05f);
            llumEscena.intensity = 1;
            yield return new WaitForSeconds(0.05f);
        }

        // 4) La càmera mira el monstre
        Vector3 direccio = (monstre.position - cameraJugador.transform.position).normalized;
        Quaternion rotacioObjectiu = Quaternion.LookRotation(direccio);
        cameraJugador.transform.rotation = rotacioObjectiu;

        // 5) Esperar abans de restaurar
        yield return new WaitForSeconds(0.8f);

        // 6) Tot torna excepte la càmera
        monstre.gameObject.SetActive(false);

        estaSust = false;
    }
}
