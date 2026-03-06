REM dotnet build 5-0\hello-world
REM Removed obsolete/invalid entries: anonymous-id, basic\*, bedrock\echo, and non-existent blazor folder (was causing recursive calls).
REM -------------------------------------------------------------------------------
REM Dynamic section: invoke build.bat in every immediate subfolder (if present)
REM This reduces manual maintenance; failures are tracked via BUILD_ERRORS flag.
REM -------------------------------------------------------------------------------
SETLOCAL ENABLEDELAYEDEXPANSION
SET BUILD_ERRORS=0
FOR /D %%D IN (*) DO (
	IF EXIST "%%D\build.bat" (
		ECHO ========= Building folder: %%D =========
		PUSHD "%%D"
		CALL build.bat
		IF ERRORLEVEL 1 (
			ECHO -------- FAILED: %%D --------
			SET BUILD_ERRORS=1
		)
		POPD
	)
)
IF %BUILD_ERRORS%==1 (
	ECHO One or more subfolder build scripts failed.
) ELSE (
	ECHO All subfolder build scripts completed successfully.
)
ENDLOCAL
REM -------------------------------------------------------------------------------

dotnet build application-environment

dotnet build caching\caching-1
dotnet build caching\caching-2
dotnet build caching\caching-3
dotnet build caching\caching-4
dotnet build caching\redis-cache
dotnet build configurations\configuration-1
dotnet build configurations\configuration-environment-variables
dotnet build configurations\configuration-ini
dotnet build configurations\configuration-ini-options
dotnet build configurations\configuration-options
dotnet build configurations\configuration-xml
dotnet build configurations\configuration-xml-options
dotnet build connection-info
dotnet build dependency-injection\dependency-injection-1
dotnet build dependency-injection\dependency-injection-3
dotnet build device-detection
dotnet build diagnostics\diagnostics-1
dotnet build diagnostics\diagnostics-2
dotnet build diagnostics\diagnostics-3
dotnet build diagnostics\diagnostics-4
dotnet build diagnostics\diagnostics-5
dotnet build diagnostics\diagnostics-6
dotnet build endpoint-routing\endpoint-routing
dotnet build endpoint-routing\endpoint-routing-2
dotnet build endpoint-routing\endpoint-routing-3
dotnet build endpoint-routing\endpoint-routing-4
dotnet build endpoint-routing\endpoint-routing-6
dotnet build endpoint-routing\new-routing
dotnet build endpoint-routing\new-routing-10
dotnet build endpoint-routing\new-routing-11
dotnet build endpoint-routing\new-routing-12
dotnet build endpoint-routing\new-routing-13
dotnet build endpoint-routing\new-routing-14
dotnet build endpoint-routing\new-routing-15
dotnet build endpoint-routing\new-routing-16
dotnet build endpoint-routing\new-routing-17
dotnet build endpoint-routing\new-routing-18
dotnet build endpoint-routing\new-routing-19
dotnet build endpoint-routing\new-routing-2
dotnet build endpoint-routing\new-routing-20
dotnet build endpoint-routing\new-routing-21
dotnet build endpoint-routing\new-routing-22
dotnet build endpoint-routing\new-routing-23
dotnet build endpoint-routing\new-routing-24
dotnet build endpoint-routing\new-routing-25
dotnet build endpoint-routing\new-routing-26
dotnet build endpoint-routing\new-routing-27
dotnet build endpoint-routing\new-routing-28
dotnet build endpoint-routing\new-routing-29
dotnet build endpoint-routing\new-routing-3
dotnet build endpoint-routing\new-routing-30
dotnet build endpoint-routing\new-routing-4
REM Removed due to API changes
REM dotnet build endpoint-routing\new-routing-5
dotnet build endpoint-routing\new-routing-6
dotnet build endpoint-routing\new-routing-7
dotnet build endpoint-routing\new-routing-8
dotnet build endpoint-routing\new-routing-9
dotnet build endpoint-routing\parameter-transformer
dotnet build features\features-connection
dotnet build features\features-http-body-response
dotnet build features\features-max-request-body-size
dotnet build features\features-request-culture
dotnet build features\features-server-addresses
dotnet build features\features-server-addresses-2
dotnet build features\features-server-custom
dotnet build features\features-server-custom-override
dotnet build features\features-server-request
dotnet build features\features-session
dotnet build features\features-session-redis-2
dotnet build file-provider\file-provider-custom
dotnet build file-provider\file-provider-physical
dotnet build file-provider\serve-static-files-1
dotnet build file-provider\serve-static-files-2
dotnet build file-provider\serve-static-files-3
dotnet build file-provider\serve-static-files-4
dotnet build file-provider\serve-static-files-5
dotnet build file-provider\serve-static-files-6
dotnet build generic-host\generic-host-1
dotnet build generic-host\generic-host-2
dotnet build generic-host\generic-host-3
dotnet build generic-host\generic-host-4
dotnet build generic-host\generic-host-5
dotnet build generic-host\generic-host-configure-app
dotnet build generic-host\generic-host-configure-host
dotnet build generic-host\generic-host-configure-logging
dotnet build generic-host\generic-host-environment
dotnet build generic-host\generic-host-ihostapplicationlifetime
dotnet build grpc\grpc\client
dotnet build grpc\grpc\server
dotnet build grpc\grpc-10\client
dotnet build grpc\grpc-10\server
dotnet build grpc\grpc-11\client
dotnet build grpc\grpc-11\server
dotnet build grpc\grpc-2\client
dotnet build grpc\grpc-2\server
dotnet build grpc\grpc-3\client
dotnet build grpc\grpc-3\server
dotnet build grpc\grpc-4\client
dotnet build grpc\grpc-4\server
dotnet build grpc\grpc-5\client
dotnet build grpc\grpc-5\server
dotnet build grpc\grpc-6\client
dotnet build grpc\grpc-6\server
dotnet build grpc\grpc-7\client
dotnet build grpc\grpc-7\server
dotnet build grpc\grpc-8\client
dotnet build grpc\grpc-8\server
dotnet build grpc\grpc-9\client
dotnet build grpc\grpc-9\server
dotnet build health-check\health-check-1
dotnet build health-check\health-check-2
dotnet build health-check\health-check-3
dotnet build health-check\health-check-4
dotnet build health-check\health-check-5
dotnet build health-check\health-check-6
dotnet build httpclientfactory\httpclientfactory-1
dotnet build httpclientfactory\httpclientfactory-2
dotnet build httpclientfactory\httpclientfactory-3
dotnet build httpclientfactory\httpclientfactory-4
dotnet build i-application-lifetime
dotnet build ihosted-service\ihosted-service-1
dotnet build image-sharp
dotnet build json\json
dotnet build json\json-2
dotnet build json\json-3
dotnet build json\json-4
dotnet build json\json-5
dotnet build json\json-6
dotnet build json\json-7
dotnet build json\json-8
dotnet build json\json-9
dotnet build json\json-10
dotnet build json\json-11

