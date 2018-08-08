using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

namespace AiGame
{
    public class NewYorkSetupScript : MonoBehaviour
    {
        public static NewYorkSetupScript Instance;

        public GameObject waypointObj;
        public GameObject[] thingsToSpawn;
        public GameObject portalModel;
        public GameObject randomModel;
        public GameObject speedUpModel;
        public GameObject[] waypoints;
        public GameObject roadSpawn;
        public GameObject ghost;
        public int numOfWaypoints;

        public void UpdateNavmeshData()
        {
            //StartCoroutine(UpdateNavmeshDataAsync());
        }

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            numOfWaypoints = 12;
            waypoints = new GameObject[numOfWaypoints];
            StartCoroutine("setup");
            
        }

   
        IEnumerator setup()
        {
   
            yield return new WaitForSeconds(4);
            
            for(int num=0;num<numOfWaypoints;num++)
            {
                //waypoints[num]=Instantiate(waypointObj, RandomNavmeshLocation(10),Quaternion.identity);
                //Place in defined place instead of using random navmesh location

                waypoints[num] = Instantiate(waypointObj, new Vector3(-1.519f, 0.2797f, 6.761f), Quaternion.identity);
                waypoints[num].transform.parent = transform.parent;
            }

            waypoints[0].transform.localPosition = new Vector3(-2.82f, 0.2797f, 4.46f);
            waypoints[1].transform.localPosition = new Vector3(1.9f, 0.2808849f, -1.05f);
            waypoints[2].transform.localPosition = new Vector3(-6.61f, 0.1833339f, 0.6f);
            waypoints[3].transform.localPosition = new Vector3(1.03f, 0.3000002f, -3.46f);
            waypoints[4].transform.localPosition = new Vector3(-0.05f, 0.2666669f, -5.55f);
            waypoints[5].transform.localPosition = new Vector3(-5.9f, 0.26f, 3.23f);
            waypoints[6].transform.localPosition = new Vector3(-9.83f, 0.2750006f, -4.81f);
            waypoints[7].transform.localPosition = new Vector3(-9.03f, 0.341f, 5f);
            waypoints[8].transform.localPosition = new Vector3(1.48f, 0.222f, 2f);
            waypoints[9].transform.localPosition = new Vector3(-4.95f, 0.2797f, 5.64f);
            waypoints[10].transform.localPosition = new Vector3(-7.25f, 0.2750006f, -4.53f);
            waypoints[11].transform.localPosition = new Vector3(-6.84f, 0.2750006f, -2.06f);

            waypoints[0].GetComponent<Waypoint>().neighbors.Add(waypoints[8].GetComponent<Waypoint>());
            waypoints[0].GetComponent<Waypoint>().neighbors.Add(waypoints[9].GetComponent<Waypoint>());
            waypoints[1].GetComponent<Waypoint>().neighbors.Add(waypoints[5].GetComponent<Waypoint>());
            waypoints[2].GetComponent<Waypoint>().neighbors.Add(waypoints[5].GetComponent<Waypoint>());
            waypoints[2].GetComponent<Waypoint>().neighbors.Add(waypoints[3].GetComponent<Waypoint>());
            waypoints[2].GetComponent<Waypoint>().neighbors.Add(waypoints[6].GetComponent<Waypoint>());
            waypoints[2].GetComponent<Waypoint>().neighbors.Add(waypoints[10].GetComponent<Waypoint>());
            waypoints[2].GetComponent<Waypoint>().neighbors.Add(waypoints[3].GetComponent<Waypoint>());
            waypoints[3].GetComponent<Waypoint>().neighbors.Add(waypoints[4].GetComponent<Waypoint>());
            waypoints[3].GetComponent<Waypoint>().neighbors.Add(waypoints[2].GetComponent<Waypoint>());
            waypoints[3].GetComponent<Waypoint>().neighbors.Add(waypoints[1].GetComponent<Waypoint>());
            waypoints[4].GetComponent<Waypoint>().neighbors.Add(waypoints[3].GetComponent<Waypoint>());
            waypoints[4].GetComponent<Waypoint>().neighbors.Add(waypoints[11].GetComponent<Waypoint>());
            waypoints[5].GetComponent<Waypoint>().neighbors.Add(waypoints[1].GetComponent<Waypoint>());
            waypoints[5].GetComponent<Waypoint>().neighbors.Add(waypoints[2].GetComponent<Waypoint>());
            waypoints[5].GetComponent<Waypoint>().neighbors.Add(waypoints[9].GetComponent<Waypoint>());
            waypoints[5].GetComponent<Waypoint>().neighbors.Add(waypoints[7].GetComponent<Waypoint>());
            waypoints[6].GetComponent<Waypoint>().neighbors.Add(waypoints[2].GetComponent<Waypoint>());
            waypoints[7].GetComponent<Waypoint>().neighbors.Add(waypoints[5].GetComponent<Waypoint>());
            waypoints[8].GetComponent<Waypoint>().neighbors.Add(waypoints[0].GetComponent<Waypoint>());
            waypoints[9].GetComponent<Waypoint>().neighbors.Add(waypoints[0].GetComponent<Waypoint>());
            waypoints[9].GetComponent<Waypoint>().neighbors.Add(waypoints[5].GetComponent<Waypoint>());
            waypoints[10].GetComponent<Waypoint>().neighbors.Add(waypoints[6].GetComponent<Waypoint>());
            waypoints[10].GetComponent<Waypoint>().neighbors.Add(waypoints[2].GetComponent<Waypoint>());
            waypoints[11].GetComponent<Waypoint>().neighbors.Add(waypoints[4].GetComponent<Waypoint>());
            waypoints[11].GetComponent<Waypoint>().neighbors.Add(waypoints[10].GetComponent<Waypoint>());
            waypoints[11].GetComponent<Waypoint>().neighbors.Add(waypoints[2].GetComponent<Waypoint>());

            ghost.transform.localPosition = waypoints[1].transform.localPosition;

           

            for (int j=0;j<(numToSpawn/10);j++)
            {
                
                StartCoroutine(spawnNPCWaves(0));
                StartCoroutine(spawnNPCWaves(1));
                StartCoroutine(spawnNPCWaves(2));
                StartCoroutine(spawnNPCWaves(3));
                StartCoroutine(spawnNPCWaves(4));
                StartCoroutine(spawnNPCWaves(5));
                StartCoroutine(spawnNPCWaves(6));
                StartCoroutine(spawnNPCWaves(7));
                StartCoroutine(spawnNPCWaves(8));
                //StartCoroutine(spawnNPCWaves(9));

            }
            spawnPortals();
         
        }

