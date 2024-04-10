using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    //Destroy
    //Setactive

    public void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("Untagged") || hit.gameObject.CompareTag("Obstacles"))
        {
            hit.gameObject.SetActive(false);
        }
    }
}
