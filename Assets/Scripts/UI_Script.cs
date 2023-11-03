using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UI_Script : MonoBehaviour
{

    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private GameObject health;
    [SerializeField] private GameObject shield;
    private Image health1;
    private Image shield1;

    [SerializeField] private Image[] spritesHealth = new Image[8];
    [SerializeField] private Image[] spritesShield = new Image[4];
    // Start is called before the first frame update
    void Start()
    {
        health1 = health.GetComponent<Image>();
        shield1 = shield.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerManager.sP == 0)
        {
            shield.active = false;
        }
        if (playerManager.hP == 0)
        {
            health.active = false;
        }
        Debug.Log(playerManager.hP + spritesHealth[playerManager.hP - 1].ToString());
        Debug.Log(playerManager.sP + spritesHealth[playerManager.sP-1].ToString());
        health1.image = spritesHealth[playerManager.hP-1];
        shield1.image = spritesShield[playerManager.sP-1];

    }
}
