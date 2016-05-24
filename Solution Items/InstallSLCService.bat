cd /d %~dp0

"..\output\ServiceLifeControllerService\ServiceLifeControllerService.exe" /i

netsh http add urlacl http://127.0.0.1:50023/ user=EveryOne    

pause