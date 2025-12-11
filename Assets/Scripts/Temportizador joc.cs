using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TemporitzadorJoc : MonoBehaviour
{
    public Light llumLlanterna;          // Llum de la llanterna
    public TextMeshProUGUI textHora;                // Text que mostra l'hora actual
    public AudioSource soCampana;        // So de la campana

    private float tempsTotal = 0f;
    public float duracioJoc = 30f * 60f;   // 30 minuts en segons

    void Update()
    {
        tempsTotal += Time.deltaTime;

        // 1. ACABAR EL JOC ALS 30 MINUTS
        if (tempsTotal >= duracioJoc)
        {
            SceneManager.LoadScene("Fi");
              Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        }

        // 2. CANVI PROGRESSIU DE LA LLUM (de blanc a vermell en 28 minuts)
        float t = Mathf.Clamp01(tempsTotal / (5f * 60f));
        llumLlanterna.color = Color.Lerp(Color.white, Color.red, t);

        // 3. CANVI D’HORA CADA 5 MINUTS
        int horaActual = Mathf.FloorToInt(tempsTotal / (1 * 60));
        horaActual = Mathf.Clamp(horaActual, 0, 6); // De 0 A.M a 6 A.M
        textHora.text = horaActual + " A.M";

        // 4. FER SONAR LA CAMPANA CADA 5 MINUTS
        if (Mathf.Abs((tempsTotal % (1 * 60)) - 0) < Time.deltaTime)
        {
            soCampana.Play();
        }
    }
}
