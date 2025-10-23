using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambiescena : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void canviarInici(){
    SceneManager.LoadScene("Inici");    
}
public void Exit(){
    Application.Quit();
}
}
