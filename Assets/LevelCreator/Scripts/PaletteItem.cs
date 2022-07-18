using UnityEngine;

public class PaletteItem : ScriptableObject {

    public enum Category {
        Misc, // Ĭ��������
        Ground, // ����
        BuildingBack, // ��������������ϵĲݡ�ʯͷ���������ľͷ�ѵ�
        Building, // ���� 
        BuildingFront, // ���������罨��ǰ��·����;
        Decoration // װ��
    }

    public string itemName = string.Empty;
    public Sprite sprite;
    public Category category = Category.Misc;
}
