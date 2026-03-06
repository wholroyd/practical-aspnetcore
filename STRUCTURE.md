# Practical ASP.NET Core - Repository Structure

Generated on: 2026-03-06

## Overview

This repository contains practical ASP.NET Core code samples organized by topic.

- **Total Samples**: 637
- **Total Categories**: 72
- **Primary .NET Version**: .NET 10.0 (net10.0)

## .NET Version Distribution

All samples target **.NET 10.0 (net10.0)** as specified in the root `global.json`:

```json
{
  "sdk": {
    "version": "10.0.0",
    "rollForward": "major",
    "allowPrerelease": true
  }
}
```

### Special Cases with Custom SDK Versions

Some categories have their own `global.json` to override the SDK version:

#### blazor-wasm

```json
{
  "sdk": {
    "version": "8.0.100",
    "rollForward": "major"
  }
}```

#### datastar

```json
{
  "sdk": {
    "version": "10.0.100",
    "rollForward": "major"
  }
}```

#### elsa

```json
{
    "sdk": {
      "version": "8.0.100",
      "rollForward": "major"
    }
  }```

#### net10

```json
{
  "sdk": {
    "version": "10.0.100",
    "rollForward": "major"
  }
}```

#### net9

```json
{
  "sdk": {
    "version": "9.0.100",
    "rollForward": "major"
  }
}```

#### orleans

```json
{
  "sdk": {
    "version": "10.0.0-rc.1.25451.107",
    "rollForward": "major",
    "allowPrerelease": true
  }
}```

## Projects Structure

### application-environment (1 samples)


### authentication (5 samples)

  - authentication-1
  - authentication-2
  - authentication-3
  - authentication-4
  - authentication-5

### blazor-ss (16 samples)

  - ChatR
  - ComponentEvents
  - ComponentEvents-2
  - DependencyInjection
  - HelloWorld
  - JsIntegration
  - Layout
  - Localization
  - Localization-2
  - Localization-3
  - Localization-4
  - RenderTreeBuilder
  - RssReader
  - RssReader-2
  - StartingVariation
  - WallOfCounters

### blazor-ssr (25 samples)

  - **RazorComponentEight** (multi-project)
  - RazorComponentEleven
  - RazorComponentFive
  - RazorComponentFour
  - RazorComponentNine
  - RazorComponentOne
  - RazorComponentSeven
  - RazorComponentSix
  - **RazorComponentTen** (multi-project)
  - **RazorComponentThirteen** (multi-project)
  - RazorComponentThree
  - RazorComponentTwelve
  - RazorComponentTwo
  - RazorFormHandlingFive
  - RazorFormHandlingFour
  - RazorFormHandlingOne
  - RazorFormHandlingThree
  - RazorFormHandlingTwo
  - RazorMixMatchFour
  - RazorMixMatchOne
  - RazorMixMatchThree
  - RazorMixMatchTwo

### blazor-wasm (36 samples)

  - Component
  - ComponentEight
  - ComponentEighteen
  - ComponentEleven
  - ComponentFifteen
  - ComponentFive
  - ComponentFour
  - ComponentFourteen
  - ComponentNine
  - ComponentNineteen
  - ComponentSeven
  - ComponentSeventeen
  - ComponentSix
  - ComponentSixteen
  - ComponentTen
  - ComponentThirteen
  - ComponentThree
  - ComponentTwelve
  - **ComponentTwenty** (multi-project)
  - ComponentTwentyFive
  - ComponentTwentyFour
  - **ComponentTwentyOne** (multi-project)
  - ComponentTwentySeven
  - ComponentTwentySix
  - ComponentTwentyThree
  - **ComponentTwentyTwo** (multi-project)
  - ComponentTwo
  - DataBinding
  - DataBindingTwo
  - HelloWorld
  - QuickGridOne
  - RadioButton
  - RenderFragment

### caching (5 samples)

  - caching-1
  - caching-2
  - caching-3
  - caching-4
  - redis-cache

### configurations (10 samples)

  - configuration-1
  - configuration-IOption
  - configuration-IOption-array
  - configuration-bind-option
  - configuration-environment-variables
  - configuration-ini
  - configuration-ini-options
  - configuration-options
  - configuration-xml
  - configuration-xml-options

### connection-info (1 samples)


### corewcf (2 samples)

  - **corewcf-1** (multi-project)

