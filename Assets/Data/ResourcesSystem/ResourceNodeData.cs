using UnityEngine;

// Assuming ToolType and MaterialData are accessible
// using MyGame.Enums; // If ToolType is in a namespace
// using MyGame.Data; // If MaterialData is in a namespace

[CreateAssetMenu(fileName = "NewResourceNodeData", menuName = "World/Resource Node Data")]
public class ResourceNodeData : ScriptableObject
{
    [Header("Node Identification")]
    public string nodeID; // Unique identifier for this node type
    public string nodeName = "New Resource Node";
    public Sprite icon; // Icon to represent the node in UI or in the world

    [Header("Resource Output")]
    public MaterialData resourceMaterial; // The material this node yields
    public int baseYieldMin = 1;
    public int baseYieldMax = 3;

    [Header("Gathering Parameters")]
    public float baseGatherTime = 2.0f; // Time in seconds to gather once
    public ToolType requiredToolType = ToolType.None; // Tool required to gather
    public float toolQualityModifier = 1.0f; // Affects speed/yield based on tool quality (future use)

    [Header("Respawn Parameters")]
    public float respawnTime = 60.0f; // Time in seconds for the node to respawn after depletion

    // Note: isDepleted is a runtime state and will be managed by ResourceNode.cs, not here.
}
