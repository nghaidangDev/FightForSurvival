using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject uiGameOver;

    private void Start()
    {
        uiGameOver.SetActive(false);
    }

    public void UIGameOver()
    {
        uiGameOver.SetActive(true);
    }
}
