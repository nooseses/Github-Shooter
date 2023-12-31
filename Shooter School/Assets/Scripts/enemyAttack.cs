using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    public GameObject player;
    public float attackRange = 10f;
    public float killRange = 1.0f;
    public float cooldown = 3f;
    public float lastTimeAttacked =
        -9999f;  // very negative so its always true when it starts

    private enemyMovement enemy;
    private playerHealth healthScript;

    public Material defaultMaterial;
    public Material alertMaterial;
    public Renderer ren;

    private bool foundPlayer;

    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("player");
        healthScript = player.GetComponent<playerHealth>();
        enemy = GetComponent<enemyMovement>();
        ren = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <=
            attackRange)
        {
            ren.sharedMaterial = alertMaterial;
            enemy.badGuy.SetDestination(
                player.transform.position);  // set destination to player
            foundPlayer = true;
        }
        else if (foundPlayer)
        {
            ren.sharedMaterial =
                defaultMaterial;  // set material back to default mode
            enemy.newLocation();  // cal enemy movemtn script
            foundPlayer = false;
        }

        {
            // cooldown for attack
            if (Time.time > lastTimeAttacked + cooldown)
            {
            }
            if (Vector3.Distance(transform.position, player.transform.position) <=
                killRange)

                healthScript.health -= 0.0175f;
                lastTimeAttacked = Time.time;
        }
    }
}