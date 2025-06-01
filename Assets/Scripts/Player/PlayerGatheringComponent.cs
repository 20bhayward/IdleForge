using UnityEngine;

// Assuming ToolData and ResourceNode are accessible
// May need to add 'using' statements if they are in namespaces

public class PlayerGatheringComponent : MonoBehaviour
{
    [Header("Tool")]
    public ToolData equippedTool; // Current tool equipped by the player
    // TODO: Implement tool equipping logic (e.g., from an inventory system)

    [Header("Interaction")]
    public float interactionRange = 2.5f; // How far the player can interact with nodes
    private ResourceNode _currentTargetNode;
    private bool _isCurrentlyGathering = false;

    void Update()
    {
        // If actively gathering from a node, update its progress
        if (_isCurrentlyGathering && _currentTargetNode != null)
        {
            if (Vector3.Distance(transform.position, _currentTargetNode.transform.position) > interactionRange)
            {
                // Player moved out of range, stop gathering
                StopGathering();
                return;
            }

            // Check if the node is still valid to gather from (e.g., not depleted by someone else)
            if (_currentTargetNode.IsDepleted)
            {
                StopGathering();
                return;
            }

            _currentTargetNode.UpdateGatheringProgress(Time.deltaTime, equippedTool);
        }

        // Example: Input to stop gathering (optional)
        if (_isCurrentlyGathering && Input.GetKeyDown(KeyCode.Escape)) // Or some other input
        {
            StopGathering();
        }
    }

    // This method would typically be called by a player interaction script (e.g., when pressing an interact button and looking at a node)
    public void AttemptToInteractWithNode(ResourceNode node)
    {
        if (node == null) return;

        if (_isCurrentlyGathering && _currentTargetNode == node)
        {
            // Already gathering this node, could stop or do nothing
            Debug.Log("PlayerGathering: Already gathering this node. Call StopGathering() to cancel.");
            return;
        }

        if (_isCurrentlyGathering && _currentTargetNode != node)
        {
            // Stop gathering from previous node if trying to interact with a new one
            StopGathering();
        }

        TryInteractWithNode(node);
    }


    public void TryInteractWithNode(ResourceNode node)
    {
        if (node == null)
        {
            Debug.LogWarning("PlayerGathering: Target node is null.");
            return;
        }

        if (node.IsDepleted)
        {
            Debug.Log($"PlayerGathering: Node {node.nodeData.nodeName} is depleted.");
            // Optionally provide UI feedback
            return;
        }

        // Check distance
        float distanceToNode = Vector3.Distance(transform.position, node.transform.position);
        if (distanceToNode > interactionRange)
        {
            Debug.Log($"PlayerGathering: Node {node.nodeData.nodeName} is out of range ({distanceToNode}m / {interactionRange}m).");
            // Optionally provide UI feedback
            return;
        }

        // Check tool requirement
        ToolType requiredTool = node.nodeData.requiredToolType;
        bool canGather = false;

        if (requiredTool == ToolType.None || requiredTool == ToolType.Hands)
        {
            canGather = true; // No specific tool or hands required
        }
        else if (equippedTool != null && equippedTool.toolType == requiredTool)
        {
            canGather = true; // Player has the correct tool
        }
        else
        {
            Debug.Log($"PlayerGathering: Incorrect tool for {node.nodeData.nodeName}. Requires {requiredTool}, Player has {(equippedTool != null ? equippedTool.toolType.ToString() : "Nothing")}.");
            // Optionally provide UI feedback (e.g., "Pickaxe Required")
            // Gathering can still proceed but ResourceNode will penalize speed.
            // For strict tool requirement, you would return here.
            // For this implementation, we allow attempting, and the node handles penalties.
            canGather = true; // Allow attempt, node handles penalty
        }

        if (canGather)
        {
            _currentTargetNode = node;
            _isCurrentlyGathering = true;
            _currentTargetNode.StartGathering(this);
            Debug.Log($"PlayerGathering: Started gathering from {node.nodeData.nodeName}.");
        }
    }

    public void StopGathering()
    {
        if (!_isCurrentlyGathering || _currentTargetNode == null) return;

        Debug.Log($"PlayerGathering: Stopped gathering from {_currentTargetNode.nodeData.nodeName}.");
        _currentTargetNode.StopGathering();
        _isCurrentlyGathering = false;
        _currentTargetNode = null;
    }

    // Placeholder for equipping a tool
    public void EquipTool(ToolData newTool)
    {
        equippedTool = newTool;
        Debug.Log($"PlayerGathering: Equipped tool {(newTool != null ? newTool.itemName : "None")}.");
        // TODO: Update player visuals or other relevant game systems
    }

    // Placeholder for unequipping a tool
    public void UnequipTool()
    {
        Debug.Log($"PlayerGathering: Unequipped tool {equippedTool?.itemName}.");
        equippedTool = null;
        // TODO: Update player visuals or other relevant game systems
    }

    void OnDrawGizmosSelected()
    {
        // Draw interaction range in editor for easier debugging
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
