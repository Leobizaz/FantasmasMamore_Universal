using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoPickup : MonoBehaviour
{
    public GameObject Tela;
    private AudioSource Audio;
    public int index;
    public Sprite photo;
    public GameObject dialogo;

    void Start()
    {
        Audio = Tela.GetComponent<AudioSource>();
    }

    //photo 1 = pesca
    //photo 2 = madeira?
    //photo 3 =
    //photo 4 =
    //photo 5 =

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            dialogo.SetActive(true);
            
            Tela.SetActive(true);
            Tela.transform.GetChild(0).GetComponent<Image>().sprite = photo;
            Audio.Play();
            Globals.photoscollected++;
            Destroy(gameObject);

            switch (index)
            {
                case 1:
                    Globals.photo1 = true;
                    break;

                case 2:
                    Globals.photo2 = true;
                    break;
                case 3:
                    Globals.photo3 = true;
                    break;
                case 4:
                    Globals.photo4 = true;
                    break;
                case 5:
                    Globals.photo5 = true;
                    break;
                case 6:
                    break;
            }
        }


    }
}
