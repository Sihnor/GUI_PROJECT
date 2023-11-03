using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class camManager : MonoBehaviour
{
    [SerializeField] private GameObject player1;
    [SerializeField] private Vector3 pos;

    void Update()
    {
        pos = player1.transform.position;
        pos.y = 0;
        pos.z = -10;
        transform.position = pos;
    }
}
