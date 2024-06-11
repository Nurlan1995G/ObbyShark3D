using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PositionStaticData))]
public class LevelStaticDataEditor : UnityEditor.Editor
{
    private const string SharkEnemy1 = "SharkPoint1";
    private const string SharkEnemy2 = "SharkPoint2";
    private const string SharkEnemy3 = "SharkPoint3";
    private const string SharkEnemy4 = "SharkPoint4";
    private const string PlayerPointTag = "SpawnPointPlayer";

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        PositionStaticData levelData = (PositionStaticData)target;

        if (GUILayout.Button("Collect"))
        {
            levelData.InitSharkOnePosition = GameObject.FindWithTag(SharkEnemy1).transform.position;
            levelData.InitSharkTwoPosition = GameObject.FindWithTag(SharkEnemy2).transform.position;
            levelData.InitSharkThreePosition = GameObject.FindWithTag(SharkEnemy3).transform.position;
            levelData.InitSharkFourPosition = GameObject.FindWithTag(SharkEnemy4).transform.position;
            levelData.InitPlayerPosition = GameObject.FindWithTag(PlayerPointTag).transform.position;
        }

        EditorUtility.SetDirty(target);
    }
}
