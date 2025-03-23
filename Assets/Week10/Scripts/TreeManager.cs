using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour
{
    public CoroutineGrower[] trees;

    public void StartGrowingTrees()
    {
        StartCoroutine(GrowAllTrees());
    }

    IEnumerator GrowAllTrees()
    { 
        yield return StartCoroutine(trees[0].Grow());
        yield return StartCoroutine(trees[1].Grow());
        yield return StartCoroutine(trees[2].Grow());
    }

}
