using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections;

public class ButtonThroughKeySelection : MonoBehaviour
{
    public GameObject[] menuButton = new GameObject[4];
    public GameObject backOpcoes;
    public GameObject backCreditos;
    public GameObject[] quitOptions = new GameObject[2];

    bool backSelected;

    [SerializeField] public string screen;
    [SerializeField] int buttonIndex;
    [SerializeField] string navigation;

    private void Start()
    {
        screen = "Menu";
        navigation = "Mouse";
        buttonIndex = 0;
    }

    void Update()
    {
        if (screen == "Menu")
        {
            backSelected = false;
            if (navigation == "Mouse")
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow) ||
                    Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    navigation = "Keyboard";
                    EventSystem.current.SetSelectedGameObject(menuButton[0]);
                }
            }

            if (navigation == "Keyboard")
            {
                if (Input.GetKeyDown(KeyCode.DownArrow) && buttonIndex < 3)
                {
                    buttonIndex++;
                    EventSystem.current.SetSelectedGameObject(menuButton[buttonIndex]);
                }

                else if (Input.GetKeyDown(KeyCode.UpArrow) && buttonIndex > 0)
                {
                    buttonIndex--;
                    EventSystem.current.SetSelectedGameObject(menuButton[buttonIndex]);
                }

                else if (Input.GetKeyDown(KeyCode.DownArrow) && buttonIndex == 3) EventSystem.current.SetSelectedGameObject(menuButton[3]);
                else if (Input.GetKeyDown(KeyCode.UpArrow) && buttonIndex == 0) EventSystem.current.SetSelectedGameObject(menuButton[0]);

                if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) && buttonIndex == 1) screen = "Opcoes";
                if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) && buttonIndex == 2) screen = "Creditos";
                if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) && buttonIndex == 3) screen = "Sair";
            }
        }

        if (screen == "Opcoes")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                EventSystem.current.SetSelectedGameObject(backOpcoes);
                screen = "Menu";
                buttonIndex = 0;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow) ||
                Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                EventSystem.current.SetSelectedGameObject(backOpcoes);
                backSelected = true;
            }

            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) && backSelected)
            {
                screen = "Menu";
                buttonIndex = 0;
            }
        }

        if (screen == "Creditos")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                EventSystem.current.SetSelectedGameObject(backCreditos);
                screen = "Menu";
                buttonIndex = 0;
            }


            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow) ||
                Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                EventSystem.current.SetSelectedGameObject(backCreditos);
                backSelected = true;
            }

            if (Input.GetKeyDown(KeyCode.Space) && backSelected)
            {
                screen = "Menu";
                buttonIndex = 0;
            }
        }

        if (screen == "Sair")
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                EventSystem.current.SetSelectedGameObject(quitOptions[0]);
                backSelected = false;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                EventSystem.current.SetSelectedGameObject(quitOptions[1]);
                backSelected = true;
            }

            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) && backSelected)
            {
                screen = "Menu";
                buttonIndex = 0;
            }
        }
    }
}
