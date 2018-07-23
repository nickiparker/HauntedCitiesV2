using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

namespace AiGame
{
    public class LondonSetupScript : MonoBehaviour
    {
        public static LondonSetupScript Instance;

       // [SerializeField]
       // private Vector3 BoundsCenter = Vector3.zero;
      //  [SerializeField]
        //private Vector3 BoundsSize = new Vector3(2500, 2500, 2500);
       // [SerializeField]
        //private int SettingsId;
       // [SerializeField]
        //private LayerMask BuildMask;
        //[SerializeField]
        //private LayerMask BuildMaskNonWalk;
        //[SerializeField]
        //private NavMeshData NavMeshData;
        //private NavMeshDataInstance NavMeshDataInstance;
        public GameObject waypointObj;
        public GameObject[] thingsToSpawn;
        public GameObject portalModel;
        public GameObject[] waypoints;
        public GameObject roadSpawn;
        public GameObject ghost;

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
            waypoints = new GameObject[10];
            StartCoroutine("setup");
            
        }

        /**
        public GameObject[] roads;
        public MeshRenderer[] roadsMesh;
        public GameObject roadsObj;

        public GameObject[] ground;
        public MeshRenderer[] groundMesh;
        public GameObject groundObj;


        public GameObject[] building;
        public MeshRenderer[] buildingMesh;
        public GameObject buildingObj;
            */
        IEnumerator setup()
        {
   
            yield return new WaitForSeconds(4);
            
            for(int num=0;num<9;num++)
            {
                //waypoints[num]=Instantiate(waypointObj, RandomNavmeshLocation(10),Quaternion.identity);
                //Place in defined place instead of using random navmesh location

                waypoints[num] = Instantiate(waypointObj, new Vector3(-1.519f, 0.2797f, 6.761f), Quaternion.identity);
                waypoints[num].transform.parent = transform.parent;
            }

            waypoints[0].transform.localPosition = new Vector3(-2.82f, 0.2797f, 5.12f);
            waypoints[1].transform.localPosition = new Vector3(-2.64f, 0.2808849f, -0.302f);
            waypoints[2].transform.localPosition = new Vector3(-9.46f, 0.1833339f, 0.55f);
            waypoints[3].transform.localPosition = new Vector3(-2.03f, 0.3000002f, -2.909342f);
            waypoints[4].transform.localPosition = new Vector3(-2.34f, 0.2666669f, -5.38f);
            waypoints[5].transform.localPosition = new Vector3(-4.44f, 0.26f, 2.65f);
            waypoints[6].transform.localPosition = new Vector3(-8.53f, 0.2750006f, -3.26f);
            waypoints[7].transform.localPosition = new Vector3(-7.32f, 0.341f, 3.9f);
            waypoints[8].transform.localPosition = new Vector3(1.48f, 0.222f, 5.01f);

            waypoints[0].GetComponent<Waypoint>().neighbors.Add(waypoints[8].GetComponent<Waypoint>());
            waypoints[0].GetComponent<Waypoint>().neighbors.Add(waypoints[5].GetComponent<Waypoint>());
            waypoints[0].GetComponent<Waypoint>().neighbors.Add(waypoints[7].GetComponent<Waypoint>());
            waypoints[1].GetComponent<Waypoint>().neighbors.Add(waypoints[3].GetComponent<Waypoint>());
            waypoints[1].GetComponent<Waypoint>().neighbors.Add(waypoints[0].GetComponent<Waypoint>());
            waypoints[1].GetComponent<Waypoint>().neighbors.Add(waypoints[5].GetComponent<Waypoint>());
            waypoints[2].GetComponent<Waypoint>().neighbors.Add(waypoints[5].GetComponent<Waypoint>());
            waypoints[2].GetComponent<Waypoint>().neighbors.Add(waypoints[6].GetComponent<Waypoint>());
            waypoints[3].GetComponent<Waypoint>().neighbors.Add(waypoints[4].GetComponent<Waypoint>());
            waypoints[3].GetComponent<Waypoint>().neighbors.Add(waypoints[1].GetComponent<Waypoint>());
            waypoints[4].GetComponent<Waypoint>().neighbors.Add(waypoints[6].GetComponent<Waypoint>());
            waypoints[4].GetComponent<Waypoint>().neighbors.Add(waypoints[3].GetComponent<Waypoint>());
            waypoints[5].GetComponent<Waypoint>().neighbors.Add(waypoints[2].GetComponent<Waypoint>());
            waypoints[5].GetComponent<Waypoint>().neighbors.Add(waypoints[0].GetComponent<Waypoint>());
            waypoints[5].GetComponent<Waypoint>().neighbors.Add(waypoints[8].GetComponent<Waypoint>());
            waypoints[5].GetComponent<Waypoint>().neighbors.Add(waypoints[1].GetComponent<Waypoint>());
            waypoints[6].GetComponent<Waypoint>().neighbors.Add(waypoints[2].GetComponent<Waypoint>());
            waypoints[7].GetComponent<Waypoint>().neighbors.Add(waypoints[0].GetComponent<Waypoint>());
            waypoints[8].GetComponent<Waypoint>().neighbors.Add(waypoints[0].GetComponent<Waypoint>());
            waypoints[8].GetComponent<Waypoint>().neighbors.Add(waypoints[5].GetComponent<Waypoint>());

            /**
            buildingObj = GameObject.Find("Buildings");
            buildingMesh = buildingObj.GetComponentsInChildren<MeshRenderer>();
            building = new GameObject[buildingMesh.Length];
            int k = 0;
            foreach (MeshRenderer child in buildingMesh)
            {
                //building[k] = child.gameObject;
                child.gameObject.GetComponent<MeshCollider>().convex = true;
                //building[k].layer = LayerMask.NameToLayer("NavMeshAvoid");
                k++;
            }*/
            print(ghost.transform.position);
            print(ghost.transform.localPosition);
            ghost.transform.localPosition = waypoints[1].transform.localPosition;
            print(ghost.transform.position);
            print(ghost.transform.localPosition);

            for (int j=0;j<(numToSpawn/10);j++)
            {
                /**
                spawnNPCSetLoc(0);
                spawnNPCSetLoc(1);
                spawnNPCSetLoc(2);
                spawnNPCSetLoc(3);
                spawnNPCSetLoc(4);
                spawnNPCSetLoc(5);
                spawnNPCSetLoc(6);
                spawnNPCSetLoc(7);
                spawnNPCSetLoc(8);
                spawnNPCSetLoc(9);
                */
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
            //spawnNPC();
            //spawnNPC();
            //spawnNPC();
            //spawnNPC();
            //AddNavMeshData();
        }

        void spawnPortals()
        {
           GameObject spawnedThing = Instantiate(portalModel, waypoints[7].transform.position, Quaternion.Euler(90, 0, 0));
           spawnedThing.transform.parent = transform;
            GameObject playerThing = GameObject.FindGameObjectWithTag("Player");
            playerThing.transform.parent = transform;
            playerThing.transform.position = waypoints[1].transform.position + new Vector3(0, 0.018f, 0) ;

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
        /**
        private void AddNavMeshData()
        {
            if (NavMeshData != null)
            {
                if (NavMeshDataInstance.valid)
                {
                    NavMesh.RemoveNavMeshData(NavMeshDataInstance);
                }
                NavMeshDataInstance = NavMesh.AddNavMeshData(NavMeshData);
            }
        }

        private IEnumerator UpdateNavmeshDataAsync()
        {
            AsyncOperation op = NavMeshBuilder.UpdateNavMeshDataAsync(NavMeshData, GetSettings(), GetNonWalkBuildSources(), GetBounds());
            yield return op;

            AddNavMeshData();
            Debug.Log("Navmesh update complete");
        }
        
        private void Build()
        {
            NavMeshData = NavMeshBuilder.BuildNavMeshData(GetSettings(), GetBuildSources(), GetBounds(), Vector3.zero, Quaternion.identity);
            //NavMeshBuilder.UpdateNavMeshData(NavMeshData, GetSettings(), GetNonWalkBuildSources(), GetBounds());
            AddNavMeshData();
        }

        private List<NavMeshBuildSource> GetBuildSources()
        {
            buildMarkupList = new List<NavMeshBuildMarkup>();
            buildMarkup.area = 0;
            buildMarkup.overrideArea = true;
            buildMarkup.root = groundObj.transform;
            buildMarkupList.Add(buildMarkup);
            buildMarkup2.area = 1;
            buildMarkup2.overrideArea = true;
            buildMarkup.root = buildingObj.transform;
            buildMarkupList.Add(buildMarkup);
            List<NavMeshBuildSource> sources = new List<NavMeshBuildSource>();
            NavMeshBuilder.CollectSources(GetBounds(), BuildMask, NavMeshCollectGeometry.PhysicsColliders, 0, buildMarkupList, sources);
            List<NavMeshBuildSource> sourcesAvoid = new List<NavMeshBuildSource>();
            NavMeshBuilder.CollectSources(GetBounds(), BuildMaskNonWalk, NavMeshCollectGeometry.PhysicsColliders, 1, buildMarkupList, sourcesAvoid);
            sources.AddRange(sourcesAvoid);
            //Debug.LogFormat("Sources {0}", sources.Count);
            return sources;
        }

        
        public NavMeshBuildMarkup buildMarkup;
        public NavMeshBuildMarkup buildMarkup2;
        public List<NavMeshBuildMarkup> buildMarkupList;

        private List<NavMeshBuildSource> GetNonWalkBuildSources()
        {
            buildMarkupList = new List<NavMeshBuildMarkup>();
            buildMarkup.area = 0;
            buildMarkup.overrideArea = true;
            buildMarkupList.Add(buildMarkup);
            List<NavMeshBuildSource> sources = new List<NavMeshBuildSource>();
            NavMeshBuilder.CollectSources(GetBounds(), BuildMaskNonWalk, NavMeshCollectGeometry.PhysicsColliders, 0, buildMarkupList, sources);
            //Debug.LogFormat("Sources {0}", sources.Count);
            return sources;
        }

        private NavMeshBuildSettings GetSettings()
        {
            NavMeshBuildSettings settings = NavMesh.GetSettingsByID(SettingsId);
            print("Settings: height " + settings.agentHeight + " radius " + settings.agentRadius + " minArea " + settings.minRegionArea);
            settings.agentRadius = 0.01f;
            settings.agentHeight = 0.1f;
            settings.voxelSize = 0.02f;
            settings.minRegionArea = 0.01f;
            print("Settings: height " + settings.agentHeight + " radius " + settings.agentRadius + " minArea " + settings.minRegionArea);
            return settings;
        }

        private Bounds GetBounds()
        {
            return new Bounds(BoundsCenter, BoundsSize);
        }

        /**
         * Random navmesh creation- stackoverflow
         *  https://answers.unity.com/questions/475066/how-to-get-a-random-point-on-navmesh.html
         *

        public Vector3 RandomNavmeshLocation(float radius)
        {
            Vector3 randomDirection = Random.insideUnitSphere * radius;
            randomDirection += transform.position;
            NavMeshHit hit;
            Vector3 finalPosition = Vector3.zero;
            if (NavMesh.SamplePosition(randomDirection, out hit, radius, NavMesh.AllAreas))
            {
                finalPosition = hit.position;
            }
            return finalPosition;
        }*/


    }
}

