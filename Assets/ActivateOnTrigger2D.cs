using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivateOnTrigger2D : MonoBehaviour
{
    [SerializeField] private UnityEvent myTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("ActivateOnTrigger2D");

            myTrigger.Invoke();
        }
    }
}
