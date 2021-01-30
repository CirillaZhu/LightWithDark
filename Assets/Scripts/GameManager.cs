using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Rings;
    //public GameObject player;

    //private int playerIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeRing(int _index)
    {
        foreach (var item in Rings)
        {
            item.GetComponent<RingRotation>().autoRotate = true;
        }
        Rings[_index].GetComponent<RingRotation>().autoRotate = false;
    }
}
