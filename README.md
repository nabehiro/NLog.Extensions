# NLog.Extensions
This is NLog Extensions. Add ..
- HipChat Target.
- ASP.NET Request Summary Renderer.
- Truncate Renderer.

** NLog.Extensions targets the .NET Framework 4.5, NLog 3.1.0 **

# Quick start
Get Nuget package.
https://www.nuget.org/packages/NLog.Extensions/

```
PM> Install-Package NLog.Extensions
``` 

Below package is useful for Configuration of NLog.
```
PM> Install-Package NLog.Config
```


# HipChat Target.
HipChat notification target requires HipChat API v1.0 (not v2.0!!) auth token and HipChat room ID.

```XML
<targets>
	<!-- if layout contains mension(e.g. @nabehiro), HipChat App(iPhone) can receive message by push notifications. -->
    <target xsi:type="HipChat"
        name="h"
        layout="@nabehiro ${newline} ${truncate:length=800:inner=${message}}"
        authToken="[ enter auth token ]"
        roomId="[ enter room id ]"
        from="hoge"
        color="red" />
</targets>
```

# ASP.NET Request Summary Renderer
Using ASP.NET Request Summary Render, add "${aspnet-request-summary}" into layout.

```XML
<targets>
	<target xsi:type="File"
        name="f"
        fileName="${basedir}/logs/${shortdate}.log"
        encoding="UTF-8"
        layout="${message} ${newline} ${aspnet-request-summary}" />
</targets>
```

output log

```
This is message.

[URL] http://localhost:2291/
[Raw URL] /
[Client IP] ::1
[HTTP Method] GET
[Form]
[Request Headers]
    [Connection] keep-alive
    [Accept] text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8
    [Accept-Encoding] gzip,deflate,sdch
    [Accept-Language] ja,en-US;q=0.8,en;q=0.6
    [Cookie] __RequestVerificationToken=On-lHF-tM1PqycmV97Tif-zfrGALRfpd2aw8E-j4PJO-1CydJZPeiNjcSQCJE777d6NXbGFfBjS_rL-FiGqVdQ5ocK_Zdnp3fCz4Vw7qLzE1; ASP.NET_SessionId=2hou2peqaqavqp4medeaaeyy; token=viLc-fXhIAuvpFf6cvziMVkJAOdFBtyMsrT4z4Y5kuwFlHXmkM0DPY2e9SejeauKcYUcuxEYUlHM1YUGTv8J8D6vmLQ1; auth_shop=CB7F35EE09E49E7726503F1BABBDA8D8FD72DE4B46948385315B0657D663FB8C35C4624E0424F7A7840EFBA04D4118364DF586F9E96F7DA40F7ABEF0438DD470D033FCF9E81C64F97B32EEB3EE9DB0E79AA5E1A63DCFECD1AE6E6734725681F4597B5129EC566CE28F24E9D3203BC85FE03FE433
    [Host] localhost:2291
    [User-Agent] Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.125 Safari/537.36
```
