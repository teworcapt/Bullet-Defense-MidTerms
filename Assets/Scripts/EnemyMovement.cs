using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    public Transform spawn, player;
    float timeCount = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    void QuaternionSlerp()
    {
        transform.rotation = Quaternion.Slerp(spawn.rotation, player.rotation, timeCount);
        timeCount = timeCount + Time.deltaTime;
    }

    void LookRotation()
    {
        Vector3 relativePos = player.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }
}
