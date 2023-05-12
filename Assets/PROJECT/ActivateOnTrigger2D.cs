using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivateOnTrigger2D : MonoBehaviour
{
    bool activated = false;
    bool check = false;
    int countdown = 4;

    public Color newColor;
    private SpriteRenderer rend;

    [SerializeField] private UnityEvent myTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && activated == true)
        {
            Debug.Log("ActivateOnTrigger2D");

            myTrigger.Invoke();
            activated = false;
        }
    }

    private void Start()
    {
        newColor = new Color(190f, 190f, 190f, 200f);
        rend = GetComponent<SpriteRenderer>();
        rend.color = newColor;
    }

    private void Update()
    {
        if(transform.localScale.x > 1.3f && check == false)
        {
            if (activated == false)
            {
                int rando = Random.Range(1, 10);
                Debug.Log("rando: " + rando);

                if (rando > 7)
                {
                    Debug.Log("ACTIVATED");
                    activated = true;
                    countdown = 4;
                }
            }

            check = true;
        }

        if(transform.localScale.x <= 1.3)
        {
            if (check == true)
            {
                check = false;
                countdown -= 1;
            }
        }

        if(countdown <= 0)
        {
            Debug.Log("DEACTIVATED");
            activated = false;
            countdown = 4;
        }

        if (activated == false)
        {
            newColor = new Color(190f, 190f, 190f, 200f);
        }

        else
        {
            newColor = new Color(255f, 200f, 0f, 200f);
        }

        rend = GetComponent<SpriteRenderer>();
        rend.color = newColor;
    }
}
