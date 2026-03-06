using Hydro;

namespace Events.Pages.Components;

public class MessageButton : HydroComponent
{  
    public void Show(string text)
    {
        DispatchGlobal(new MessageChangedEvent(text));
    }
}
