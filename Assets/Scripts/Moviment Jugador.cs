using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimentJugador : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = transform.right * horizontal + transform.forward * vertical;
        controller.Move(direction * speed * Time.deltaTime);
    }
     private void OnTriggerEnter(Collider objecteTocat)
    {
        if (objecteTocat.tag == "Finish")
        {
            SceneManager.LoadScene("Fi"); 
              Cursor.lockState = CursorLockMode.None;
        }
    }
}
