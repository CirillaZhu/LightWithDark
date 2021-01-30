using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public int playerLight;
    public int playerLightMax;
    public int playerDark;
    public int playerDarkMax;

    public Image LightCount;
    public Image DarkCount;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (playerLight > playerLightMax)
        {
            playerLight = playerLightMax;
        }
        if (playerDark > playerDarkMax)
        {
            playerDark = playerDarkMax;
        }
        LightCount.fillAmount = (float)playerLight / playerLightMax;
        DarkCount.fillAmount = (float)playerDark / playerDarkMax;
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy.type == "Light")
            {
                playerLight += enemy.score;
            }
            else if (enemy.type == "Dark")
            {
                playerDark += enemy.score;
            }
            Destroy(collision.gameObject);
        }
    }
}
