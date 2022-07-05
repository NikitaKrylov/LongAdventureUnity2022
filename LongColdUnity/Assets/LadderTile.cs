using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class LadderTile : Tile
{
    public override void RefreshTile(Vector3Int position, ITilemap tilemap)
    {
        base.RefreshTile(position, tilemap);
    }

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        base.GetTileData(position, tilemap, ref tileData);

    }


#if UNITY_EDITOR
    [MenuItem("Assets/Create/2D/Custom Tile/Ladder Tile")]
    public static void CreateLadderTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Variable Tile", "New Tile", "Asset", "Save Variable Tile", "Assets");
        
        if (path == "") return;

        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<LadderTile>(), path);
    }
#endif
}
