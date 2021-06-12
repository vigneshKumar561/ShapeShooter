using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    List<Transform> waypoints;
    int wayPointIndex = 0;
    [SerializeField] float moveSpeed = 0.5f;
    [SerializeField] WaveConfig waveConfig;
    // Start is called before the first frame update

    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[wayPointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(wayPointIndex <= waypoints.Count - 1)
        {
            
            var targetPosition = waypoints[wayPointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            
            if (transform.position == targetPosition)
            {
                print("HI");
                wayPointIndex++;
            }
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
