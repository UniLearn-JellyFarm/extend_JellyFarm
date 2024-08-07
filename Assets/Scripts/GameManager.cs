using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Sprite[] JellySptriteList; // 2D 그래픽 오브젝트
    public string[] JellyNameList;
    public int[] JellyJelatinList;
    public int[] JellyGoldList;
    public int[] NumGoldList;
    public int[] ClickGoldList;

    public Vector3[] PointList;

    public RuntimeAnimatorController[] LevelAc;

    public void ChangeAc(Animator anim, int level)
    {
        anim.runtimeAnimatorController = LevelAc[level - 1];
        Debug.Log(level);
    }
}
