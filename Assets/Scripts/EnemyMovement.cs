using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject obj;
    public GameObject[] pathPoints;
    public int numberOfPoints;
    public float speed;

    private Vector3 actualPosition;
    private int x;

    public bool stopMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        obj.GetComponent<Animator>().SetBool("Run", true); ;
    }

    // Update is called once per frame
    void Update()
    {
        if(!stopMoving){
            actualPosition = obj.transform.position;
            obj.transform.position = Vector3.MoveTowards(actualPosition, pathPoints[x].transform.position, speed * Time.deltaTime);

            if(actualPosition == pathPoints[x].transform.position && x != numberOfPoints)
            {
                x++;
            }
            if (x == numberOfPoints)
            {
                x = 0;
            }
        }
    }
}
