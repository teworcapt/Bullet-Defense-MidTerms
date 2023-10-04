using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public List<Color> color;
    public MeshRenderer mats;

    // Start is called before the first frame update
    void Start()
    {
        mats = GetComponent<MeshRenderer>();
    }

    private void OnMouseDown()
    {
       ChangeColor();
    }

    public void ChangeColor()
    {

        for (int i = 0; i < color.Count; i++)
        {
            mats.material.color = color[Random.Range(0, color.Count)];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
