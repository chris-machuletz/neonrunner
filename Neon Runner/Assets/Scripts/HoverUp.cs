﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter)), RequireComponent(typeof(MeshRenderer))]
public class HoverUp : MonoBehaviour
{
    //das leuchten der Cubes muss noch hinzugefügt werden


    public Mesh mesh;
    public Material mats;

    public static bool gegessen;

    private GameObject cube;
    private GameObject lightGameObject;

    private int entfernung = 500;  //legt fest in bis zu welcher entfernung der cube spawnen soll

    void Start()
    {
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();

        gegessen = false;

        this.transform.position = new Vector3(Random.Range(-3.0f, 3.0f), 1, Random.Range(GameObject.FindGameObjectWithTag("Player").transform.position.z, GameObject.FindGameObjectWithTag("Player").transform.position.z + entfernung)); //random spawn für cube

        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        cube.GetComponent<Renderer>().material = mats;
        cube.transform.position = this.transform.position;

        cube.tag = "HoverUp";
        BoxCollider box = cube.GetComponent(typeof(BoxCollider)) as BoxCollider;    //aktiviert den collider im cube
        box.isTrigger = true;

        //Leuchten des Cubes
        lightGameObject = new GameObject("The Light");
        Light lightComp = lightGameObject.AddComponent<Light>();
        lightComp.color = Color.green;
        lightComp.intensity = 8.5f;
        lightComp.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        lightGameObject.transform.position = this.transform.position;
    }

    private void FixedUpdate()
    {
        //soll ausgeführt werden, wenn der block konsumiert wurde. und spawnt ihn neu
        if (gegessen == true)
        {
            this.transform.position = new Vector3(Random.Range(-50.0f, 50.0f), 1, Random.Range(GameObject.FindGameObjectWithTag("Player").transform.position.z, GameObject.FindGameObjectWithTag("Player").transform.position.z + entfernung));
            cube.transform.position = this.transform.position;
            lightGameObject.transform.position = this.transform.position;
            gegessen = false;
        }
        if (GameObject.FindGameObjectWithTag("Player").transform.position.z-30 >= this.transform.position.z)
        {
            this.transform.position = new Vector3(Random.Range(-50.0f, 50.0f), 1, Random.Range(GameObject.FindGameObjectWithTag("Player").transform.position.z, GameObject.FindGameObjectWithTag("Player").transform.position.z + entfernung));
            cube.transform.position = this.transform.position;
            lightGameObject.transform.position = this.transform.position;
        }

        //sorgt dafür das sich der cube dreht
        cube.transform.Rotate(Vector3.up, 100 * Time.deltaTime);
    }
 

}

//Programmierer Alex