using UnityEngine;
using UnityEngine.UI;

public class Selected : MonoBehaviour
{
    LayerMask mask;
    public float distance = 1.5f;
    public Texture2D punter;
    public GameObject TextDetect;
    GameObject ultimObjecte = null;
    void Start()
    {
        mask = LayerMask.GetMask("RaycastDetect");
        TextDetect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, mask))
        {
            DeselectedObject();
            SelectedObject(hit.transform);
            if (hit.collider.tag == "ObjecteInteractiu")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.GetComponent<ObjetoInteractuar>().ActivarObjeto();
                }
            }
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
        }else
        {
            DeselectedObject();
        }

    }
    void SelectedObject(Transform transform)
    {
        transform.GetComponent<MeshRenderer>().material.color = Color.red;
        ultimObjecte = transform.gameObject;
    }
    void DeselectedObject()
    {
        if (ultimObjecte)
        {
            ultimObjecte.GetComponent<MeshRenderer>().material.color = Color.white;
            ultimObjecte = null;
        }

    }
     void OnGUI()
    {
        Rect punterPos = new Rect(Screen.width / 2 , Screen.height / 2 , punter.width, punter.height   );
        GUI.DrawTexture(punterPos, punter);
        if (ultimObjecte)
        {
            TextDetect.SetActive(true);
        }
        else
        {
            TextDetect.SetActive(false);
        }
    }
}
