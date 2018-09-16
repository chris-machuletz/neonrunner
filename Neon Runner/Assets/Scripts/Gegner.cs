﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gegner : MonoBehaviour {

    public Mesh mesh;

    public Material mats;
    public GameObject gegner1;
    public GameObject gegner2;
    public GameObject gegner3;
    public GameObject gegner4;
    public GameObject gegner5;

    //töten
    public bool tot1 = false;
    public bool tot2 = false;
    public bool tot3 = false;
    public bool tot4 = false;
    public bool tot5 = false;

    private int entfernung = 2000;  //legt fest in bis zu welcher entfernung der cube spawnen soll

    void Start()
    {
        spawnen1();
        spawnen2();
        spawnen3();
        spawnen4();
        spawnen5();
    }

    // Update is called once per frame
    void FixedUpdate() {
        gegner1.transform.position = new Vector3(gegner1.transform.position.x, gegner1.transform.position.y, gegner1.transform.position.z - 2f);
        gegner2.transform.position = new Vector3(gegner2.transform.position.x, gegner2.transform.position.y, gegner2.transform.position.z - 2f);
        gegner3.transform.position = new Vector3(gegner3.transform.position.x, gegner3.transform.position.y, gegner3.transform.position.z - 2f);
        gegner4.transform.position = new Vector3(gegner4.transform.position.x, gegner4.transform.position.y, gegner4.transform.position.z - 2f);
        gegner5.transform.position = new Vector3(gegner5.transform.position.x, gegner5.transform.position.y, gegner5.transform.position.z - 2f);

        //tot ???
        if (tot1 == true)
        {
            Destroy(gegner1);
            tot1 = false;
            spawnen1();
        }
        if (tot2 == true)
        {
            Destroy(gegner2);
            tot2 = false;
            spawnen2();
        }
        if (tot3 == true)
        {
            Destroy(gegner3);
            tot3 = false;
            spawnen3();
        }
        if (tot4 == true)
        {
            Destroy(gegner4);
            tot4 = false;
            spawnen4();
        }
        if (tot5 == true)
        {
            Destroy(gegner5);
            tot5 = false;
            spawnen5();
        }

        //position findung
        if ( gegner1.transform.position.z <= GameObject.FindGameObjectWithTag("Player").transform.position.z)
        {
            tot1 = true;
        }
        if (gegner2.transform.position.z <= GameObject.FindGameObjectWithTag("Player").transform.position.z)
        {
            tot2 = true;
        }
        if (gegner3.transform.position.z <= GameObject.FindGameObjectWithTag("Player").transform.position.z)
        {
            tot3 = true;
        }
        if (gegner4.transform.position.z <= GameObject.FindGameObjectWithTag("Player").transform.position.z)
        {
            tot4 = true;
        }
        if (gegner5.transform.position.z <= GameObject.FindGameObjectWithTag("Player").transform.position.z)
        {
            tot5 = true;
        }

    }

    //Fein Spawn
    void spawnen1()
    {
        gegner1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        gegner1.transform.position = new Vector3(Random.Range(-100.0f, 100.0f), 5, Random.Range(GameObject.FindGameObjectWithTag("Player").transform.position.z + 500, GameObject.FindGameObjectWithTag("Player").transform.position.z + entfernung)); //random spawn für cube
        gegner1.transform.localScale = new Vector3(10f, 10f, 10f);
        gegner1.GetComponent<Renderer>().material.color = Color.yellow;

        gegner1.name = "Feind1";
        SphereCollider box = gegner1.GetComponent(typeof(SphereCollider)) as SphereCollider;    //aktiviert den collider im cube
        box.isTrigger = true;
        GegnerScript aa = gegner1.AddComponent<GegnerScript>();
    }
    void spawnen2()
    {
        gegner2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        gegner2.transform.position = new Vector3(Random.Range(-100.0f, 100.0f), 5, Random.Range(GameObject.FindGameObjectWithTag("Player").transform.position.z + 500, GameObject.FindGameObjectWithTag("Player").transform.position.z + entfernung)); //random spawn für cube
        gegner2.transform.localScale = new Vector3(10f, 10f, 10f);
        gegner2.GetComponent<Renderer>().material.color = Color.yellow;

        gegner2.name = "Feind2";
        SphereCollider box = gegner2.GetComponent(typeof(SphereCollider)) as SphereCollider;    //aktiviert den collider im cube
        box.isTrigger = true;
        GegnerScript aa = gegner2.AddComponent<GegnerScript>();
    }
    void spawnen3()
    {
        gegner3 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        gegner3.transform.position = new Vector3(Random.Range(-100.0f, 100.0f), 5, Random.Range(GameObject.FindGameObjectWithTag("Player").transform.position.z + 500, GameObject.FindGameObjectWithTag("Player").transform.position.z + entfernung)); //random spawn für cube
        gegner3.transform.localScale = new Vector3(10f, 10f, 10f);
        gegner3.GetComponent<Renderer>().material.color = Color.yellow;

        gegner3.name = "Feind3";
        SphereCollider box = gegner3.GetComponent(typeof(SphereCollider)) as SphereCollider;    //aktiviert den collider im cube
        box.isTrigger = true;
        GegnerScript aa = gegner3.AddComponent<GegnerScript>();
    }
    void spawnen4()
    {
        gegner4 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        gegner4.transform.position = new Vector3(Random.Range(-100.0f, 100.0f), 5, Random.Range(GameObject.FindGameObjectWithTag("Player").transform.position.z + 500, GameObject.FindGameObjectWithTag("Player").transform.position.z + entfernung)); //random spawn für cube
        gegner4.transform.localScale = new Vector3(10f, 10f, 10f);
        gegner4.GetComponent<Renderer>().material.color = Color.yellow;

        gegner4.name = "Feind4";
        SphereCollider box = gegner4.GetComponent(typeof(SphereCollider)) as SphereCollider;    //aktiviert den collider im cube
        box.isTrigger = true;
        GegnerScript aa = gegner4.AddComponent<GegnerScript>();
    }
    void spawnen5()
    {
        gegner5 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        gegner5.transform.position = new Vector3(Random.Range(-100.0f, 100.0f), 5, Random.Range(GameObject.FindGameObjectWithTag("Player").transform.position.z + 500, GameObject.FindGameObjectWithTag("Player").transform.position.z + entfernung)); //random spawn für cube
        gegner5.transform.localScale = new Vector3(10f, 10f, 10f);
        gegner5.GetComponent<Renderer>().material.color = Color.yellow;

        gegner5.name = "Feind5";
        SphereCollider box = gegner5.GetComponent(typeof(SphereCollider)) as SphereCollider;    //aktiviert den collider im cube
        box.isTrigger = true;
        GegnerScript aa = gegner5.AddComponent<GegnerScript>();
    }
}
