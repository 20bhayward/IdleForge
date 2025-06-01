using UnityEngine;
using UnityEngine.UI; // Required for ScrollRect (though not directly referenced, good for context)
using System.Collections.Generic;
using TMPro; // If you use TextMeshPro for titles etc.
// Assuming RecipeData.cs and RecipeListItemUI.cs are accessible
// using YourNamespace.Data;
// using YourNamespace.UI.Elements;

public class CraftingMenuController : MonoBehaviour
{
    public GameObject craftingMenuCanvas; // The root Canvas GameObject for the crafting menu
    public Transform scrollViewContentParent; // The 'Content' child of the ScrollView
    public GameObject recipeListItemPrefab; // The RecipeListItemUIPrefab

    // Placeholder list of recipes for testing
    public List<RecipeData> testRecipes = new List<RecipeData>();

    void Start()
    {
        // Initially hide the menu
        if (craftingMenuCanvas != null)
        {
            craftingMenuCanvas.SetActive(false);
        }

        // Create a few sample RecipeData ScriptableObjects for testing if not assigned in Inspector
        // This is just for testing display. In a real scenario, recipes would come from a CraftingManager or similar.
        if (testRecipes == null || testRecipes.Count == 0)
        {
            // Note: Creating ScriptableObject instances at runtime like this is generally for editor tools
            // or testing. For game builds, you'd typically create these as assets in the editor.
            // Since we can't create .asset files directly here without more complex UnityEditor scripting,
            // this part serves as a conceptual guide. The user should create these assets in the Editor.
            // For now, we will assume testRecipes might be populated via the Inspector or later code.
        }

        // Populate with test recipes if any are available
        // The user should create actual RecipeData assets and assign them to testRecipes in the inspector,
        // or you can call PopulateRecipeList from another script with loaded/generated recipes.
        if (testRecipes != null && testRecipes.Count > 0) {
            PopulateRecipeList(testRecipes);
        } else {
            Debug.LogWarning("CraftingMenuController: No test recipes provided. PopulateRecipeList will not be called with data in Start.");
        }
    }

    public void ShowMenu()
    {
        if (craftingMenuCanvas != null)
        {
            craftingMenuCanvas.SetActive(true);
            // Optionally, repopulate if the available recipes might change while menu is hidden
            // if (testRecipes != null && testRecipes.Count > 0) PopulateRecipeList(testRecipes);
        }
        else
        {
            Debug.LogError("CraftingMenuController: CraftingMenuCanvas is not assigned!");
        }
    }

    public void HideMenu()
    {
        if (craftingMenuCanvas != null)
        {
            craftingMenuCanvas.SetActive(false);
        }
        else
        {
            Debug.LogError("CraftingMenuController: CraftingMenuCanvas is not assigned!");
        }
    }

    public void PopulateRecipeList(List<RecipeData> availableRecipes)
    {
        if (scrollViewContentParent == null)
        {
            Debug.LogError("CraftingMenuController: ScrollViewContentParent is not assigned!");
            return;
        }
        if (recipeListItemPrefab == null)
        {
            Debug.LogError("CraftingMenuController: RecipeListItemPrefab is not assigned!");
            return;
        }

        // Clear existing items
        foreach (Transform child in scrollViewContentParent)
        {
            Destroy(child.gameObject);
        }

        if (availableRecipes == null)
        {
            Debug.LogWarning("CraftingMenuController: PopulateRecipeList called with null availableRecipes list.");
            return;
        }

        // Instantiate and setup new items
        foreach (RecipeData recipe in availableRecipes)
        {
            if (recipe == null) continue;

            GameObject itemGO = Instantiate(recipeListItemPrefab, scrollViewContentParent);
            RecipeListItemUI itemUI = itemGO.GetComponent<RecipeListItemUI>();

            if (itemUI != null)
            {
                itemUI.Setup(recipe);
            }
            else
            {
                Debug.LogError("CraftingMenuController: RecipeListItemPrefab is missing the RecipeListItemUI component.", itemGO);
            }
        }
    }

    // Example of how to toggle the menu (e.g., called by a UI button)
    public void ToggleMenu()
    {
        if (craftingMenuCanvas != null)
        {
            if (craftingMenuCanvas.activeSelf)
            {
                HideMenu();
            }
            else
            {
                ShowMenu();
            }
        }
    }
}
