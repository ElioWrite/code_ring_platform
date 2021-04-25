using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TransitionsUIModel : UIModel
{
    [SerializeField]
    private List<TransitionUIModel> _transitions;
    public List<TransitionUIModel> Transitions => _transitions;

    public TransitionUIModel Get(TransitionCode code) 
        => Transitions.FirstOrDefault(t => t.Code == code);

    public T Get<T>() where T : TransitionUIModel => Transitions.OfType<T>().FirstOrDefault();
}

public enum TransitionCode
{
    None,
    Alpha
}
