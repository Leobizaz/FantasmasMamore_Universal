using UnityEngine;
using UnityEngine.UI;

public class ToggleInvincibilidade : MonoBehaviour
{
    Toggle toggle;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
    }
    void Update()
    {
        toggle.isOn = Cheats.invincible;
    }
}
