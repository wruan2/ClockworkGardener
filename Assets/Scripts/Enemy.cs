using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    static float rhealth;
    static float rtimer;
    public string loadLevel;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            SceneManager.LoadScene(loadLevel);
        }
    }
    public static void setHealth(float health)
    {
        rhealth = health;
    }
    public static void setTimer(float timer)
    {
        rtimer = timer;
    }
    public static float getHealth()
    {
        return rhealth;
    }
    public static float getTimer()
    {
        return rtimer;
    }
}