### datastar (21 samples)

  - backend-patch-signals
  - backend-patch-signals-2
  - backend-patch-signals-3
  - backend-patch-signals-4
  - data-attr
  - data-bind
  - data-class
  - data-computed
  - data-effect
  - data-ignore
  - data-indicator
  - data-on-click
  - data-on-custom-event
  - data-on-interval
  - data-on-signal-patch
  - data-on-signal-patch-filter
  - data-patch-elements-outer
  - data-ref
  - data-show
  - data-style
  - hello-world

### dependency-injection (6 samples)

  - dependency-injection-1
  - dependency-injection-2
  - dependency-injection-3
  - dependency-injection-4
  - keyed-service
  - keyed-service-2

### device-detection (1 samples)


### diagnostics (5 samples)

  - diagnostics-1
  - diagnostics-2
  - diagnostics-3
  - diagnostics-4
  - diagnostics-5

### elsa (17 samples)

  - composite-activity
  - for-activity
  - foreach-activity
  - fork-activity
  - fork-activity-2
  - if-activity
  - readline-activity
  - sequence-activity
  - setname-activity
  - setvariable-activity
  - while-activity
  - workflow
  - workflow-2
  - workflow-3
  - workflow-4
  - workflow-5
  - writeline-activity

### endpoint-routing (37 samples)

  - endpoint-routing
  - endpoint-routing-2
  - endpoint-routing-3
  - endpoint-routing-4
  - endpoint-routing-6
  - new-routing
  - new-routing-10
  - new-routing-11
  - new-routing-12
  - new-routing-13
  - new-routing-14
  - new-routing-15
  - new-routing-16
  - new-routing-17
  - new-routing-18
  - new-routing-19
  - new-routing-2
  - new-routing-20
  - new-routing-21
  - new-routing-22
  - new-routing-23
  - new-routing-24
  - new-routing-25
  - new-routing-26
  - new-routing-27
  - new-routing-28
  - new-routing-29
  - new-routing-3
  - new-routing-30
  - new-routing-31
  - new-routing-4
  - new-routing-5
  - new-routing-6
  - new-routing-7
  - new-routing-8
  - new-routing-9
  - parameter-transformer

### exception-handler-middleware (2 samples)

  - iexception-handler
  - iexception-handler-2

### features (11 samples)

  - features-connection
  - features-http-body-response
  - features-max-request-body-size
  - features-request-culture
  - features-server-addresses
  - features-server-addresses-2
  - features-server-custom
  - features-server-custom-override
  - features-server-request
  - features-session
  - features-session-redis-2

### file-provider (10 samples)

  - file-provider-custom
  - file-provider-physical
  - serve-static-files-1
  - serve-static-files-2
  - serve-static-files-3
  - serve-static-files-4
  - serve-static-files-5
  - serve-static-files-6
  - serve-static-files-7
  - serve-static-files-8

### generic-host (10 samples)

  - generic-host-1
  - generic-host-2
  - generic-host-3
  - generic-host-4
  - generic-host-5
  - generic-host-configure-app
  - generic-host-configure-host
  - generic-host-configure-logging
  - generic-host-environment
  - generic-host-ihostapplicationlifetime

### grpc (29 samples)

  - **grpc-10** (multi-project)
  - **grpc-11** (multi-project)
  - **grpc-12** (multi-project)
  - grpc-13
  - grpc-14
  - grpc-15
  - grpc-16
  - grpc-17
  - **grpc-2** (multi-project)
  - **grpc-3** (multi-project)
  - **grpc-4** (multi-project)
  - **grpc-5** (multi-project)
  - **grpc-6** (multi-project)
  - **grpc-7** (multi-project)
  - **grpc-8** (multi-project)
  - **grpc-9** (multi-project)
  - **grpc** (multi-project)

### health-check (6 samples)

  - health-check-1
  - health-check-2
  - health-check-3
  - health-check-4
  - health-check-5
  - health-check-6

### htmx (40 samples)

  - all-verbs
  - boost
  - form
  - form-2
  - header-hx-refresh
  - header-hx-replace-url
  - header-hx-reselect
  - header-hx-retarget
  - header-hx-trigger
  - header-hx-trigger-2
  - header-hx-trigger-3
  - header-hx-trigger-4
  - htmx-after-on-load
  - htmx-config-request
  - htmx-response-error
  - hx-confirm
  - hx-headers
  - hx-include
  - hx-indicator
  - hx-on
  - hx-on-2
  - hx-preserve
  - hx-prompt
  - hx-replace-url
  - hx-replace-url-2
  - hx-sync-queue
  - hx-vals
  - modal-bootstrap
  - push-url
  - query-string
  - select
  - select-2
  - select-oob
  - swap
  - swap-2
  - target
  - trigger-every
  - trigger-load
  - trigger-load-2
  - trigger-once

