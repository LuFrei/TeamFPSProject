using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior: MonoBehaviour
{
    private Vector3 dir = Vector3.forward;
    private RaycastHit hit;

    private float lifeTime = 0.2f;

    public Vector3 Direction { set => dir = value;  }

    void Awake()
    {
        if(Physics.Raycast(transform.position, dir, out hit)) {
            //If it hit something, check if it's damageble. 
            //yes? deal damage.
            //no? get texture coordinate and apply hit texture.
        } else {
            //destroy self after x time
        }

        Debug.Log("Pew!");
    }

    void Update() {
        Timer(lifeTime);
    }

    IEnumerator Timer(float time) {
        while(time > 0) {
            time -= Time.deltaTime;
            yield return null;
        }
        Destroy(this.gameObject);
    }
}