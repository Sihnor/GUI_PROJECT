using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField]
    public Transform PlayerTransformation;

    [SerializeField]
    public float EnemySpeed;

    MoveEnemy()
    {
        
        this.EnemySpeed = 0.0f;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = this.EnemySpeed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, this.PlayerTransformation.position, step);
    }

    
}
