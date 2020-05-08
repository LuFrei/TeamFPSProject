using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior: MonoBehaviour
{
    private LineRenderer line;
    private Vector3[] lineVertices = new Vector3[2];

    private Ray ray;
    private Vector3 dir;
    private RaycastHit hit;

    private float lifeTime = 0.2f;
    private float magnitude;



    
    

    public Vector3 Direction { set => dir = value; }
    public float Magnitude { set => magnitude = value; }



    void Awake(){
        //Set variables
        line = GetComponent<LineRenderer>();
        ray = new Ray(transform.position, dir);

        //shoot
        ShootRay();// this will start a chain reaction of rays later on
        //draw
        RenderTracer();

    }

    void Update() {
        Timer(lifeTime);
    }

    void ShootRay() {
        if(Physics.Raycast(ray, out hit, magnitude)) {
            //If it hit something, check if it's damageble. 
            //yes? deal damage.
            //no? get texture coordinate and apply hit texture. 
        }
        Debug.Log("Pew!");
    }

    void RenderTracer() {
        line.SetPositions(lineVertices);
    }

    IEnumerator Timer(float time) {
        while(time > 0) {
            time -= Time.deltaTime;
            yield return null;
        }
        Destroy(this.gameObject);
    }
}