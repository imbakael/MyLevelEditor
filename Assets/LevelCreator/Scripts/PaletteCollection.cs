using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "PaletteCollection", menuName = "CreatePaletteCollection")]
public class PaletteCollection : ScriptableObject
{
    public List<PaletteItem> list = new List<PaletteItem>();

    public List<PaletteItem> GetPaletteItemByCategory(PaletteItem.Category category) {
        return list.Where(t => t.category == category).ToList();
    }

    public PaletteItem GetPaletteItemBySprite(Sprite sprite) {
        return list.Where(t => t.sprite == sprite).FirstOrDefault();
    }
}
