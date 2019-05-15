using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSControl : MonoBehaviour {
    public GameObject vilao;
    bool moveLock = true;
    public static bool live = true;
    public static bool victory = false;
    public static bool next = false;
    public GameObject Dialogo;
    public GameObject Dialogo2;
    public GameObject Dialogo3;
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject musica;


    private PlayerState playerState;

    AudioSource audio;
    public AudioClip porta;
    public AudioClip voz1;
    public AudioClip voz2;
    public AudioClip voz3;
    public GameObject thomas;
    public GameController_Ato_1 killme;

    public TextMeshProUGUI obj;

    CutsceneLookControl cutscene;

    CharacterController player;
    public GameObject eyes;
    private Rigidbody rb;
    Coroutine lastCoroutine;

    public float speed;
    float ForwardBack;
    float LeftRight;
    public float speedfactor;
    public float acceleration;

    public float sensitivity;
    float camX;
    float camY;

    public float gravity = 100.0f;

    Animator anim;

    public static bool beliche;

    // Use this for initialization
    void Start ()
    {
        cutscene = GetComponent<CutsceneLookControl>();
        playerState = GetComponent<PlayerState>();
        player = this.GetComponent<CharacterController>();
        rb = this.GetComponent<Rigidbody>();
        anim = this.GetComponent<Animator>();
        speedfactor = 1;
        lastCoroutine = null;
        audio = GetComponent<AudioSource>();

        if (Globals.playerProgress == 0)
        {
            anim.Play("Cutscene Inicial");
            audio.Play();
            obj.text = "Investigue a casa.";
        }
        else if(Globals.playerProgress == 1)
        {

            UnlockMovement();
            cutscene.WideScreenOutF();
            vilao.SetActive(true);
            killme.enemyBatch_1.SetActive(true);
            TeleportPlayer(9.54f, 51f, 14.4f, 0, -189f, 0);
            Invoke("Killme", 3f);
            musica.SetActive(true);
        }


	}
	
	// Update is called once per frame
	void Update () {

        if (moveLock) CameraRun.speed = 0f;

        if (!moveLock)
        {
            ForwardBack = Input.GetAxis("Vertical") * speed;
            LeftRight = Input.GetAxis("Horizontal") * speed;
            Vector3 move = new Vector3(ForwardBack, 0, -LeftRight);
            move = transform.rotation * move;
            move.y = move.y - (gravity * Time.deltaTime);

            camX = Input.GetAxis("Mouse X") * sensitivity;
            camY -= Input.GetAxis("Mouse Y") * sensitivity;

            camY = Mathf.Clamp(camY, -90f, 90f);

            player.Move(move * Time.deltaTime);
            transform.Rotate(0, camX, 0);
            // eyes.transform.Rotate(0, 0, camY); // esse não travava a rotação Y
            eyes.transform.localRotation = Quaternion.Euler(0, 0, -camY);



            if (Input.GetKey(KeyCode.LeftShift))
            {
                Run();
                //StopCoroutine(lastCoroutine);
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                CameraRun.speed = 0f;
                lastCoroutine = StartCoroutine("Stoprun");
            }
            if(Door.Cut == true)
            {
                moveLock = true;
                anim.SetInteger("State", 2);

            }

        }
        if (live == false)
        {
            CameraRun.speed = 0f;
            Stoprun();
        }
    }

    public void Run()
    {
        Debug.Log("Running");
        
        speedfactor = speedfactor + acceleration;
        speed = speedfactor * 2f;
        speedfactor = Mathf.Clamp(speedfactor, 1, 3);
        if(speedfactor >= 2.4f)
        CameraRun.speed = Mathf.Round(speedfactor * 5);
    }

    IEnumerator Stoprun()
    {
        while (true)
        {
            Debug.Log("Stopping");
            speedfactor = speedfactor - (acceleration*3);
            speed = speedfactor * 1.6f;
            speedfactor = Mathf.Clamp(speedfactor, 1, 3);
            if (speedfactor == 1)
            {
                StopCoroutine(lastCoroutine);
                speed = 2.4f;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    public void UnlockMovement()
    {
        moveLock = false;
        Door.Cut = false;
    }

    public void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            anim.SetInteger ("State", 1);
            moveLock = true;
            live = false;
        }
        if(col.gameObject.tag == "Door" && beliche)
        {
            anim.SetInteger("State", 0);
            vilao.SetActive(true);
            moveLock = true;
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Ledge")
        {
            moveLock = true;
            victory = true;
        }
        if (col.gameObject.tag == "Cut" && !beliche)
        {
            anim.SetInteger("State", 3);
            moveLock = true;
            beliche = true;
        }
    }
    public void Obj2()
    {
        obj2.SetActive(true);
    }

    public void Continue()
    {
        next = true;
        Invoke("StopContinue", 0.1f);
    }
    public void End()
    {
        Dialogo.SetActive(false);
        obj1.SetActive(true);
    }
    public void End2()
    {
        Dialogo2.SetActive(false);
        obj2.SetActive(true);
        Invoke("Thomas", 1.8f);
    }
    public void End3()
    {
        obj.text = "Escape pela mata até chegar na beira do rio.";
        Dialogo3.SetActive(false);
        musica.SetActive(true);
        Globals.playerProgress = 1;
        obj3.SetActive(true);
    }

    public void StartText()
    {
        Dialogo.SetActive(true);
    }

    public void Thomas()
    {
        obj.text = "Vá até a porta e investigue lá fora.";
        thomas.SetActive(true);
        Invoke("Naohaviatrem", 2f);
    }

    public void Naohaviatrem()
    {
        audio.clip = voz2;
        audio.Play();
    }


    public void StartText2()
    {
        audio.clip = voz1;
        audio.Play();
        Dialogo2.SetActive(true);
    }
    public void StartText3()
    {
        vilao.SetActive(true);
        vilao.GetComponent<AudioSource>().Play();
        Dialogo3.SetActive(true);
    }

    public void Sound_Porta()
    {
        audio.clip = porta;
        audio.Play();
    }

    void StopContinue()
    {
        next = false;
    }

    public void ChangeState()
    {
        anim.SetInteger("State", 0);
    }

    public void Killme()
    {
        killme.AI_Enable();
        GameController_Ato_1.AI_Enabled = true;
    }

    void TeleportPlayer(float Tx, float Ty, float Tz, float Rx, float Ry, float Rz)
    {
        player.enabled = false;
        transform.position = new Vector3(Tx, Ty, Tz);
        transform.rotation = Quaternion.Euler(Rx, Ry, Rz);
        player.enabled = true;
    }


}
