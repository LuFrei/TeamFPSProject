using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TWG.Equipment {
public class BulletBehavior: MonoBehaviour {
    private LineRenderer line;
    private Vector3[] lineVertices = new Vector3[2];

    private Ray ray;
    private RaycastHit hit;

    [SerializeField] private float lifeTime = 0.05f;
    [SerializeField] private float decayState = 100; //determines when a bullet should be destroyed (time/hit based)
    [SerializeField] private float magnitude = 100;

    [SerializeField] private GameObject[] bulletHoleTexture;


    public float Magnitude { set => magnitude = value; }
    public RaycastHit Hit => hit;




    void Awake() {
        //Set variables 
        line = GetComponent<LineRenderer>();
        ray = new Ray(transform.position, transform.forward);
        //Debug.DrawRay(ray.origin, ray.direction * magnitude, Color.blue);
        ShootRay();
    }

    void Update() {
        StartCoroutine(Timer(decayState, 2000));
    }



    // TODO: Insead of ray collision should trigger event where character can reduce health.
    private void ShootRay() {

        if(Physics.Raycast(ray, out hit, magnitude)) {
                // Commenting for now, but his does nothing yet anyway.
            //if(hit.collider.GetComponent<Health>()) {
            //    DealDamage(hit);
            //}
            ApplyHitTexture(hit);
            Decay(100);
        }
    }

    //Needs Health class to be set up first
    private void DealDamage(RaycastHit hit) {
        //hit.collider.GetComponent<Health>().
    }

    private void ApplyHitTexture(RaycastHit hit) {
        //For now,it selectgs a random texture, might have dynamic textures later based on what it hit. (might store texture values on the object being hit itself.
        Instantiate(bulletHoleTexture[Random.Range(0, 4)], hit.point, Quaternion.LookRotation(hit.normal));
    }

    private void Decay(float decayValue) {
        decayState -= decayValue;
        if(decayState <= 0) {
            Destroy(gameObject);
        }
    }

    IEnumerator Timer(float time, float multiplier = 1) {
        while(time > 0) {
            time -= Time.deltaTime * multiplier;
            yield return null;
        }
        Destroy(gameObject);
    }
}
}