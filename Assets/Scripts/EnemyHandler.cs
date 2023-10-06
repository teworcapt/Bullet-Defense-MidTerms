using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class EnemyHandler : MonoBehaviour
{
    public Transform player, target;
    public GameObject redEnemy, yellowEnemy, greenEnemy;
    public float speed = 1.0f;
    public int Damage;

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
            Destroy(gameObject);

        }
        else if (other.CompareTag("YellowBullet") && yellowEnemy)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

        }
        else if (other.CompareTag("GreenBullet") && greenEnemy)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
