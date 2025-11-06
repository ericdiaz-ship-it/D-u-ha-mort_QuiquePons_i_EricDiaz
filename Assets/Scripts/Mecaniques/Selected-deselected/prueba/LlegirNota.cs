using UnityEngine;
using TMPro; // Necesario para TextMeshPro

public class LlegirNota : MonoBehaviour, IInteractuable
{
    [Header("UI del texto")]
    public GameObject panel;   // Panel del Canvas que contiene el texto
    public TMP_Text textBox;   // Componente TextMeshPro dentro del panel

    private bool isActive = false;

    private string story = "Hoy el padre me ha pedido que ordene la biblioteca.\n" +
                           "Hay libros que no deberían estar aquí, no, no deberían… uno me miró. Tenía un número.\n" +
                           "Sí, un número… pero al mirarlo al revés, algo gritó dentro de mí.\n" +
                           "Las sombras se estiran, se enroscan entre los estantes. Susurran.\n" +
                           "Susurran mi nombre, mis pensamientos… la palabra vive en el número de la bestia invertido.\n" +
                           "Lo digo en voz baja, pero todavía me escuchan. Todavía lo saben.\n" +
                           "Sigo el hilo… no sé por qué sigo el hilo. Si lo sigo, encontraré algo.\n" +
                           "Algo que no estaba destinado a ser encontrado. Y me temo que ya me está mirando.";

    void Update()
    {
        // Cerrar el panel si está activo y se presiona Enter
        if (isActive && Input.GetKeyDown(KeyCode.Return))
        {
            TancarPanel();
        }
    }

    public void Interactuar()
    {
        ObrirPanel();
    }

    private void ObrirPanel()
    {
        panel.SetActive(true);
        textBox.text = story; // Aquí usamos TMP_Text
        isActive = true;
    }

    private void TancarPanel()
    {
        panel.SetActive(false);
        isActive = false;
    }
}
