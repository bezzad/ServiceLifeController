# Service Life Controller 
[![GitHub license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/Behzadkhosravifar/ServiceLifeController/blob/master/LICENSE)
[![GitHub license](https://img.shields.io/badge/first--timers--only-friendly-blue.svg)](http://www.firsttimersonly.com/)

Controll windows services life for stopping or running or any else status of service time by notification from 
Email and SMS (by defaulte in based of I.R.Iran Telecommunications System).

This project created by two part of project, first part is a windows service which controll other OS services by pooling the status of service.


---------------------------
### How to use
After the compile you have a folder by name `output` in main directory.
Goto `output\ServiceLifeController\` and execute `ServiceLifeController.exe` file to open **Service Controller** application.
This app can bind your setting to main win service to controll any time and realtime your choosed services.

The **Service Controller** application main form is like this: <br>
![Service Controller]()
---------------------------
### Service Life Controller Server
If you want to install or unistall a service for Service Life Controller service or just run the server without installing, do following commands:

* Install Service Life Controller Service: <br/>
	`$ ServiceLifeController\Output\ServiceLifeControllerService\ServiceLifeControllerService.exe /i` <br/>
	or <br/>
	`$ ServiceLifeController\Solution Items\InstallService.bat`


* Uninstall Service Life Controller Service: <br/>
	`$ ServiceLifeController\Output\ServiceLifeControllerService\ServiceLifeControllerService.exe /u` <br/>
	or <br/>
	`$ ServiceLifeController\Solution Items\UninstallSignalRService.bat`


* Delete Service Life Controller Service: <br/>
	`$ ServiceLifeController\Solution Items\DeleteSignalRService.bat`


* Execute Service Life Controller Service (without install service): <br/>
	`$ ServiceLifeController\Output\ServiceLifeControllerService\ServiceLifeControllerService.exe /d` <br/>
	or <br/>
	`$ ServiceLifeController\Solution Items\RunServiceOnWPF.bat`

	![wpfServer](https://raw.githubusercontent.com/Behzadkhosravifar/SignalR/master/img/wpfServer.PNG)

--------------------------
### Service Life Controller Clients
A sample project in win32 for present and controll Service Life Controller service

![clients](https://raw.githubusercontent.com/Behzadkhosravifar/SignalR/master/img/clients.PNG)

### Default Setting for Service Life Controller Service

Go to OS drive like `C:\` and go to `ProgramData`

Create a directory by name `ServicesLifeController` and then copy setting.json file from 

`$(ProjectDirectory)\ServiceLifeController\Help\Setting.json`

to

`$(OperationSystemDrive)C:\ProgramData\ServicesLifeController\Setting.json`