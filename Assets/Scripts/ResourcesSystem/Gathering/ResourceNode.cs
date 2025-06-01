using UnityEngine;

// Assuming PlayerGatheringComponent, ToolData, MaterialData, ResourceNodeData are accessible
// May need to add 'using' statements if they are in namespaces

public class ResourceNode : MonoBehaviour
{
    [Header("Data")]
    public ResourceNodeData nodeData;

    [Header("Runtime State")]
    [SerializeField] private bool _isCurrentlyDepleted = false;
    [SerializeField] private float _currentRespawnTimer = 0f;
    [SerializeField] private float _currentGatherTime = 0f;
    [SerializeField] private bool _isPlayerGathering = false;

    private PlayerGatheringComponent _currentPlayerGathering; // Reference to the player currently gathering

    public bool IsDepleted => _isCurrentlyDepleted;

    void Update()
    {
        if (_isCurrentlyDepleted)
        {
            UpdateRespawnTimer(Time.deltaTime);
        }
        // Player interaction logic (like UpdateGatheringProgress) will be driven by PlayerGatheringComponent's Update
    }

    public void StartGathering(PlayerGatheringComponent player)
    {
        if (_isCurrentlyDepleted || _isPlayerGathering || nodeData == null)
        {
            Debug.LogWarning($"ResourceNode: Cannot start gathering. Depleted: {_isCurrentlyDepleted}, Already Gathering: {_isPlayerGathering}, NodeData Null: {nodeData == null}");
            return;
        }

        _isPlayerGathering = true;
        _currentPlayerGathering = player;
        _currentGatherTime = 0f;
        Debug.Log($"ResourceNode: {player.name} started gathering from {nodeData.nodeName}.");
        // Potentially show some UI feedback or start an animation
    }

    public void StopGathering()
    {
        if (!_isPlayerGathering) return;

        _isPlayerGathering = false;
        // Potentially stop animation or UI feedback
        Debug.Log($"ResourceNode: Gathering stopped at {nodeData.nodeName}.");
        _currentPlayerGathering = null;
    }

    // Called by PlayerGatheringComponent
    public void UpdateGatheringProgress(float deltaTime, ToolData equippedTool)
    {
        if (!_isPlayerGathering || _isCurrentlyDepleted || nodeData == null)
        {
            StopGathering(); // Ensure gathering stops if state is invalid
            return;
        }

        float actualGatherTime = nodeData.baseGatherTime;
        if (equippedTool != null && equippedTool.toolType == nodeData.requiredToolType)
        {
            actualGatherTime /= equippedTool.efficiency * nodeData.toolQualityModifier;
        }
        else if (nodeData.requiredToolType != ToolType.None && nodeData.requiredToolType != ToolType.Hands) // Penalty if wrong tool or no tool for required
        {
            actualGatherTime *= 2f; // Example: Make it twice as slow if wrong/no tool
            Debug.Log($"ResourceNode: Using wrong or no tool. Gathering speed penalized.");
        }


        _currentGatherTime += deltaTime;
        // Debug.Log($"ResourceNode: Gathering progress: {_currentGatherTime}/{actualGatherTime}");

        if (_currentGatherTime >= actualGatherTime)
        {
            YieldResources();
            StopGathering(); // Stop after yielding
        }
    }

    void YieldResources()
    {
        if (nodeData == null || nodeData.resourceMaterial == null)
        {
            Debug.LogError("ResourceNode: NodeData or ResourceMaterial is not set!");
            return;
        }

        int yieldAmount = Random.Range(nodeData.baseYieldMin, nodeData.baseYieldMax + 1);
        // TODO: Modify yieldAmount based on tool efficiency or other factors if desired

        Debug.Log($"Player gathered {yieldAmount} {nodeData.resourceMaterial.materialName} from {nodeData.nodeName}");

        // Placeholder for inventory interaction
        // PlayerInventory.Instance.AddMaterial(nodeData.resourceMaterial, yieldAmount);
        Debug.Log($"Placeholder: PlayerInventory.AddMaterial({nodeData.resourceMaterial.materialName}, {yieldAmount})");

        _isCurrentlyDepleted = true;
        _currentRespawnTimer = nodeData.respawnTime;
        // gameObject.SetActive(false); // Or change appearance to show depletion
        Debug.Log($"ResourceNode: {nodeData.nodeName} is now depleted. Respawning in {nodeData.respawnTime}s.");
    }

    void UpdateRespawnTimer(float deltaTime)
    {
        if (!_isCurrentlyDepleted) return;

        _currentRespawnTimer -= deltaTime;
        if (_currentRespawnTimer <= 0)
        {
            _isCurrentlyDepleted = false;
            _currentRespawnTimer = 0f;
            // gameObject.SetActive(true); // Or change appearance back
            Debug.Log($"ResourceNode: {nodeData.nodeName} has respawned.");
        }
    }

    // Basic interaction method (can be called by a player's interaction script)
    public void OnInteract(PlayerGatheringComponent player)
    {
        if (player == null) return;

        if (_isCurrentlyDepleted)
        {
            Debug.Log($"ResourceNode: {nodeData.nodeName} is currently depleted.");
            // Optionally, provide feedback to player (e.g., UI message)
            return;
        }

        if (_isPlayerGathering && _currentPlayerGathering != player)
        {
            Debug.Log($"ResourceNode: {nodeData.nodeName} is already being gathered by someone else.");
            return;
        }

        if (_isPlayerGathering && _currentPlayerGathering == player) // Player is already gathering this node
        {
            // This click could cancel gathering, or do nothing
            // StopGathering();
            Debug.Log($"ResourceNode: {nodeData.nodeName} is already being gathered by you.");
        }
        else
        {
             // Tool check will be handled by PlayerGatheringComponent before calling StartGathering
            player.TryInteractWithNode(this);
        }
    }

    // Example for direct click interaction if this GameObject has a Collider
    void OnMouseDown()
    {
        // This requires a Player reference. For simplicity, assume a static way to get the player or a player interaction manager.
        // For a more robust solution, player should initiate interaction via raycast or trigger.
        // PlayerGatheringComponent player = FindObjectOfType<PlayerGatheringComponent>(); // Simple, but not always best
        // if (player != null)
        // {
        //    OnInteract(player);
        // }
        Debug.Log($"ResourceNode: OnMouseDown on {name}. Player should initiate interaction via raycast/trigger to call OnInteract().");
    }
}
