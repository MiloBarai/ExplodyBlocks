using System.Collections;
using System.Linq;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ExplodyBlocks.Assets.Scripts
{
    public class ObstacleGen : MonoBehaviour
    {

        public Transform player;
        public Transform ground;
        public GameObject obstacle;

        public float obstacleDensity = 1;
        public int obstacleWidthSpawnMax = 3;

        public int initialObstacleSpawnDepth = 8;

        public float obstacleSpawnDistance = 50;

        //Padding for obstacles that the player has passed to be included in looping relocation.
        private float obstacleSpawnDistanceLoopPadding = 5;

        public float loopingOffset = 200;
        public float preSpawnDistance = 200;

        private float lastObstacleSpawn;

        public List<GameObject> obstacles = new List<GameObject>();

        private void Start()
        {
            Vector3 groundScales = ground.localScale;
            float groundXWidth = groundScales.x / 2;

            int obstaclesToSpawn = UnityEngine.Random.Range(1, obstacleWidthSpawnMax);
            float spawningPosition = lastObstacleSpawn + obstacleSpawnDistance;

            Debug.Log("Starting obstacles to spawn: " + obstaclesToSpawn * initialObstacleSpawnDepth);
            for (int j = 0; j < initialObstacleSpawnDepth; j++)
            {
                for (int i = 0; i < obstaclesToSpawn; i++)
                {
                    obstacles.Add(spawnObstacle(groundXWidth, spawningPosition));
                }
                spawningPosition += obstacleSpawnDistance;
            }
        }

        void Update()
        {

            float playerZPosition = player.position.z;
            Vector3 groundScales = ground.localScale;

            if (playerZPosition >= groundScales.z - loopingOffset)
            {
                loopPlayer();
                return;
            }

            if (lastObstacleSpawn > playerZPosition + preSpawnDistance)
            {
                return;
            }

            float groundXWidth = groundScales.x / 2;

            int obstaclesToSpawn = UnityEngine.Random.Range(1, obstacleWidthSpawnMax);
            float spawningPosition = lastObstacleSpawn + obstacleSpawnDistance;

            Debug.Log("Obstacles to spawn: " + obstaclesToSpawn);
            for (int i = 0; i < obstaclesToSpawn; i++)
            {
                obstacles.Add(spawnObstacle(groundXWidth, spawningPosition));
            }

            lastObstacleSpawn = spawningPosition;
        }


        private GameObject spawnObstacle(float groundRange, float spawningPosition)
        {
            float obstacleX = UnityEngine.Random.Range(-groundRange, groundRange);
            return Instantiate(obstacle, new Vector3(obstacleX, 1, spawningPosition), Quaternion.identity);
        }

        private void loopPlayer()
        {
            var obstaclesToKeep = obstacles.Where(obstacle => obstacle.transform.position.z + obstacleSpawnDistanceLoopPadding >= player.position.z).ToList();

            obstacles.Where(obstacle => !obstaclesToKeep.Contains(obstacle))
                     .ToList()
                     .ForEach(obstacle =>
                     {
                         obstacles.Remove(obstacle);
                         Destroy(obstacle);
                     });

            foreach (var obstacleToMove in obstaclesToKeep)
            {
                obstacleToMove.transform.position = calcNewObstaclePosition(obstacleToMove);
            }

            lastObstacleSpawn = obstacles.Last().transform.position.z;
            player.position = new Vector3(player.position.x, player.position.y, 0);
        }

        private Vector3 calcNewObstaclePosition(GameObject obstacle)
        {
            float playerZPos = player.position.z;
            float obstacleXPos = obstacle.transform.position.x;
            float obstacleYPos = obstacle.transform.position.y;
            float obstacleZPos = obstacle.transform.position.z;

            float newObstacleZPos = obstacleZPos - playerZPos;
            return new Vector3(obstacleXPos, obstacleYPos, newObstacleZPos);
        }
    }
}
