# Polly Rate Limiting with Retry

You can find the policy for rate limiting and retry at `Program.cs`.

- In this case, we only allow max 20 concurrent requests - anything beyond that will be queue maximum to 50. If it exceed this queue, `RateLimiterRejectedException` will be thrown.
- We will retry maximum 3 times if the http request status is not `200`.
- We will retry also if `RateLimiterRejectedException` is thrown.