using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    //public KeyCode jumpKey;
    //public KeyCode moveOutKey;
    //public KeyCode moveInKey;

    private float[] playerPoses = {3.83f, 5.11f};
    public int playerIndex;

    private Vector3 targetPos;

    private GameManager GameManager;
    // Start is called before the first frame update
    void Start()
    {

        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameManager.ChangeRing(playerIndex);

    }

    // Update is called once per frame
    void Update()
    {
        targetPos = new Vector3(0.0f, playerPoses[playerIndex], 0.0f);
        transform.position = Vector3.Slerp(transform.position, targetPos, moveSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump/Attack");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameManager.Rings[playerIndex].GetComponent<RingRotation>().ClockWise(-1);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameManager.Rings[playerIndex].GetComponent<RingRotation>().ClockWise(1);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (playerIndex < playerPoses.Length-1)
            {
                playerIndex++;
                GameManager.ChangeRing(playerIndex);
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (playerIndex > 0)
            {
                playerIndex--;
                GameManager.ChangeRing(playerIndex);
            }
        }
    }
}
