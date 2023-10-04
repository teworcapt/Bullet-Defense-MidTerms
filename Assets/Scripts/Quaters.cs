using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Quaternions_Sample : MonoBehaviour
{
    public Quaternion currentRotation;
    public float rotSpeed;
    public float rangeValue;
    public Transform enemy;
    float x, y, z;
    //float timeCount = 0.0f;

    // Start is called before the first frame update
    void Update()
    {
        LookRotation();

        float dist = Vector3.Distance(transform.position, enemy.position);

        if (dist < rangeValue)
        {
            Debug.Log("Enemy is close");
        }

    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangeValue);
    }


    void LookRotation()
    {
        Vector3 relativePos = enemy.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }
}
