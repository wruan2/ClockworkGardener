using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerData : MonoBehaviour
{
    public static void setInitialData(PlayerController player)
    {
        PlayerPrefs.SetFloat("x", 115);
        PlayerPrefs.SetFloat("y", -122);
        PlayerPrefs.SetInt("enemy0", 1);
        PlayerPrefs.SetInt("enemy1", 1);
        PlayerPrefs.SetInt("enemy2", 1);
        PlayerPrefs.SetInt("enemy3", 1);
        PlayerPrefs.SetInt("reload", 1);
    }
    public static void setData(PlayerController player, Collider2D other)
    {
        PlayerPrefs.SetFloat("x", player.transform.position.x);
        PlayerPrefs.SetFloat("y", player.transform.position.y);
        if (other.gameObject.name == "Enemy 0")
        {
            PlayerPrefs.SetInt("enemy0", 0);
        }
        if (other.gameObject.name == "Enemy 1")
        {
            PlayerPrefs.SetInt("enemy1", 0);
        }
        if (other.gameObject.name == "Enemy 2")
        {
            PlayerPrefs.SetInt("enemy2", 0);
        }
        if (other.gameObject.name == "Enemy 3")
        {
            PlayerPrefs.SetInt("enemy3", 0);
        }
    }
    public static Player loadData()
    {
        float x = PlayerPrefs.GetFloat("x");
        float y = PlayerPrefs.GetFloat("y");
        int enemyTutorial = PlayerPrefs.GetInt("enemy0");
        int enemyFirst = PlayerPrefs.GetInt("enemy1");
        int enemySecond = PlayerPrefs.GetInt("enemy2");
        int enemyThird = PlayerPrefs.GetInt("enemy3");
        Player savedPlayer = new Player()
        {
            Location = new Vector2(x, y),
            enemy0 = enemyTutorial,
            enemy1 = enemyFirst,
            enemy2 = enemySecond,
            enemy3 = enemyThird
        };
        return savedPlayer;
    }
}
