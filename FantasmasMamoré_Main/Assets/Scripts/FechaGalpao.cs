using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FechaGalpao : MonoBehaviour
{

    public GameObject porta;
    private AudioSource Au;
    public AudioClip inpact;
    public GameObject E;
    // Start is called before the first frame update
    void Start()
    {
         Au = porta.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            porta.transform.rotation = Quaternion.Euler(0, 84.815f, 0);
            //E.SetActive(true);
            Au.PlayOneShot(inpact, 0.4f);
            Invoke("Cu", 6f);
            //Destroy(this.gameObject);
                
        }
    }

    void Cu()
    {
        E.SetActive(true);
        Destroy(this.gameObject);
    }
}