dotnet build localization\localization-1
dotnet build localization\localization-2
dotnet build localization\localization-3
dotnet build localization\localization-4
dotnet build localization\localization-5
dotnet build localization\localization-6
dotnet build logging\logging-1
dotnet build logging\logging-2
dotnet build mailkit\mailkit-1
dotnet build mailkit\mailkit-2
dotnet build markdown-server
dotnet build markdown-server-middleware
dotnet build middleware\middleware-0
dotnet build middleware\middleware-1
dotnet build middleware\middleware-10
dotnet build middleware\middleware-11
dotnet build middleware\middleware-12
dotnet build middleware\middleware-13
dotnet build middleware\middleware-2
dotnet build middleware\middleware-3
dotnet build middleware\middleware-4
dotnet build middleware\middleware-5
dotnet build middleware\middleware-6
dotnet build middleware\middleware-7
dotnet build middleware\middleware-8
dotnet build middleware\middleware-9
dotnet build mvc\api-problem-details
dotnet build mvc\api-problem-details-2
dotnet build mvc\api-versioning
dotnet build mvc\hello-world
dotnet build mvc\jwt
dotnet build mvc\model-binding-from-query
dotnet build mvc\model-binding-from-route
dotnet build mvc\mvc-output-xml
dotnet build mvc\nswag
dotnet build mvc\nswag-2
dotnet build mvc\output-formatter-syndication
dotnet build mvc\result-filestream
dotnet build mvc\result-physicalfile
dotnet build mvc\utf8json-formatter
dotnet build orchard-core\multi-tenant\Host
dotnet build orchard-core\routing\ForumModule
dotnet build orchard-core\routing\Host
dotnet build orchard-core\routing\TicketModule
dotnet build orchard-core\routing-2\ForumModule
dotnet build orchard-core\routing-2\Host
dotnet build orchard-core\routing-2\TicketModule
dotnet build orchard-core\static-files\ForumModule
dotnet build orchard-core\static-files\Host
dotnet build password-hasher
dotnet build security\authentication-with-identity\src
dotnet build signalr\signalr-1\Client
dotnet build signalr\signalr-1\Server
dotnet build sse
dotnet build version

dotnet build sfa\wiki


