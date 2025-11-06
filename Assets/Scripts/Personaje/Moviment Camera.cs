using UnityEngine;

public class MovimentCamera : MonoBehaviour
{
    public float velocity = 100f;
    float Rotacionx = 0f;
    public Transform Jugador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * velocity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * velocity * Time.deltaTime;
        Rotacionx -= mouseY;
        Rotacionx = Mathf.Clamp(Rotacionx, -90f, 90f);
        transform.localRotation = Quaternion.Euler(Rotacionx, 0f, 0f);
        Jugador.Rotate(Vector3.up * mouseX);
    }
}
