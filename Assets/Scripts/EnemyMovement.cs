using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;

    private Enemy enemy;

    private int yön = 0; 
    private int eskiyon = 0; 

public void Start()
    {
        enemy = GetComponent<Enemy>();

        target = Waypoints.points[0];
    }

    public void Update()
    {

        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector2.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    public void GetNextWaypoint()
    {
    
        eskiyon = yön;

        float deger_x = target.position.x;
        float deger_y = target.position.y;

        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];

        

        float target_deger_x = target.position.x;
        float target_deger_y = target.position.y;

        if (target_deger_x == deger_x)
        {
            if (target_deger_y < deger_y)//aþaðý
            {
                yön = 0;
            }
            else //yukarý
            {
                yön = 1;
            }
        }
        else if (target_deger_y == deger_y)
        {
            if (target_deger_x < deger_x) //sol
            {
                yön = 2;
              
            }
            else//sað
            {
                yön = 3;
             
            }
        }

        if (eskiyon == 0)
        {
            if (yön == 2)
            {
                transform.Rotate(0, 0, -90);
            }
            else if (yön == 3)
            {
                transform.Rotate(0, 0, 90);
            }
            
        }
        else if (eskiyon == 1)
        {
            if (yön == 2)
            {
                transform.Rotate(0, 0, 90);
            }
            else if (yön == 3)
            {
                transform.Rotate(0, 0, -90);
            }
        }
        else if (eskiyon == 2)
        {
            if (yön == 0)
            {
                transform.Rotate(0, 0, 90);
            }
            else if (yön == 1)
            {
                transform.Rotate(0, 0, -90);
            }
        }
        else if (eskiyon == 3)
        {
            if (yön == 0)
            {
                transform.Rotate(0, 0, -90);
            }
            else if (yön == 1)
            {
                transform.Rotate(0, 0, 90);
            }
        }

    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

}
