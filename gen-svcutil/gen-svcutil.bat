del *.config
del *.cs
"C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\bin\SvcUtil.exe" /language:cs /out:generatedProxy.cs /config:app.config http://localhost:40640/Service1.svc