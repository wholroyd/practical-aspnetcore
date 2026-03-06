using Hydro;

namespace HelloWorld.Pages.Components;
public class Message : HydroComponent
{  
    public string Text { get; set; }    

    public void Show(string text)
    {
        Text = text;
    }
}