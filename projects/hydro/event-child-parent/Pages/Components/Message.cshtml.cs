using Hydro;

namespace Events.Pages.Components;
public class Message : HydroComponent
{  
    public string Text { get; set; }    

    public Message()
    {
        Subscribe<MessageChangedEvent>(e => Text = e.Message);
    }
}


