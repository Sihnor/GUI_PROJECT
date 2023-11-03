using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitEvent : MonoBehaviour
{
    [SerializeField] private Collider EnemyCollider;

    private PlayerManager Player;
    
    [SerializeField]
    private int EnemyDamage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        
        other.gameObject.TryGetComponent<PlayerManager>(out this.Player);

        if (this.Player)
        {
            this.Player.dealDamage(this.EnemyDamage);
        }
    }
}
