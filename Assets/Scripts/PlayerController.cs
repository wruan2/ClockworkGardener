using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public Player Player { get; set; }
    private Animator anim;

    private bool playerMoving;
    private Vector2 lastMove;

    public bool canMove;
    
    private void OnEnable()
    {
        if (!PlayerPrefs.HasKey("reload"))
        {
            SavePlayerData.setInitialData(this);
        }
        despawn();
        spawn();
        Player = SavePlayerData.loadData();
        transform.position = Player.Location;
        anim = GetComponent<Animator>();
        canMove = true;
    }
    // Update is called once per frame
    void Update()
    {
        playerMoving = false;

        if (!canMove)
        {
            //myRigidBody.velocity = Vector2.zero;

            transform.Translate(new Vector3(0f, 0f, 0f));
            transform.Translate(new Vector3(0f, 0f, 0f));

            anim.SetFloat("MoveX", 0);
            anim.SetFloat("MoveY", 0);

            anim.SetBool("PlayerMoving", playerMoving);
            anim.SetFloat("LastMoveX", 0);
            anim.SetFloat("LastMoveY", 0);

            return;

        }

        if (canMove)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {

                transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);

            }

            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {

                transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));

            }

            anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));

            anim.SetBool("PlayerMoving", playerMoving);
            anim.SetFloat("LastMoveX", lastMove.x);
            anim.SetFloat("LastMoveY", lastMove.y);
        }

    }
    // Sets enemy health and timer depending on which one player runs into
    void OnTriggerEnter2D(Collider2D other)
    {
        // First enemy
        if (other.gameObject.name == "Enemy 0")
        {
            Enemy.setHealth(60);
            Enemy.setTimer(30);
            SavePlayerData.setData(this, other);
        }
        // Second Enemy
        if (other.gameObject.name == "Enemy 1")
        {
            Enemy.setHealth(90);
            Enemy.setTimer(30);
            SavePlayerData.setData(this, other);
        }
        // Third enemy
        if (other.gameObject.name == "Enemy 2")
        {
            Enemy.setHealth(120);
            Enemy.setTimer(40);
            SavePlayerData.setData(this, other);
        }
        // Final boss
        if (other.gameObject.name == "Enemy 3")
        {
            Enemy.setHealth(180);
            Enemy.setTimer(60);
            SavePlayerData.setData(this, other);
        }
    }
    // Despawns enemies
    void despawn()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            if (enemy.name == "Enemy 0" && PlayerPrefs.GetInt("enemy0") == 0)
                enemy.SetActive(false);
            if (enemy.name == "Enemy 1" && PlayerPrefs.GetInt("enemy1") == 0)
                enemy.SetActive(false);
            if (enemy.name == "Enemy 2" && PlayerPrefs.GetInt("enemy2") == 0)
                enemy.SetActive(false);
            if (enemy.name == "Enemy 3" && PlayerPrefs.GetInt("enemy3") == 0)
                enemy.SetActive(false);
        }
    }
    // Spawns walls
    void spawn()
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (GameObject wall in walls)
        {
            if (wall.name == "Wall" && PlayerPrefs.GetInt("enemy0") == 1)
                wall.SetActive(false);
            if (wall.name == "Wall1" && PlayerPrefs.GetInt("enemy1") == 1)
                wall.SetActive(false);
            if (wall.name == "Wall2" && PlayerPrefs.GetInt("enemy2") == 1)
                wall.SetActive(false);
            if (wall.name == "Wall3" && PlayerPrefs.GetInt("enemy3") == 1)
                wall.SetActive(false);
        }
    }
    public void stopPlayer()
    {
        canMove = false;
    }
}