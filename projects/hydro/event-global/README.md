# Global event handling

This sample introduce the concept of hydro global event communication. It allows a component to publish an event and have any subscribing components to receive it.

One point of caution, in `MessageButton.cshtml`, it's not enough to have the button tag as a root component because it will disappear once you click the button. You need to have a `div` or other container tag to keep the button rerendered. 

```csharp
<div>
    <button on:click="@(() => Model.Show("This greeting comes from MessageButton component"))">Show</button>
</div>
```