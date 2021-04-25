using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    #region SINGLETONE

    private static Menu _instance;
    public static Menu Instance => _instance ?? (_instance = FindObjectOfType<Menu>());

    #endregion

    [SerializeField]
    private SettingsMenuModel _settingsModel;
    public SettingsMenuModel SettingsModel => _settingsModel;

    [SerializeField]
    private ProgressMenuModel _progressModel;
    public ProgressMenuModel ProgressModel => _progressModel;
}
