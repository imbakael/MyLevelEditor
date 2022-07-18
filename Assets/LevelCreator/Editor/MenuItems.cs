using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class MenuItems {

    [MenuItem("Tools/Level Creator/Show Palette #_p")]
    public static void ShowPalette() {
        PaletteWindow.ShowPalette();
    }

    [MenuItem("Tools/Create PaletteItems")]
    public static void CreateAsset() {
        PaletteCollection paletteCollection = LevelEditorUtils.GetScriptableObjectAsset<PaletteCollection>("Assets/Resources/PaletteCollection.asset");
        List<PaletteItem.Category> categories = LevelUtils.GetListFromEnum<PaletteItem.Category>();
        foreach (PaletteItem.Category item in categories) {
            List<Sprite> sprites = LevelEditorUtils.GetAssets<Sprite>("Assets/Resources/MapRes/" + item);
            for (int i = 0; i < sprites.Count; i++) {
                Sprite sprite = sprites[i];
                PaletteItem p = paletteCollection.GetPaletteItemBySprite(sprite);
                if (p == null) {
                    var paletteItem = ScriptableObject.CreateInstance<PaletteItem>();
                    paletteItem.sprite = sprites[i];
                    paletteItem.category = item;
                    paletteItem.itemName = sprites[i].name;
                    AssetDatabase.CreateAsset(paletteItem, "Assets/Resources/MapTiles/" + paletteItem.itemName + ".asset");
                    paletteCollection.list.Add(paletteItem);
                }
            }
        }
        EditorUtility.SetDirty(paletteCollection);
    }

}
