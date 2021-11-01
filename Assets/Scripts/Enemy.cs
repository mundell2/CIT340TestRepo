using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //Ways of getting another script/object's data, Method 1
    //Efficient, but has to be done in the editor manually
    //public WaypointManager waypointManager;
    
    public float speed = 5;
    public float distanceThreshold = .75f;
    public int maxHealth = 10;
    public Slider healthBar;

    private Vector2 targetWaypoint;
    private int targetWaypointIndex;
    private SpriteRenderer sr;
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        //Ways of getting another script/object's data, Method 2
        //Slowest, but works for objects that didn't exist on game start
        //waypointManager = FindObjectOfType<WaypointManager>();

        //Ways of getting another script/object's data, Method 3
        targetWaypoint = WaypointManager.staticWaypoints[0];
        targetWaypointIndex = 0;

        sr = GetComponent<SpriteRenderer>();

        currentHealth = maxHealth;
        healthBar = GetComponentInChildren<Slider>();
    }
    public void DoDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
            Destroy(gameObject);
        healthBar.value = (float)currentHealth / maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 directionToMove = targetWaypoint - (Vector2)transform.position;
        float distance = directionToMove.magnitude;
        if (distance < distanceThreshold)
        {
            if (targetWaypointIndex == WaypointManager.staticWaypoints.Count - 1)
                return;
            targetWaypoint = WaypointManager.staticWaypoints[++targetWaypointIndex];
            directionToMove = targetWaypoint - (Vector2)transform.position;
        }

        directionToMove.Normalize();
        transform.Translate(directionToMove * speed * Time.deltaTime);
        if (directionToMove.x > .01)
            sr.flipX = true;
        else
            sr.flipX = false;
    }
}
