using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    public Vector3 noTerrainPosition;
    public LayerMask terrainMask;
    public GameObject currentChunk;
    PlayerMovement pm;

    [Header("Optimization")]
    public List<GameObject> spawnedChunks;
    GameObject latestChunk;
    public float maxOpDist; // Must be greater than the length and width of the tilemap
    float opDist;
    float optimizerCooldown;
    public float optimizerCooldownDur;
    public float chunkSize;

    void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        ChunkChecker();
        ChunkOptimizer();
    }

    void ChunkChecker()
    {
        if (!currentChunk)
        {
            return;
        }

        if (pm.moveDir.y != 0 || pm.moveDir.x != 0)
        {
            Vector3 Up = currentChunk.transform.position + new Vector3(0, chunkSize, 0);
            Vector3 Down = currentChunk.transform.position + new Vector3(0, -chunkSize, 0);
            Vector3 Right = currentChunk.transform.position + new Vector3(chunkSize, 0, 0);
            Vector3 Left = currentChunk.transform.position + new Vector3(-chunkSize, 0, 0);
            Vector3 UpRight = currentChunk.transform.position + new Vector3(chunkSize, chunkSize, 0);
            Vector3 UpLeft = currentChunk.transform.position + new Vector3(-chunkSize, chunkSize, 0);
            Vector3 DownRight = currentChunk.transform.position + new Vector3(chunkSize, -chunkSize, 0);
            Vector3 DownLeft = currentChunk.transform.position + new Vector3(-chunkSize, -chunkSize, 0);

            if (!Physics2D.OverlapCircle(Up, checkerRadius, terrainMask))
            {
                SpawnChunk(Up);
            }
            if (!Physics2D.OverlapCircle(Down, checkerRadius, terrainMask))
            {
                SpawnChunk(Down);
            }
            if (!Physics2D.OverlapCircle(Right, checkerRadius, terrainMask))
            {
                SpawnChunk(Right);
            }
            if (!Physics2D.OverlapCircle(Left, checkerRadius, terrainMask))
            {
                SpawnChunk(Left);
            }
            if (!Physics2D.OverlapCircle(UpRight, checkerRadius, terrainMask))
            {
                SpawnChunk(UpRight);
            }
            if (!Physics2D.OverlapCircle(UpLeft, checkerRadius, terrainMask))
            {
                SpawnChunk(UpLeft);
            }
            if (!Physics2D.OverlapCircle(DownRight, checkerRadius, terrainMask))
            {
                SpawnChunk(DownRight);
            }
            if (!Physics2D.OverlapCircle(DownLeft, checkerRadius, terrainMask))
            {
                SpawnChunk(DownLeft);
            }
        }
    }

    void SpawnChunk(Vector3 position) // Added position parameter
    {
        int rand = Random.Range(0, terrainChunks.Count);
        latestChunk = Instantiate(terrainChunks[rand], position, Quaternion.identity); // Used the position parameter
        spawnedChunks.Add(latestChunk);
    }

    void ChunkOptimizer()
    {
        optimizerCooldown -= Time.deltaTime;

        if (optimizerCooldown <= 0f)
        {
            optimizerCooldown = optimizerCooldownDur;
        }
        else
        {
            return;
        }

        foreach (GameObject chunk in spawnedChunks)
        {
            opDist = Vector3.Distance(player.transform.position, chunk.transform.position);
            if (opDist > maxOpDist)
            {
                chunk.SetActive(false);
            }
            else
            {
                chunk.SetActive(true);
            }
        }
    }
}

