public class MainMenuPanelVM : PanelViewModel
{ 
    public void OnStartBtnClicked()
    {
        Root.States.GoToState(StateCode.Question);
    }
}
