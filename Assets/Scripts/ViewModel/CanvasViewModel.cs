using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Canvas))]
public class CanvasViewModel : UIViewModel
{
    private Canvas _canvasCached;
    public Canvas CanvasCached => _canvasCached ?? (_canvasCached = GetComponent<Canvas>());

    [SerializeField]
    private EventSystem _eventSystem;
    public EventSystem EventSystem => _eventSystem;
}