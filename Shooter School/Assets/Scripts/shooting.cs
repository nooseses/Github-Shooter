using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class shooting : MonoBehaviour
{
    public Camera cam;

    private RaycastHit hit;
    private Ray ray;

    public AudioSource sfx;
    public AudioClip audioClip;


    // Start is called before the first frame update
    void Start()
    {
        sfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            sfx.Play();
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {   
                if (hit.collider.tag.Equals("npc"))
                {
                    Debug.Log("you are dead");
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
