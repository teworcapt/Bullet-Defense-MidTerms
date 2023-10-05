using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    public Transform player, target;
    public float speed = 1.0f;

    void Awake()
    {
        target = player.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,target.position, step);
        
}

    //void LookRotation()
    //{
    //    Vector3 relativePos = player.position - transform.position;
    //    Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
    //    transform.rotation = rotation;
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedBullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
