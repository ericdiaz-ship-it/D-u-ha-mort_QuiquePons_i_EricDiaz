using UnityEngine;

public class Cadenat : MonoBehaviour, IInteractuable
{
    public GameObject panel;
  private bool isActive = false;
    public void Interactuar()
    {
        ObrirPanel();
    }
    void Update()
    {
        // Cerrar el panel si está activo y se presiona Enter
        if (isActive && Input.GetKeyDown(KeyCode.Return))
        {
            TancarPanel();
        }
    }
    private void ObrirPanel()
    {
        panel.SetActive(true);
        isActive = true;
    }

    private void TancarPanel()
    {
        panel.SetActive(false);
        isActive = false;
    }
}
