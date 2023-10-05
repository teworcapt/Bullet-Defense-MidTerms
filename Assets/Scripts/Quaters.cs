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

public class Quaternions_Sample : MonoBehaviour
{
    public Quaternion currentRotation;
    public float rotSpeed;
    public float rangeValue;
    public Transform enemy;
    float x, y, z;
    public string enemyTag = "enemy";
    private Transform Target;
    public Colors_Player playerColor;
    public GameObject red,green,blue;
    //float timeCount = 0.0f;

    // Start is called before the first frame update
    void Update()
    {
        //float dist = Vector3.Distance(transform.position, enemy.position);

        //if (dist < rangeValue)
        //{
        //    Debug.Log("Enemy is close");
        //}

        NearestEnemy();
        RotatetowardsTarget();
        switch (playerColor)
        {
            case Colors_Player.red:
                red.SetActive(true);
                green.SetActive(false);
                blue.SetActive(false);
                break;
            case Colors_Player.green:
                red.SetActive(false);
                green.SetActive(true);
                blue.SetActive(false);
                break;
            case Colors_Player.blue:
                red.SetActive(false);
                green.SetActive(false);
                blue.SetActive(true);
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
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        Transform nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy > shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy.transform;

            }
        }

        Target = nearestEnemy;
    }

    void RotatetowardsTarget()
    {
        Vector3 relativePos = enemy.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }

    void OnMouseDown()
    {
        if (playerColor == Colors_Player.red)
        {
            playerColor = Colors_Player.blue;
        } else if (playerColor == Colors_Player.green)
        {
            playerColor = Colors_Player.red;
        } else if (playerColor == Colors_Player.blue)
        {
            playerColor = Colors_Player.green;
        }

    }
}
