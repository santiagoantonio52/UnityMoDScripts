﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{

    public GameObject theTree;
    public TerrainData theIsland;

    // Use this for initialization
    void Start()
    {
        // Grab the island's terrain data
        // theIsland = GameObject.Find("PrimeIsland").GetComponent<Terrain>().terrainData;
        // For every tree on the island
        foreach (TreeInstance tree in theIsland.treeInstances)
        {
            // Find its local position scaled by the terrain size (to find the real world position)
            Vector3 worldTreePos = Vector3.Scale(tree.position, theIsland.size) + Terrain.activeTerrain.transform.position;
            Instantiate(theTree, worldTreePos, Quaternion.identity); // Create a prefab tree on its pos
        }
        // Then delete all trees on the island
        List<TreeInstance> newTrees = new List<TreeInstance>(0);
        theIsland.treeInstances = newTrees.ToArray();
    }
}
