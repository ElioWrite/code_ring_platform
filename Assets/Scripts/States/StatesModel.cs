using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatesModel : Model
{
    [SerializeField]
    private List<StateModel> _states;
    public IEnumerable<StateModel> States => _states;

    [SerializeField]
    private StateModel _initialState;

    public StateModel CurrentState { get; private set; }

    public StateCode CurrentStateId => CurrentState == null ? StateCode.None : CurrentState.ID;

    public IEnumerator GoToStateCoroutine(StateCode code)
    {
        var stateModel = GetState(code);

        if (!stateModel) yield break;

        yield return CurrentState?.OnStateEnding();

        CurrentState = stateModel;

        yield return stateModel.OnStateBeginning();
    }

    public void GoToState(StateCode code)
    {
        StartCoroutine(GoToStateCoroutine(code));
    }

    public StateModel GetState(StateCode id) => States.FirstOrDefault(s => s.ID == id);

    private void Awake()
    {
        if(_initialState != null)
            GoToState(_initialState.ID);
    }
}

public enum StateCode
{
    None = 0,
    Initialize = 10,
    Tutorial = 30,
    MainMenu = 40,
    Result = 60,
    Exiting = 100
}
