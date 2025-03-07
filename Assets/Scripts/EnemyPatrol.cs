using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    Rigidbody2D rigid;

    public Transform[] patrolPoints;
    public int currentPoint;
    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        currentPoint = 0;
    }

    // Update is called once per frame
    void FixedUpdate(){
        if(Vector2.Distance(transform.position, patrolPoints[currentPoint].position) < 0.1f) {
            currentPoint = currentPoint > 3 ? 0 : currentPoint++;
        }
        else {
            transform.Translate(patrolPoints[currentPoint].position * 1 * Time.deltaTime);
        }

    }
}
