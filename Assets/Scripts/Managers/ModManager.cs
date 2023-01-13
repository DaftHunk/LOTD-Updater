using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ModManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField]
    private GameObject pagePrefab;
    [SerializeField]
    private GameObject categoryPrefab;
    [SerializeField]
    private GameObject modPrefab;

    [Header("StructurePrefabs")]
    [SerializeField]
    private GameObject pageStructurePrefab;
    [SerializeField]
    private GameObject categoryStructurePrefab;

    private static readonly SortedSet<GameObject> pagesInfo = new SortedSet<GameObject>();
    private static readonly SortedSet<GameObject> categoriesInfo = new SortedSet<GameObject>();
    private static readonly SortedSet<GameObject> modsInfo = new SortedSet<GameObject>();

    [Header("Parents")]
    [SerializeField]
    private Transform todoParent;
    [SerializeField]
    private Transform doingParent;
    [SerializeField]
    private Transform testingParent;
    [SerializeField]
    private Transform doneParent;
    [SerializeField]
    private Transform archivedParent;
    [SerializeField]
    private Transform structureParent;

    #region Singleton
    public static ModManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public static void InstanciatePage(Transform structureParent)
    {
        GameObject pageInfoPrefab = Instantiate(
            Instance.pageStructurePrefab,
            structureParent);

        pagesInfo.Add(pageInfoPrefab);
    }

    public static void InstanciatePage(int status)
    {
        GameObject pageInfoPrefab = Instantiate(
            Instance.pagePrefab,
            StatusParent(status));

        pagesInfo.Add(pageInfoPrefab);

        PageInfo pageInfo = pageInfoPrefab.GetComponent<PageInfo>();
        Page page = pageInfo.Page;
        page.Status = (Status)status;
        pageInfo.Page = page;
    }

    public static void InstanciatePage()
    {
        GameObject pageInfoPrefab = Instantiate(
            Instance.pageStructurePrefab,
            Instance.structureParent);

        pagesInfo.Add(pageInfoPrefab);
    }

    public static void InstanciateCategory(Transform pageParent)
    {
        GameObject categoryInfoPrefab = Instantiate(
            Instance.categoryStructurePrefab,
            pageParent);

        categoriesInfo.Add(categoryInfoPrefab);
    }

    public static void InstanciateMod(TypeInfo typeInfo)
    {
        GameObject modInfoPrefab = Instantiate(
            Instance.modPrefab,
            typeInfo.transform);

        modInfoPrefab.GetComponent<ModInfo>()
            .Mod.ActionType = typeInfo.ActionType;

        modsInfo.Add(modInfoPrefab);
    }

    public static Transform StatusParent(int status) => status switch
    {
        0 => Instance.todoParent,
        1 => Instance.doingParent,
        2 => Instance.testingParent,
        3 => Instance.doneParent,
        4 => Instance.archivedParent,
        _ => Instance.todoParent
    };
}
