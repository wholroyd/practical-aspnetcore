# Event handling from a child component to parent

This sample introduce the concept of hydro event communication from child component to parent.

One point of caution, in `MessageButton.cshtml`, it's not enough to have the button tag as a root component because it will disappear once you click the button. You need to have a `div` or other container tag to keep the button rerendered. 

```csharp
<div>
    <button on:click="@(() => Model.Show("This greeting comes from MessageButton component"))">Show</button>
</div>
```