### httpclientfactory (4 samples)

  - httpclientfactory-1
  - httpclientfactory-2
  - httpclientfactory-3
  - httpclientfactory-4

### hydro (8 samples)

  - component-1
  - component-2
  - component-3
  - cookies
  - event-child-parent
  - event-global
  - event-global-subject
  - hello-world

### i-application-lifetime (1 samples)


### ihosted-service (2 samples)

  - ihosted-service-1
  - ihosted-service-2

### image-sharp (1 samples)


### json (26 samples)

  - json
  - json-10
  - json-11
  - json-12
  - json-13
  - json-14
  - json-15
  - json-16
  - json-17
  - json-18
  - json-19
  - json-2
  - json-20
  - json-21
  - json-22
  - json-23
  - json-24
  - json-25
  - json-26
  - json-3
  - json-4
  - json-5
  - json-6
  - json-7
  - json-8
  - json-9

### localization (6 samples)

  - localization-1
  - localization-2
  - localization-3
  - localization-4
  - localization-5
  - localization-6

### logging (6 samples)

  - logging-1
  - logging-2
  - logging-3
  - logging-4
  - logging-5
  - logging-Loki

### mailkit (2 samples)

  - mailkit-1
  - mailkit-2

### map-short-circuit (1 samples)


### markdown-server-middleware (1 samples)


### markdown-server (1 samples)


### middleware (14 samples)

  - middleware-0
  - middleware-1
  - middleware-10
  - middleware-11
  - middleware-12
  - middleware-13
  - middleware-2
  - middleware-3
  - middleware-4
  - middleware-5
  - middleware-6
  - middleware-7
  - middleware-8
  - middleware-9

### mini (2 samples)

  - **minimal-api-pokedex** (multi-project)
  - pdf-viewer

### minimal-api (40 samples)

  - anti-forgery-1
  - anti-forgery-2
  - **anti-forgery-3** (multi-project)
  - endpoint-filter-1
  - endpoint-filter-2
  - endpoint-filter-3
  - endpoint-filter-4
  - hello-world
  - iform-file
  - iform-file-collection
  - link-generator-path-by-route-name
  - map
  - map-2
  - map-3
  - map-4
  - map-5
  - map-6
  - map-group-1
  - map-group-2
  - map-group-3
  - map-methods
  - map-post
  - map-post-2
  - minimal-api-form-model-binding
  - open-api-1
  - open-api-2
  - parameter-binding-custom-bind-async
  - parameter-binding-custom-try-parse
  - parameter-binding-header-explicit
  - parameter-binding-json-explicit
  - parameter-binding-json-implicit
  - parameter-binding-query-string-explicit
  - parameter-binding-query-string-implicit
  - parameter-binding-route-explicit
  - parameter-binding-route-implicit
  - parameter-binding-special-types
  - route-constraints-decimal
  - route-constraints-int
  - typed-results-1

### minimal-hosting (25 samples)

  - empty-builder
  - slim-builder
  - web-application-builder-change-default-web-root-folder
  - web-application-builder-change-environment
  - web-application-builder-logging-set-minimum-level
  - web-application-builder-mvc
  - web-application-builder-razor-pages
  - web-application-configuration
  - web-application-configuration-json
  - web-application-lifetime-events
  - web-application-logging
  - web-application-middleware
  - web-application-middleware-pipeline
  - web-application-middleware-pipeline-2
  - web-application-options-change-content-root-path
  - web-application-options-set-environment
  - web-application-server-aspnetcore-urls
  - web-application-server-default-urls
  - web-application-server-listen-all
  - web-application-server-multiple-urls-ports
  - web-application-server-port-env-variable
  - web-application-server-specific-url-port
  - web-application-use-file-server
  - web-application-use-web-sockets
  - web-application-welcome-page

### mvc (57 samples)

  - api
  - api-problem-details
  - api-problem-details-2
  - api-versioning
  - hello-world
  - jwt
  - **localization** (multi-project)
  - model-binding-from-query
  - model-binding-from-route
  - mvc-infer-dependency-from-action
  - mvc-output-xml
  - newtonsoft-json
  - nswag
  - nswag-2
  - output-formatter-syndication
  - **razor-class-library** (multi-project)
  - result-filestream
  - result-json
  - result-physicalfile
  - **routing** (multi-project)
  - **tag-helper** (multi-project)
  - **view-component** (multi-project)

