using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovScreenMenu : MonoBehaviour
{

    Animator anim;

    public Animator Title;
    public Animator TransitionGame;
    public Transform target;

    public GameObject music;
    public GameObject apito;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    public void MenuP()
    {
        anim.SetInteger("State", 0);
        Title.SetInteger("State", 0);
        target.transform.position = new Vector3(22.47f, 2.01f, 5f);

    }
    public void Options()
    {
        anim.SetInteger("State", 1);
        Title.SetInteger("State", 1);
        target.transform.position = new Vector3(22.47f, 2.01f, 1f);
    }
    public void Credits()
    {
        anim.SetInteger("State", 2);
        Title.SetInteger("State", 1);
        target.transform.position = new Vector3(13f, 2.01f, 15.41f);
    }

    public void Play()
    {
        anim.SetInteger("State", 3);
        Title.SetInteger("State", 1);
        TransitionGame.SetInteger("State", 1);
        target.transform.position = new Vector3(26.6f, 2.01f, 15.41f);
        music.SetActive(false);
        apito.SetActive(true);

        Invoke("LoadAct1", 4f);
    }

    // Start is called before the first frame update
    void Update()
    {
        transform.LookAt(target);


    }
    public void LoadAct1()
    {
        SceneManager.LoadScene("Tutorial");
        FPSControl.live = true;
    }
}
