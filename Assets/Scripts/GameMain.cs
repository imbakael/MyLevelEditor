using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour {

    private Camera mainCamera;
    private Transform rangeLayer;
    private List<Transform> rangeTiles = new List<Transform>();
    private Level level;
    private Vector3Int[] rangeRule = new Vector3Int[] { };

    private void Start() {
        mainCamera = Camera.main;
        rangeLayer = GameObject.Find("MapRangeLayer").transform;
        Load("map.txt");
    }

    private void Load(string fileName) {
        var go = new GameObject("Level");
        var level = go.AddComponent<Level>();
        level.InitLevel(fileName);
        go.transform.SetParent(transform);
        this.level = level;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            rangeRule = new Vector3Int[] {
                Vector3Int.zero, Vector3Int.up, Vector3Int.right, Vector3Int.down, Vector3Int.left
            };
        } else if (Input.GetKeyDown(KeyCode.W)) {
            rangeRule = new Vector3Int[] {
                Vector3Int.up, Vector3Int.right, Vector3Int.down, Vector3Int.left, new Vector3Int(1, 1, 0), new Vector3Int(1, -1, 0), new Vector3Int(-1, 1, 0),new Vector3Int(-1, -1, 0)
            };
        }
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int mousePosInMap = level.WorldToGridCoordinates(worldPos);
        if (!level.IsInsideGridBounds(mousePosInMap)) {
            for (int i = 0; i < rangeTiles.Count; i++) {
                Destroy(rangeTiles[i].gameObject);
            }
            rangeTiles.Clear();
            return;
        }
        int validCount = 0;
        for (int i = 0; i < rangeRule.Length; i++) {
            Vector3Int pos = mousePosInMap + rangeRule[i];
            if (level.IsInsideGridBounds(pos.x, pos.y)) {
                if (rangeTiles.Count > validCount) {
                    Transform rangeTile = rangeTiles[validCount];
                    rangeTile.transform.position = pos + new Vector3(0.5f, 0.5f, 0);
                } else {
                    GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    go.transform.SetParent(rangeLayer.transform);
                    go.transform.position = pos + new Vector3(0.5f, 0.5f, 0);
                    rangeTiles.Add(go.transform);
                }
                validCount++;
            }
        }
        if (validCount < rangeTiles.Count) {
            for (int i = rangeTiles.Count - 1; i >= validCount; i--) {
                Destroy(rangeTiles[i].gameObject);
                rangeTiles.RemoveAt(i);
            }
        }
        
    }
}
