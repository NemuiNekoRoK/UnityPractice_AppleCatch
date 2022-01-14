using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour{
    public float dropSpeed = -0.3f;
    void Update(){
        transform.Translate(0, this.dropSpeed, 0);
        if(transform.position.y < -0.1f){
            Destroy(gameObject);
        }
    }
}
