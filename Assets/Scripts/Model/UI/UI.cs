using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    #region SINGLETONE

    private static UI _instance;
    public static UI Instance => _instance ?? (_instance = FindObjectOfType<UI>());

    #endregion

    [SerializeField]
    private PanelsUIModel _panels;
    public PanelsUIModel Panels => _panels;

    [SerializeField]
    private TransitionsUIModel _transitions;
    public TransitionsUIModel Transitions => _transitions;
}
