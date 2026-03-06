# Backend SSE patch signals with filterSignals

This page has 3 signals. This sample shows how to use `filterSignals` option to only send specific signals to the backend.

```<h1 data-on-load="@get('/sse', { filterSignals: { include: /^greeting(.)?/ } })">```

Here we set up filterSignals to allow `greeting` and `greeting2` signals to pass through the backend.

