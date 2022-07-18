using UnityEngine;

public class PaletteItem : ScriptableObject {

    public enum Category {
        Misc, // 默认是杂项
        Ground, // 地面
        BuildingBack, // 被建筑挡，如地上的草、石头、建筑后的木头堆等
        Building, // 建筑 
        BuildingFront, // 挡建筑，如建筑前的路标牌;
        Decoration // 装饰
    }

    public string itemName = string.Empty;
    public Sprite sprite;
    public Category category = Category.Misc;
}
