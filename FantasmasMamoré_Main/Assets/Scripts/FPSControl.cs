using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FPSControl : MonoBehaviour {
    public GameObject vilao;
    public GameObject vilaoanim;
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
    public GameObject trem;
    public GameObject enemies;
    public TOD_Sky sky;
    public GameObject lampada;
    public GameObject aimdsnao;
    public GameObject falaRespawn;
    public Animator fadeOut;
    public GameObject somMove;
    bool ledge;

    public ControleTempoGalpao controleTempo;

    private PlayerState playerState;

    AudioSource audio;
    public AudioClip porta;
    public AudioClip voz1;
    public AudioClip voz2;
    public AudioClip voz3;
    public GameObject thomas;
    public GameController_Ato_1 killme;
    public GameObject lamparinasave;

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
    public bool noMove;

    public float gravity = 100.0f;

    Animator anim;

    public static bool beliche;

    public GameObject chicoF;
    public ObjetivoGlobal objetivo;



    // Use this for initialization
    void Start ()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
            Save();
            anim.Play("Cutscene Inicial");
            audio.Play();
            ObjetivoGlobal.Objetivo = "Investigar a casa.";
        }
        else if(Globals.playerProgress == 1)
        {
            ObjetivoGlobal.Objetivo = "Fugir dos fantasmas!";
            UnlockMovement();
            cutscene.WideScreenInF();
            vilao.SetActive(true);
            falaRespawn.SetActive(true);
            Invoke("VilaoAnimation", 6f);
            vilaoanim.SetActive(true);
            killme.enemyBatch_1.SetActive(true);
            TeleportPlayer(9.54f, 51f, 14.4f, 0, -189f, 0);
            Invoke("Killme", 3f);
            musica.SetActive(true);
        }
        else if(Globals.playerProgress == 2)
        {
            ObjetivoGlobal.Objetivo = "Preciso encontrar respostas.";
            UnlockMovement();
            cutscene.WideScreenInF();
            killme.Ato1.SetActive(false);
            enemies.SetActive(false);
            TeleportPlayer(260, 55, 334, 0, -91, 0);
        }
        else if (Globals.playerProgress == 3)
        {
            ObjetivoGlobal.Objetivo = "Falar com a mulher que parece estar perdida";
            UnlockMovement();
            cutscene.WideScreenInF();
            killme.Ato1.SetActive(false);
            enemies.SetActive(false);
            TeleportPlayer(-124, 51, 54, 0, 85, 0);
        }
        else if(Globals.playerProgress == 4)
        {
            ObjetivoGlobal.Objetivo = "Procurar pelo meu corpo na cabana onde durmo";
            UnlockMovement();
            cutscene.WideScreenInF();
            trem.SetActive(false);
            controleTempo.TriggerCamaAto1.SetActive(false);
            controleTempo.PortaAto1.SetActive(false);
            controleTempo.TriggersAto3.SetActive(true);
            controleTempo.luzes.SetActive(false);
            controleTempo.ColisoesAto3.SetActive(true);
            enemies.SetActive(false);
            chicoF.SetActive(false);
            sky.Cycle.Hour = 12f;
            TeleportPlayer(-121, 51, 28, 0, 82, 0);

        }


    }
    void Update()
    {
        sensitivity = VolumeBrightness.Saved_sensibilidade;

        if (ControleTempoGalpao.time >= 7) lampada.SetActive(false);
        else lampada.SetActive(true);
    }
    // Update is called once per frame
    void FixedUpdate () {

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
            if(!noMove)
                player.Move(move * Time.deltaTime);
            transform.Rotate(0, camX, 0);
            // eyes.transform.Rotate(0, 0, camY); // esse não travava a rotação Y
            eyes.transform.localRotation = Quaternion.Euler(0, 0, -camY);


            Vector3 horizontalVelocity = new Vector3(player.velocity.x, 0, player.velocity.z);

            float horizontalSpeed = horizontalVelocity.magnitude;


            if (Input.GetKey(KeyCode.LeftShift) && horizontalSpeed > 1)
            {
                Run();
                //StopCoroutine(lastCoroutine);
            }
            if (Input.GetKeyUp(KeyCode.LeftShift) || horizontalSpeed < 1)
            {

                CameraRun.speed = 0f;
                lastCoroutine = StartCoroutine("Stoprun");
            }

            if (Door.Cut == true)
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
        //Debug.Log("Running");

        //speedfactor = speedfactor + acceleration;
        //speed = speedfactor * 2f;
        speed = 7f;
        //speedfactor = Mathf.Clamp(speedfactor, 1, 3);
        //if(speedfactor >= 2.4f)
        CameraRun.speed = Mathf.Round(3 * 5);
    }

    IEnumerator Stoprun()
    {
        //while (true)
        //{
            //Debug.Log("Stopping");
          //  speedfactor = speedfactor - (acceleration*3);
            //speed = speedfactor * 1.6f;
            //speedfactor = Mathf.Clamp(speedfactor, 1, 3);
            //if (speedfactor == 1)
            //{
              //  StopCoroutine(lastCoroutine);
                speed = 4f;
            //}

            yield return new WaitForSeconds(0.1f);
        
    }

    public void UnlockMovement()
    {
        moveLock = false;
        Door.Cut = false;
    }

    public void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Enemy" && !Cheats.invincible)
        {
            anim.SetInteger ("State", 1);
            moveLock = true;
            live = false;
        }
        if(col.gameObject.tag == "Door" && beliche)
        {
            anim.SetInteger("State", 0);
            vilao.SetActive(true);
            vilaoanim.SetActive(true);
            moveLock = true;
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Ledge" && !ledge)
        {
            Save();
            ledge = true;
            moveLock = true;
            TeleportPlayer(261.08f, 66.57f, 321.93f, 0, -91.84f, 0);
            anim.Play("Ledge");
            ObjetivoGlobal.Objetivo = "Encontre um caminho alternativo para voltar à vila";
            objetivo.AtualizaObjetivo();
            killme.Ato1.SetActive(false);
            enemies.SetActive(false);
            Globals.playerProgress = 2;
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
        //obj2.SetActive(true);
        objetivo.AtualizaObjetivo();
    }

    public void Continue()
    {
        next = true;
        Invoke("StopContinue", 0.1f);
    }
    public void End()
    {
        Dialogo.SetActive(false);
        objetivo.AtualizaObjetivo();
        //obj1.SetActive(true);
    }
    public void End2()
    {
        Dialogo2.SetActive(false);
        //obj2.SetActive(true);
        objetivo.AtualizaObjetivo();
        Invoke("Thomas", 1.8f);
    }
    public void End3()
    {
        ObjetivoGlobal.Objetivo = "Escape pela mata até chegar na beira do rio.";
        Dialogo3.SetActive(false);
        //musica.SetActive(true);
        Globals.playerProgress = 1;
        //obj3.SetActive(true);
        objetivo.AtualizaObjetivo();
    }

    public void Musica()
    {
        musica.SetActive(true);
    }


    public void StartText()
    {
        Dialogo.SetActive(true);
    }

    public void Thomas()
    {
        ObjetivoGlobal.Objetivo = "Vá até a porta e investigue lá fora.";
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

    public void ToStation()
    {
        player.enabled = false;
        Invoke("SomCarrinho", 2f);
        //TeleportPlayer(-119.213f, 52.4f, 0.15f, 0, -180f, 0);

        transform.parent.gameObject.transform.parent = GameObject.Find("Carrinho").transform;
        transform.localPosition = Vector3.zero;
        transform.position = new Vector3(-119.213f, 52.4f, 0.15f);
        transform.rotation = Quaternion.Euler(0, -180f, 0);
        transform.parent.gameObject.transform.localPosition = Vector3.zero;
        transform.parent.gameObject.transform.localPosition = new Vector3(-0.01f, 0.9f, -2.04f);
        transform.parent.gameObject.transform.localRotation = Quaternion.Euler(0, 90, 0);

        moveLock = true;
        Globals.playerProgress = 5;
        //moveLock = true;
        Invoke("FadeOut", 8f);
        Invoke("LoadStation", 12f);
    }

    void SomCarrinho()
    {
        somMove.SetActive(true);
    }

    public void VilaoAnimation()
    {
        vilao.transform.GetComponentInChildren<Animator>().Play("charge");
    }

    public void AiMeuDeusNao()
    {
        Save();
        //aimdsnao.SetActive(true);
    }

    public void FadeOut()
    {
        fadeOut.Play("FadeOut");
    }

    public void LoadStation()
    {
        SceneManager.LoadScene("LoadingScreenAtoFinal");
    }

    public void AtualizaOObjetivo()
    {
        objetivo.AtualizaObjetivo();
    }

    public void Save()
    {
        lamparinasave.SetActive(true);
        Invoke("DesativaLamparina", 5f);
    }

    void DesativaLamparina()
    {
        lamparinasave.SetActive(false);
    }


}
