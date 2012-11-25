@echo off
set WebDevPath=C:\Program Files (x86)\Common Files\microsoft shared\DevServer\10.0
set ServicePath=C:\GitHub\BUTE-Class-Administration-System\BUTEClassAdministrationSystem\BUTEClassAdministrationService
set Port=8080
set URL=BUTEClassAdministrationService
start /B "" "%WebDevPath%\WebDev.WebServer40.EXE" /port:%Port% /path:%ServicePath% /vpath:/%BUTEClassAdministrationService%
