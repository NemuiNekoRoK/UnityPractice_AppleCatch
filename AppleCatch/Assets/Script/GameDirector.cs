using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour{
    GameObject timerText;
    GameObject pointText;
    GameObject readyText;
    float time = 30f + ItemGenerator.delay;
    int point = 0;
    GameObject generator;

    public void GetApple(){
        this.point += 100;
    }
    public void GetBomb(){
        this.point /= 2;
    }

    void Start(){
        this.generator = GameObject.Find("ItemGenerator");
        this.timerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");
        this.readyText = GameObject.Find("Ready");
    }

    void Update() {
        this.time -= Time.deltaTime;

        StartMessage();

        Difficulty();

        if(this.time <= 30){
            this.timerText.GetComponent<Text>().text = this.time.ToString("F1");
        }
        this.pointText.GetComponent<Text>().text = this.point.ToString() + " point";
    }

    void StartMessage(){
        if(33 <= this.time){
            this.readyText.GetComponent<Text>().text = "Ready";
        }else if (32 <= this.time && this.time < 33){
            this.readyText.GetComponent<Text>().text = "3";
        }else if (31 <= this.time && this.time < 32){
            this.readyText.GetComponent<Text>().text = "2";
        }else if (30 <= this.time && this.time < 31){
            this.readyText.GetComponent<Text>().text = "1";
        } if (29 <= this.time && this.time < 30){
            this.readyText.GetComponent<Text>().text = "Start!";
        }else if (this.time < 29){
            this.readyText.GetComponent<Text>().text = "";
        }
    }

    void Difficulty(){
        //set Game Difficulty
        if(this.time < 0){
            this.time = 0;
            this.generator.GetComponent<ItemGenerator>().SetParameter(10000.0f, 0, 0);
        }else if(this.time <= 0 && this.time < 5){
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.7f, -0.04f, 3);
        }else if(this.time <= 5 && this.time < 10){
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.5f, -0.05f, 6);
        }else if(this.time <= 10 && this.time < 20){
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.8f, -0.04f, 4);
        }else if(this.time <= 20 && this.time < 30){
            this.generator.GetComponent<ItemGenerator>().SetParameter(1.0f, -0.03f, 2);
        }
    }
}

