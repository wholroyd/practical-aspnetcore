# Backend SSE patch signals

Here we demonstrate how the backend can patch signals through SSE and how the UI reacts with it. The sample adds 3 seconds delays on the SSE response so the changes on the UI is visible. 

In this example we started with the following available signals at a starting point.

```<body class="container" data-signals="{greeting:'hello world', greeting2:'greetings earthlings'}">```

We display the signal using `data-text-`.

```<div data-text="$greeting">Loading...</div>`.