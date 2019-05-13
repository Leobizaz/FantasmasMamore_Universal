using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneLookControl : MonoBehaviour
{
    CharacterController player;

    public GameObject WideIn;
    public GameObject WideOut;
    public GameObject Eyes;
    bool beliche = false;
    bool trem = false;
    Vector3 to = new Vector3(0, 0, 0);
    Vector3 to2 = new Vector3(0, 90, 0);
    Vector3 Tr = new Vector3(0, 90, 0);
    Vector3 Tr2 = new Vector3(0, 0, 10);
    void Start()
    {
        player = this.GetComponent<CharacterController>();
    }

    void Update()
    {
        if (beliche == true)
        {
            Eyes.transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime * 0.01f);
            transform.eulerAngles = to2;
                //Vector3.Lerp(transform.rotation.eulerAngles, to2, Time.deltaTime * 1.5f);
            Invoke("Desativa", 2f);
        }
        if (trem == true)
        {
            //player.enabled = false;
            transform.eulerAngles = Tr;
                //Vector3.Lerp(transform.rotation.eulerAngles, Tr, Time.deltaTime);
            Eyes.transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, Tr2, Time.deltaTime * 0.01f);
            Invoke("Desativa", 4f);
        }

    }

    void TransformBeliche()
    {
        player.enabled = false;
        beliche = true;
        transform.position = new Vector3(11.021f, 51.45f, 31.814f);
        player.enabled = true;


    }

    void TransformTrem()
    {
        player.enabled = false;
        trem = true;
        transform.position = new Vector3(21.34923f, 51.58f, 28.34f);
        player.enabled = true;
    }

    void TransformLedge()
    {
        player.enabled = false;
        transform.position = new Vector3(261, 66, 321);
        transform.rotation = Quaternion.Euler(0, -91, 0);
        //Eyes.transform.eulerAngles = new Vector3(0, 0, 0);
        player.enabled = true;
    }

    void WideScreenIn()
    {
        WideIn.SetActive(true);
    }

    void WideScreenOut()
    {
        WideOut.SetActive(true);
    }
    public void WideScreenInF()
    {
        WideIn.SetActive(false);
    }

    public void WideScreenOutF()
    {
        WideOut.SetActive(false);
    }

    void Desativa()
    {
        beliche = false;
        trem = false;
        player.enabled = true;
    }
}
