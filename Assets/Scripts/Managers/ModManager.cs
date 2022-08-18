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

    [Header("Infos")]
    [SerializeField]
    private SortedSet<GameObject> pagesInfo = new SortedSet<GameObject>();
    [SerializeField]
    private SortedSet<GameObject> categoriesInfo = new SortedSet<GameObject>();
    [SerializeField]
    private SortedSet<GameObject> modsInfo = new SortedSet<GameObject>();

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

    
    #region Singleton
    public static ModManager Instance;
    private void Awake(){
        Instance = this;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // Load mods
        // Setup interface

    }

    public static void InstanciatePage(int status) {
        GameObject pagePrefab = Instantiate(Instance.pagePrefab, StatusParent(status));
        Instance.pagesInfo.Add(pagePrefab);

        PageInfo pageInfo = pagePrefab.GetComponent<PageInfo>();
        Page page = pageInfo.Page;
        page.Status = (Status)status;
        pageInfo.Page = page;          
    }

    public static void InstanciateCategory(CategoryInfo categoryInfo) {
        GameObject category = Instantiate(Instance.categoryPrefab);

        category.transform.SetParent(categoryInfo.transform.parent);

        Instance.categoriesInfo.Add(category);
    }

    public static void InstanciateMod(TypeInfo typeInfo) {
        GameObject modInfoPrefab = Instantiate(Instance.modPrefab);

        modInfoPrefab.GetComponent<ModInfo>()
            .Mod.ActionType = typeInfo.ActionType;
        modInfoPrefab.transform.SetParent(typeInfo.transform);

        Instance.modsInfo.Add(modInfoPrefab);
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