### net10 (11 samples)

  - open-api-10
  - open-api-11
  - open-api-8
  - open-api-9
  - redirect-http-result-is-local-url
  - sse-2
  - sse-3
  - sse-4
  - validation-1
  - validation-2
  - validation-3

### net9 (3 samples)

  - open-api-3
  - open-api-4
  - typed-results-2

### open-telemetry (4 samples)

  - open-telemetry-1
  - open-telemetry-2
  - open-telemetry-3
  - open-telemetry-4

### orchard-core (10 samples)

  - decoupled-cms
  - **multi-tenant** (multi-project)
  - **routing-2** (multi-project)
  - **routing** (multi-project)
  - **static-files** (multi-project)

### orleans (13 samples)

  - orleans-1
  - orleans-2
  - orleans-3
  - orleans-4
  - orleans-5
  - reminder
  - rss-reader
  - rss-reader-2
  - rss-reader-3
  - rss-reader-4
  - rss-reader-5
  - rss-reader-6
  - timer

### output-cache-middleware (8 samples)

  - output-cache-1
  - output-cache-2
  - output-cache-3
  - output-cache-4
  - output-cache-5
  - output-cache-6
  - output-cache-7
  - output-cache-8

### password-hasher (1 samples)


### path-string (1 samples)

  - path-string-1

### polly (1 samples)

  - rate-limiter-http-client

### problem-details-middleware (3 samples)

  - problem-details
  - problem-details-2
  - problem-details-3

### razor-pages (10 samples)

  - custom-html-generator
  - handler
  - hello-world
  - razor-pages-basic
  - razor-pages-mvc
  - **razor** (multi-project)
  - routing
  - routing-2
  - temp-data

### razor-slices (1 samples)

  - hello-world

### request-timeouts-middleware (6 samples)

  - request-timeout
  - request-timeout-2
  - request-timeout-3
  - request-timeout-4
  - request-timeout-5
  - request-timeout-6

### request (16 samples)

  - anti-forgery
  - cookies-1
  - cookies-2
  - **cookies-3** (multi-project)
  - form-upload-file
  - form-url-encoded-content
  - form-values
  - query-string-1
  - query-string-2
  - query-string-3
  - query-string-create
  - request-headers
  - request-headers-names
  - request-headers-typed
  - request-verb

### response (3 samples)

  - compression-response
  - response-header
  - trailing-headers

### rewrite (6 samples)

  - rewrite-1
  - rewrite-2
  - rewrite-3
  - rewrite-4
  - rewrite-5
  - rewrite-6

### route-debugger-web (2 samples)

  - RouteDebugger
  - route-debugger-web

### security (7 samples)

  - **authentication-with-identity** (multi-project)
  - **dataprotection** (multi-project)

### sfa (2 samples)

  - remaining-time
  - wiki

### signalr (2 samples)

  - **signalr-1** (multi-project)

### sse (1 samples)


### syndications (3 samples)

  - newsserver-mvc
  - syndication-1
  - syndication-2

### testing (2 samples)

  - **nunit-1** (multi-project)

### unpoly (5 samples)

  - up-flashes
  - up-hungry
  - up-poll
  - up-target
  - up-target-2

### uri-helper (5 samples)

  - uri-helper-build-absolute
  - uri-helper-from-absolute
  - uri-helper-get-display-url
  - uri-helper-get-encoded-path-and-query
  - uri-helper-get-encoded-url

### utils (3 samples)

  - http-status-codes
  - media-type-names
  - media-type-names-2

### version (1 samples)


### web-sockets (6 samples)

  - web-sockets-1
  - web-sockets-2
  - web-sockets-3
  - web-sockets-4
  - web-sockets-5
  - web-sockets-6

### web-utilities (3 samples)

  - web-utilities-query-helpers
  - web-utilities-query-helpers-2
  - web-utilities-reason-phrases

### windows-service (1 samples)

  - windows-service-1

### xml (1 samples)

  - xml-validation

### yarp (3 samples)

  - **basic-demo** (multi-project)

## Exercises

The `exercises/` directory contains learning exercises:

### pathway-1

Contains markdown files with exercise instructions:

- README.md
- exercise-1.md
- exercise-2.md
- exercise-3.md
- exercise-4.md
- exercise-5.md
- exercise-6.md
- exercise-7.md
- exercise-8.md
- exercise-9.md
