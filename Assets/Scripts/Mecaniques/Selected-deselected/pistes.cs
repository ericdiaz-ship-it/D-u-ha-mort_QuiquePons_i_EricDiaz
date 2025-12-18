using UnityEngine;
using TMPro;

public class Pistes : MonoBehaviour, IInteractuable
{
    [Header("Referencias UI")]
    public GameObject panel;
    public TextMeshProUGUI textoTMP;

    [Header("Texto")]
    [TextArea]
    public string textoAMostrar;

    private bool panelAbierto = false;

    private void Start()
    {
        if (panel != null)
            panel.SetActive(false);
    }

    private void Update()
    {
        if (panelAbierto && Input.GetKeyDown(KeyCode.Return))
        {
            CerrarPanel();
        }
    }

    public void Interactuar()
    {
        if (panel != null)
        {
            panel.SetActive(true);
            panelAbierto = true;
        }

        if (textoTMP != null)
        {
            textoTMP.text = textoAMostrar;
        }
    }

    private void CerrarPanel()
    {
        if (panel != null)
            panel.SetActive(false);

        panelAbierto = false;
    }
}
