using UnityEngine;

public class Atril : MonoBehaviour, IInteractuable
{
    public GameObject uiCandau;

    public void Interactuar()
    {
        uiCandau.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
