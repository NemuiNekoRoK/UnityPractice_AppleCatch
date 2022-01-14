using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour{
    public GameObject applePrefab;
    public GameObject bombPrefab;
    float span = 1.0f, delta = 0;
    int ratio = 2;
    float speed = -0.03f;
    public static float delay = 5;

    public void SetParameter(float span, float speed, int ratio){
        this.span = span;
        this.speed = speed;
        this.ratio = ratio;
    }

    void Update(){
        Invoke("Generate", delay);
        this.delta += Time.deltaTime;
    }

    void Generate(){
            if(this.delta > this.span){
            this.delta = 0;
            
            GameObject item;
            int dice = Random.Range(1, 11);
            if(dice <= this.ratio){
                item = Instantiate(bombPrefab) as GameObject;
            }else item = Instantiate(applePrefab) as GameObject; //randomize Generate bomb and apple 2:8
            
            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 4, z);

            item.GetComponent<ItemController>().dropSpeed = this.speed;
        }
    }
}
