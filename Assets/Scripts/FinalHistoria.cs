using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class FinalHistoria : MonoBehaviour
{
    public TextMeshProUGUI textoUI;
    public float velocidadEscritura = 0.03f;
    public string escenaFinal = "Menu";  // Escena a carregar després

    private int indice = 0;
    private bool mostrando = false;

    private string[] frases = new string[]
    {
        "Vaig posar-ho tot a l’altar.",
        "Per fi aquell malson acabaria.",
        "Tornaria a escapar, amb el cor trencat.",
        "Però viva.",

        "La meva germana era morta.",
        "I no només morta, sinó també posseïda.",
        "I jo no hi podia fer res.",

        "Abans de marxar, em va agafar del braç.",
        "En aquell moment vaig entendre què em demanava des del principi.",
        "Els seus llavis murmuraven sense parar: “Ajuda’m”.",

        "Vaig agafar el crucifix.",
        "El mateix que la va “matar”.",
        "I vaig començar a resar.",

        "El seu cos es va començar a contorsionar.",
        "Cridava sense descans.",
        "Fins que, al cap d’uns minuts, silenci.",

        "El cos va caure a terra.",
        "Per fi descansava en pau.",

        "Vaig sortir de l’església.",
        "Amb el cos de la meva germana.",
        "Amb tots els records.",

        "El pati, jugant amb ella.",
        "Les pregàries que acabaven sempre amb rialles.",
        "Com va començar tot, amb aquell llibre.",
        "L’ombra que la seguia constantment.",
        "La calma abans de la tempesta.",
        "I el final de la meva germana.",

        "Em vaig girar.",
        "Vaig encendre l’encenedor i el vaig deixar caure.",
        "Les flames van devorar l’església.",
        "I la meva infantesa amb ella.",

        "A fora, vaig enterrar el cos de la meva germana.",
        "Vaig plorar.",
        "Tot el que no havia plorat mentre l’esperava viva.",

        "Quina fantasia, oi?",

        "I vaig marxar.",
        "Per sempre."
    };

    void Start()
    {
        // No escriu res en iniciar
        textoUI.text = "";
    }

    // 👉 Aquest mètode l’activa el puzzle final
    public void IniciarHistoria()
    {
        indice = 0;
        textoUI.text = "";
        gameObject.SetActive(true);
    }

    void Update()
    {
        // Saltar tota la història amb ESPAI
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopAllCoroutines();
            textoUI.text = "";
            FinalitzarHistoria();
        }

        // Avançar amb ENTER
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!mostrando)
            {
                if (indice < frases.Length)
                {
                    StartCoroutine(MostrarTexto(frases[indice]));
                    indice++;
                }
                else
                {
                    StartCoroutine(SortirIntro());
                }
            }
        }
    }

    IEnumerator MostrarTexto(string frase)
    {
        mostrando = true;
        textoUI.text = "";

        foreach (char lletra in frase)
        {
            textoUI.text += lletra;
            yield return new WaitForSeconds(velocidadEscritura);
        }

        mostrando = false;
    }

    IEnumerator SortirIntro()
    {
        yield return new WaitForSeconds(0.5f);
        FinalitzarHistoria();
    }

    void FinalitzarHistoria()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(escenaFinal);
    }
}