        public int[] intArray;

        private void RandomUnique()
        {
            intArray = new int[waypoints.Length];
            for (int i = 0; i < waypoints.Length; i++)
            {
                intArray[i] = i;
            }
            Shuffle(intArray);
        }

        public void Shuffle(int[] obj)
        {
            for (int i = 0; i < obj.Length; i++)
            {
                int temp = obj[i];
                int objIndex = Random.Range(0, obj.Length);
                obj[i] = obj[objIndex];
                obj[objIndex] = temp;
            }
        }

        void spawnPortals()
        {
            RandomUnique();
            GameObject thingToSpawn;
            GameObject spawnedThing;
            int finishNum =  Random.Range(0, waypoints.Length);
            
            for(int i=0;i<waypoints.Length;i++)
            {
                if(intArray[0] ==i||intArray[1] ==i||intArray[2] ==i)
                {
                    thingToSpawn = portalModel;
                }
                else if(intArray[3] == i || intArray[4] == i|| intArray[5] == i)
                {
                    thingToSpawn = speedUpModel;
                }
                else
                {
                    thingToSpawn = randomModel;
                }
                spawnedThing = Instantiate(thingToSpawn, waypoints[i].transform.position, Quaternion.Euler(90, 0, 0));
                spawnedThing.transform.parent = transform;
                if(i==intArray[0])
                {
                    spawnedThing.tag = "Finish";
                }
            }
         
            GameObject playerThing = GameObject.FindGameObjectWithTag("Player");
            playerThing.transform.parent = transform;
            playerThing.transform.position = waypoints[1].transform.position + new Vector3(0, 0.018f, 0) ;
            playerThing.GetComponent<GhostScript>().setupProximity();
            GetComponent<portalManager>().startPortals();
        }
        
        public int numSpawned;
        public int numToSpawn;

        IEnumerator spawnNPCWaves(int locNum)
        {
            Vector3 loc = waypoints[locNum].transform.position;
            GameObject thingToSpawn = thingsToSpawn[Random.Range(0, thingsToSpawn.Length)];
            GameObject spawnedThing = Instantiate(thingToSpawn, loc, Quaternion.identity);
            spawnedThing.transform.parent = transform;
            numSpawned++;
            yield return new WaitForSeconds(0.5f);
            if(numSpawned<=numToSpawn)
            {

                StartCoroutine(spawnNPCWaves(locNum));
            }
        }


        public void spawnNPCSetLoc(int locNum)
        {
            //int ran = Random.Range(0, 10);
            Vector3 loc = waypoints[locNum].transform.position;
            GameObject thingToSpawn = thingsToSpawn[Random.Range(0, thingsToSpawn.Length)];
            GameObject spawnedThing = Instantiate(thingToSpawn, loc, Quaternion.identity);
            spawnedThing.transform.parent = transform;
        }

        public void spawnNPC()
        {
            int ran = Random.Range(0, 10);
            Vector3 loc = waypoints[ran].transform.position;
            GameObject thingToSpawn = thingsToSpawn[Random.Range(0, thingsToSpawn.Length)];
            GameObject spawnedThing = Instantiate(thingToSpawn, loc, Quaternion.identity);
            spawnedThing.transform.parent = transform;   
        }
        


    }
}

