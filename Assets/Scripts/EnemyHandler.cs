using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovement : MonoBehaviour
{
    public Transform player, target;
    public GameObject redEnemy, blueEnemy, greenEnemy;
    public float speed = 1.0f;

    void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,target.position, step);
        
}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedBullet") && redEnemy)
        {
            Destroy(other.gameObject);
            Destroy(redEnemy.gameObject);
            
        } else if (other.CompareTag("BlueBullet") && blueEnemy)
        {
            Destroy(other.gameObject);
            Destroy(blueEnemy.gameObject);
        } else if (other.CompareTag("GreenBullet") && greenEnemy)
        {
            Destroy(other.gameObject);
            Destroy(greenEnemy.gameObject);
        }
    }
}
