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

    [SerializeField]private float lifeTime = 0.05f;
    [SerializeField]private float magnitude = 100;



    public Vector3 Direction {
        set {
            if(value == null) {
                dir = transform.localEulerAngles;
            } else {
                dir = value;
            }
        }
    }
    public float Magnitude { set => magnitude = value; }
    public RaycastHit Hit => hit;




    void Awake(){
        //Set variables
        line = GetComponent<LineRenderer>();
        ray = new Ray(transform.position, dir);
    }

    void Update() {
        StartCoroutine(Timer(lifeTime));

        Debug.DrawRay(ray.origin, ray.direction * magnitude, Color.blue);
        ShootRay();
    }

    

    void ShootRay() {
        if(Physics.Raycast(ray, out hit, magnitude)) {
            if(hit.collider.GetComponent<Health>()) {
                DealDamage();
            } else {
                //get texture coordinate and apply hit texture.
            }

            Destroy(gameObject);
        }
        Debug.Log("Pew!");
    }

    //Needs Health class to be set up first
    void DealDamage() {
        //hit.collider.GetComponent<Health>().
    }

    //**  Work on Line Rendering sometime later. **//
    //void RenderTracer() {
    //    line.SetPositions(lineVertices);
    //    line.world
    //    Debug.Log("Rendering Pew!");
    //}
    //
    //void SetNewLineVertices(Vector3 v1, Vector3 v2) {
    //    lineVertices[0] = v1;
    //    lineVertices[1] = v2;
    //}


    IEnumerator Timer(float time) {
        while(time > 0) {
            time -= Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}