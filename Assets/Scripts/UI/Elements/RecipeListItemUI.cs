using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro namespace
using System.Text; // For StringBuilder
// Assuming RecipeData.cs is in Assets/Scripts/Data/ or a similar accessible location
// using YourNamespace.Data; // If you have namespaces

public class RecipeListItemUI : MonoBehaviour
{
    public TextMeshProUGUI recipeNameText;
    public Image outputItemIcon;
    public TextMeshProUGUI materialsListText;

    public void Setup(RecipeData recipeData)
    {
        if (recipeData == null)
        {
            if (recipeNameText != null) recipeNameText.text = "N/A";
            if (materialsListText != null) materialsListText.text = "N/A";
            if (outputItemIcon != null) outputItemIcon.sprite = null; // Or a default 'missing' sprite
            return;
        }

        if (recipeNameText != null)
        {
            recipeNameText.text = recipeData.recipeName;
        }

        if (outputItemIcon != null)
        {
            outputItemIcon.sprite = recipeData.outputItemIcon;
            // Optional: if no icon, disable or set to a default
            outputItemIcon.enabled = recipeData.outputItemIcon != null;
        }

        if (materialsListText != null)
        {
            if (recipeData.materials != null && recipeData.materials.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < recipeData.materials.Count; i++)
                {
                    sb.Append(recipeData.materials[i]);
                    if (i < recipeData.materials.Count - 1)
                    {
                        sb.Append(", ");
                            }
                        }
                        materialsListText.text = sb.ToString();
                    }
                    else
                    {
                        materialsListText.text = "No materials required.";
                    }
                }
            }
        }
