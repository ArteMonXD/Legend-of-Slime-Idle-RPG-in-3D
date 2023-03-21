using UnityEngine;
using UnityEditor;

public class HierarchyUpgrade
{
    [InitializeOnLoadMethod]
    static void ViewPlayer()
    {
        EditorApplication.hierarchyWindowItemOnGUI += ShowPlayerTag;
    }

    static void ShowPlayerTag(int instanceID, Rect selectionRect)
    {
        GameObject current_GO = (GameObject)EditorUtility.InstanceIDToObject(instanceID);

        if (current_GO == null || current_GO.tag != LegendsOfSlime.Global.GlobalConstance.PLAYER_TAG)
            return;

        Rect rect = new Rect(selectionRect);
        rect.width = 42;
        rect.height = 16;
#if UNITY_2019_1_OR_NEWER 
        rect.x = Screen.width - 46;
#else
        rect.x = Screen.width - 20;
#endif

        GUI.Label(rect, "Player");
    }
}
