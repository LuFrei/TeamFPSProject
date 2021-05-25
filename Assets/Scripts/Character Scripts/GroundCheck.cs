using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//For the purpose of testing character movements, this class will start out simple
//Moving forward, I want to implement these following things:
//1. Check if ANY collider is below object to achieve a "Grounded" state
//2. Use slope of ground to keep charatcers anchored to the floor if they are not jump (no skipping if walking down a slope)
//3. ... I forgot.
public class GroundCheck : MonoBehaviour{
    private GameObject groundCollider;

    private void Start()
    {
        //groundCollider = new GameObject("Ground Checker", typeof(Collider));
        //Instantiate(groundCollider,this.transform);
    }
}
