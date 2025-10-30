using UnityEngine;
using TMPro;
using System.Collections;

public class IntroHistoria : MonoBehaviour
{
    public TextMeshProUGUI textoUI;

    public float velocidadEscritura = 0.03f;

    private int indice = 0;
    private bool mostrando = false;

    private string[] frases = new string[]
    {
        "Déu ha mort.",
        "Van ser les últimes paraules que va dir la meva germana abans de clavar-se el crucifix.",
        "El gabinet sagrat va travessar el seu pit com si fos paper.",
        "Jo vaig quedar paralitzada, mirant com la sang tacava l’altar.",
        "No vaig poder moure’m. No vaig poder cridar.",
        "Anàvem a escapar. Ho teníem tot planejat.",
        "Però ella... va decidir quedar-s’hi.",
        "Vaig córrer sense mirar enrere.",
        "Ara, anys després, torno.",
        "Torno a l’església de l’Eterna Vigília.",
        "Torno per buscar respostes.",
        "Torno per trobar-la.",
        "Torno per acabar el que ella va començar."
    };

    void Start()
    {
        textoUI.text = "";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Enter o Return
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
                    StartCoroutine(SalirDeIntro());
                }
            }
        }
    }

    IEnumerator MostrarTexto(string frase)
    {
        mostrando = true;
        textoUI.text = "";

        foreach (char letra in frase.ToCharArray())
        {
            textoUI.text += letra;
            yield return new WaitForSeconds(velocidadEscritura);
        }

        mostrando = false;
    }

    IEnumerator SalirDeIntro()
    {
    
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);

    }
}
