# Backend SSE patch signals - 2

Here we demonstrate how the backend can patch signals through SSE and how the UI reacts with it. The sample adds 3 seconds delays on the SSE response so the changes on the UI is visible. 

In this example we didn't initialize the three signals with values. You can see that all the three signals are assigned default value empty string.

We display the signal using `data-text-`.

```<div data-text="$greeting">Loading...</div>`.

We also use `data-show` to evaluate whether to display an element or not. 

```<div data-show="$showMessage == true">This message is only shown when the signal <code>$showMessage</code> is set to true.</div>```