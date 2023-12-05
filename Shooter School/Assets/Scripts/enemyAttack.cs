using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    public Transform player;
    public float attackRange = 10f;

    private enemyMovement enemy;

    public Material defaultMaterial;
    public Material alertMaterial;
    public Renderer ren;

    private bool foundPlayer;

    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
        enemy = GetComponent<enemyMovement>();
        ren = GetComponent<Renderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            Debug.Log("You die now");
            ren.sharedMaterial = alertMaterial; // set destination to player
            enemy.badGuy.SetDestination(player.position);
            foundPlayer = true;
        }
        else if (foundPlayer)
        {
            ren.sharedMaterial = defaultMaterial; // set material back to default mode
            enemy.newLocation(); //cal enemy movemtn script
            foundPlayer = false;
        }
    }
}
