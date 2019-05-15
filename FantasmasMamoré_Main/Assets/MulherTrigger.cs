using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MulherTrigger : MonoBehaviour
{
    public MulherBehaviour code;
    public int ID;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (ID == 1)
            {
                code.Corre1();
            }else if (ID == 2)
            {
                code.Corre2();
            }else if(ID == 3)
            {
                code.Corre3();
            }else if(ID == 4)
            {
                code.Corre4();
            }
            Destroy(gameObject);
        }
    }
}
