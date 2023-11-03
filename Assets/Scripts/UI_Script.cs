using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Script : MonoBehaviour
{
    //[SerializeField] private SpriteRenderer sR;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private GameObject health;
    private Image health1;

    [SerializeField] private Sprite[] spritesHealth = new Sprite[12];
    // Start is called before the first frame update
    void Start()
    {
        health1 = health.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerManager.hP == 0)
        {
            health.active = false;
        }
        Debug.Log(playerManager.hP + spritesHealth[playerManager.hP - 1].ToString());
        //sR.sprite = spritesHealth[playerManager.hP-1];
        health1.sprite = spritesHealth[playerManager.hP - 1];
    }
}
