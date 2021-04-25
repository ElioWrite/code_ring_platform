using System.Collections;
using UnityEngine;

public abstract class StateModel : Model
{
    public UI UI => UI.Instance;

    [SerializeField]
    private StateCode _id;
    public StateCode ID => _id;


    public virtual IEnumerator OnStateBeginning()
    {
        Debug.Log(string.Format("Entry to {0} State", ID));

        yield return null;
    }

    public virtual IEnumerator OnStateEnding()
    {
        Debug.Log(string.Format("Exit from {0} State", ID));

        yield return null;
    }

}
