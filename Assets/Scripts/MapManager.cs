// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEditor;
//
// public class MapManager : MonoBehaviour
// {
//     public SpriteRenderer sr;
//     public List<Sprite> maps = new List<Sprite>();
//     private int selectedMap = 0;
//     public GameObject map;
//
//     public void NextOption() {
//         selectedMap += 1;
//         if (selectedMap == maps.Count) {
//             selectedMap = 0;
//         }
//         sr.sprite = maps[selectedMap];
//     }
//
//     public void BackOption() {
//         selectedMap -= 1;
//         if (selectedMap < 0) {
//             selectedMap = maps.Count - 1;
//         }
//         sr.sprite = maps[selectedMap];
//     }
//
//     public void PlayGame() {
//         PrefabUtility.SaveAsPrefabAsset(map, "Assets/selectedmap.prefab");
//     }
//
// }
