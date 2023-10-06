using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public enum Colors_Player
{
    red,
    green,
    blue
}

public class PlayerHandler : MonoBehaviour
{

    public Transform Enemy, Target;
    public GameObject redplayer, greenplayer, blueplayer;
    public string enemyTag = "Mobs";
    public float rangeValue;
    public Colors_Player playerColor;

    // Start is called before the first frame update
    void Update()
    {
        NearestEnemy();
        RotatetowardsTarget();
        switch (playerColor)
        {
            case Colors_Player.red:
                redplayer.SetActive(true);
                greenplayer.SetActive(false);
                blueplayer.SetActive(false);
                break;
            case Colors_Player.green:
                redplayer.SetActive(false);
                greenplayer.SetActive(true);
                blueplayer.SetActive(false);
                break;
            case Colors_Player.blue:
                redplayer.SetActive(false);
                greenplayer.SetActive(false);
                blueplayer.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangeValue);
    }

    void NearestEnemy()
    {
        // finds objects with enemyTag which is "Mobs" in this case
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        // calculates the shortest distance of object to player
        float shortestDistance = Mathf.Infinity;
       
        //nearest enemy starts as null
        Transform nearestEnemy = null;
        
        //for each enemy gameobject in enemies array
        foreach (GameObject enemy in Enemies)
        {
            // converts distance of enemy gameobject to vector 3
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            //compares distance of enemy gameobject to shortest distance
            if (distanceToEnemy > shortestDistance)
            {
                //shortestDistance converts itself to be distance to Enemy
                shortestDistance = distanceToEnemy;

                //nearestEnemy declares itself as the enemy gameobject
                nearestEnemy = enemy.transform;
            }
        }

        //target becomes nearest enemy
        Target = nearestEnemy;
    }

    void RotatetowardsTarget()
    {
        //vector 3 rotates towards target position from player position
        Vector3 relativePos = Enemy.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }

    void OnMouseDown()
    {
        if (playerColor == Colors_Player.red)
        {
            playerColor = Colors_Player.blue;
        }
        else if (playerColor == Colors_Player.green)
        {
            playerColor = Colors_Player.red;
        }
        else if (playerColor == Colors_Player.blue)
        {
            playerColor = Colors_Player.green;
        }

    }
}