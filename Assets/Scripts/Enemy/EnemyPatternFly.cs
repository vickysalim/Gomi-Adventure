using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyPatternFly : MonoBehaviour
{
    public AIPath aiPath;

    void Update(){
        if (aiPath.desiredVelocity.x >= 0.01f) // right
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= 0.01f) // left
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

    }
}
