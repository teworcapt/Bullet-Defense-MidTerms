using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public enum Colors_Player
{
    red,
    green,
    yellow
}

public class PlayerHandler : MonoBehaviour
{
    public Transform target;
    public GameObject redplayer, greenplayer, yellowplayer;
    public string enemyTag = "enemy";
    public float searchRadius = 10f;
    public Colors_Player playerColor;


    // Start is called before the first frame update
    void Update()
    {
        NearestEnemy();
        RotateTowardsTarget();
        switch (playerColor)
        {
            case Colors_Player.red:
                redplayer.SetActive(true);
                greenplayer.SetActive(false);
                yellowplayer.SetActive(false);
                break;
            case Colors_Player.green:
                redplayer.SetActive(false);
                greenplayer.SetActive(true);
                yellowplayer.SetActive(false);
                break;
            case Colors_Player.yellow:
                redplayer.SetActive(false);
                greenplayer.SetActive(false);
                yellowplayer.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, searchRadius);
    }

    void NearestEnemy()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        Transform nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance && distanceToEnemy <= searchRadius)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy.transform;
            }
        }

        target = nearestEnemy;
    }

    void RotateTowardsTarget()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f);
        }

    }

    void OnMouseDown()
    {
        if (playerColor == Colors_Player.red)
        {
            playerColor = Colors_Player.yellow;
        }
        else if (playerColor == Colors_Player.green)
        {
            playerColor = Colors_Player.red;
        }
        else if (playerColor == Colors_Player.yellow)
        {
            playerColor = Colors_Player.green;
        }

    }
}