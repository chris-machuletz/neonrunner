﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackSpawnManager : MonoBehaviour {

    public GameObject[] trackSections;

    public GameObject lumenCube;
    public GameObject lifeCube;
    public GameObject indestructableCube;
    public GameObject hoverCube;

    private int anzLumenCubes = 40;
    private int anzLifeCubes = 2;
    private int anzIndestructableCubes = 1;
    //private int anzHoverCubes = 1;

    // public Material trackMaterial; // Material für Streckenteile
    private Transform playerTransform;
    public float spawnZ = -15.0f; // -15, damit beim Start keine Lücke hinterm Spieler zu sehen ist
    private float trackSectionLength = 400.0f;
    private int amountofRenderedTracks = 5;
    private float safeZone = 500.0f; // Löscht Streckensegmente erst, nachdem Spieler sie passiert hat
    private int lastSpawnedTrack = 0;

    public List<GameObject> activeTracks;

    private List<GameObject> activeLumenCubes;
    private List<GameObject> activeLifeCubes;
    private List<GameObject> activeIndestructableCubes;
   // private List<GameObject> activeHoverCubes;
  

    Scene scen; //Scenen-Element, um zu prüfen, ob der aktuelle Code im Menü ausgeführt wird, wo er deaktiviert werden soll

    // Use this for initialization
    void Start()
    {
        //Spawns the amount of Rendered Tracks at the beginning
        activeTracks = new List<GameObject>();
        activeLumenCubes = new List<GameObject>();
        activeLifeCubes = new List<GameObject>();
        activeIndestructableCubes = new List<GameObject>();
        //activeHoverCubes = new List<GameObject>();
      
      


        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i < amountofRenderedTracks; i++)
        {
            if (i < 2) // als erste 2 Tracksections werden tracksection[0] gespawnt, auf dem sich noch keine Hindernisse befinden
            {
                SpawnTrack(0);

            }
            else
            {
                SpawnTrack();


                gameObject.GetComponent<randomSpawn>().Test();
                SpawnLumenCubes();
                DeleteLumenCubes();

                SpawnLifeCubes();
                DeleteLifeCubes();

                SpawnIndestructableCubes();
                DeleteIndestructableCubes();

                //SpawnHoverCubes();
                //DeleteHoverCubes();
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Ship")){
            //If Player has passed the safeZone: a new track gets spawned and the first gets deleted
            if (playerTransform.position.z > (spawnZ + safeZone - amountofRenderedTracks * trackSectionLength))
            {
                SpawnTrack();

             
                gameObject.GetComponent<randomSpawn>().Test();

                DeleteTrack();

                SpawnLumenCubes();
                DeleteLumenCubes();

                SpawnLifeCubes();
                DeleteLifeCubes();

                SpawnIndestructableCubes();
                DeleteIndestructableCubes();

                //SpawnHoverCubes();
                //DeleteHoverCubes();

                GameObject.FindGameObjectsWithTag("track");

            }
        }
    }



    //Spanws a new Track
    private void SpawnTrack(int trackIndex = -1)
    {
        GameObject gameobj;

        if (trackIndex == -1)
        {
            gameobj = Instantiate(trackSections[RandomTrackGenerator()]) as GameObject;

        }
        else
            gameobj = Instantiate(trackSections[0]) as GameObject;


        gameobj.transform.SetParent(transform);
        gameobj.AddComponent<MeshCollider>();
        gameobj.transform.position = Vector3.forward * spawnZ;


        spawnZ += trackSectionLength;
        activeTracks.Add(gameobj);

    }
    //Deletes the Track the Player already passed
    private void DeleteTrack()
    {
        Destroy(activeTracks[0]);
        activeTracks.RemoveAt(0);
    }

    //generates a Random Track (Baukastensystem)
    private int RandomTrackGenerator()
    {
        if(trackSections.Length <= 1)
        return 0;

        int rndIndex = lastSpawnedTrack;
        while(rndIndex == lastSpawnedTrack)
        {
            rndIndex = Random.Range(0, trackSections.Length);
        }
        lastSpawnedTrack = rndIndex;
        return rndIndex;
    }

    private void SpawnLumenCubes()
    {
        scen = SceneManager.GetActiveScene();
        if (scen.name != "ship_switch" && scen.name != "Menü" && scen.name != "Hilfemenü" && scen.name != "HighScore") //nur ausführen, wenn der Code nicht im Menü ist, da er nicht gebraucht wird - sonst Fehlermeldungen
        {
            for (int i = 0; i < anzLumenCubes; i++)
            {
                Vector3 cubePos = new Vector3(Random.Range(-100.0f, 100.0f), 0.6f, Random.Range(spawnZ - trackSectionLength, spawnZ));

                GameObject lcube;
                lcube = Instantiate(lumenCube, cubePos, Quaternion.identity) as GameObject;
                lcube.transform.parent = GameObject.Find("LumenCubes").transform;

                activeLumenCubes.Add(lcube);
            }
        }
    }
    private void DeleteLumenCubes()
    {
        while (activeLumenCubes.Count > (anzLumenCubes * 5)) // so werden Cubes hinterm spieler korrekt entfernt, unabhängig von der anzahl der Cubes die auf dem Tracksegment gespawnt werden sollen
        {
            Destroy(activeLumenCubes[0]);
            activeLumenCubes.RemoveAt(0);
        }
    }

    private void SpawnLifeCubes()
    {
        scen = SceneManager.GetActiveScene();
        if (scen.name != "ship_switch" && scen.name != "Menü" && scen.name != "Hilfemenü" && scen.name != "HighScore") //nur ausführen, wenn der Code nicht im Menü ist, da er nicht gebraucht wird - sonst Fehlermeldungen
        {
            for (int i = 0; i < anzLifeCubes; i++)
            {
                Vector3 cubePos = new Vector3(Random.Range(-100.0f, 100.0f), 0.6f, Random.Range(spawnZ - trackSectionLength, spawnZ));

                GameObject licube;
                licube = Instantiate(lifeCube, cubePos, Quaternion.identity) as GameObject;
                licube.transform.parent = GameObject.Find("LifeCubes").transform;

                activeLifeCubes.Add(licube);
            }
        }
    }

    private void DeleteLifeCubes()
    {
        while (activeLifeCubes.Count > (anzLifeCubes * 5)) // so werden Cubes hinterm spieler korrekt entfernt, unabhängig von der anzahl der Cubes die auf dem Tracksegment gespawnt werden sollen
        {
            Destroy(activeLifeCubes[0]);
            activeLifeCubes.RemoveAt(0);
        }
    }

    private void SpawnIndestructableCubes()
    {
        scen = SceneManager.GetActiveScene();
        if (scen.name != "ship_switch" && scen.name != "Menü" && scen.name != "Hilfemenü" && scen.name != "HighScore") //nur ausführen, wenn der Code nicht im Menü ist, da er nicht gebraucht wird - sonst Fehlermeldungen
        {
            for (int i = 0; i < anzIndestructableCubes; i++)
            {
                int spawnraffle = Random.Range(0, 10);
                if (spawnraffle > 7)
                {
                    Vector3 cubePos = new Vector3(Random.Range(-100.0f, 100.0f), 0.6f, Random.Range(spawnZ - trackSectionLength, spawnZ));

                    GameObject indcube;
                    indcube = Instantiate(indestructableCube, cubePos, Quaternion.identity) as GameObject;
                    indcube.transform.parent = GameObject.Find("IndestructableCubes").transform;

                    activeIndestructableCubes.Add(indcube);
                }
            }
        }
    }
    private void DeleteIndestructableCubes()
    {
        while (activeIndestructableCubes.Count > (anzIndestructableCubes * 5)) // so werden Cubes hinterm spieler korrekt entfernt, unabhängig von der anzahl der Cubes die auf dem Tracksegment gespawnt werden sollen
        {
            Destroy(activeIndestructableCubes[0]);
            activeIndestructableCubes.RemoveAt(0);
        }
    }

    /* Findet in Hover UP statt!!
    private void SpawnHoverCubes()
    {
        scen = SceneManager.GetActiveScene();
        if (scen.name != "Menü" && scen.name != "Ende" && scen.name != "ship_switch") //nur ausführen, wenn der Code nicht im Menü ist, da er nicht gebraucht wird - sonst Fehlermeldungen
        {

            for (int i = 0; i < anzHoverCubes; i++)
            {
                Vector3 cubePos = new Vector3(Random.Range(-100.0f, 100.0f), 0.6f, Random.Range(spawnZ - trackSectionLength, spawnZ));

                GameObject hovcube;
                hovcube = Instantiate(hoverCube, cubePos, Quaternion.identity) as GameObject;
                hovcube.transform.parent = GameObject.Find("HoverCubes").transform;

                activeHoverCubes.Add(hovcube);
            }

        }
        
    }
    private void DeleteHoverCubes()
    {
        while (activeHoverCubes.Count > (anzHoverCubes * 5)) // so werden Cubes hinterm spieler korrekt entfernt, unabhängig von der anzahl der Cubes die auf dem Tracksegment gespawnt werden sollen
        {
            Destroy(activeHoverCubes[0]);
            activeHoverCubes.RemoveAt(0);
        }
    } */
}
