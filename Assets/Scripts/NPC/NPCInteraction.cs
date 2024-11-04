using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public GameObject uiInteraction;
    private bool isPlayerNeared = false;

    private void Start()
    {
        uiInteraction.SetActive(false);
    }

    private void Update()
    {
        if (isPlayerNeared && Input.GetMouseButtonDown(0))
        {
            DoItSomething();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            uiInteraction.SetActive(true);
            isPlayerNeared = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            uiInteraction.SetActive(false);
            isPlayerNeared = false;
        }
    }

    private void DoItSomething()
    {
        //
        Debug.Log("Interaction was worked");
    }
}
