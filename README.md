# Service Life Controller 
[![Build status](https://ci.appveyor.com/api/projects/status/qs8hglln9b55nyk4?svg=true)](https://ci.appveyor.com/project/Behzadkhosravifar/signalr)
[![GitHub license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/Behzadkhosravifar/SignalR/blob/master/LICENSE)
[![GitHub license](https://img.shields.io/badge/first--timers--only-friendly-blue.svg)](http://www.firsttimersonly.com/)

A reusable win32 API  for connect any client to server or each other clients. Send data or code from one client to other clients included.

---------------------------
### Service Life Controller Server
If you want to install or unistall a service for signalR server or just run the server without installing, do following commands:

* Install signalR service: <br/>
	`$ SignalR\Out\SignalR\Core.Server\SignalRServer.exe /i` <br/>
	or <br/>
	`$ SignalR\Solution Items\InstallSignalRService.bat`


* Uninstall signalR service: <br/>
	`$ SignalR\Out\SignalR\Core.Server\SignalRServer.exe /u` <br/>
	or <br/>
	`$ SignalR\Solution Items\UninstallSignalRService.bat`


* Delete signalR service: <br/>
	`$ SignalR\Solution Items\DeleteSignalRService.bat`


* Execute signalR server (without install service): <br/>
	`$ SignalR\Out\SignalR\Core.Server\SignalRServer.exe /d` <br/>
	or <br/>
	`$ SignalR\Solution Items\RunServiceOnWPF.bat`

	![wpfServer](https://raw.githubusercontent.com/Behzadkhosravifar/SignalR/master/img/wpfServer.PNG)

--------------------------
### Service Life Controller Clients
A sample project in win32 for present signalR client

![clients](https://raw.githubusercontent.com/Behzadkhosravifar/SignalR/master/img/clients.PNG)


### Service Life Controller Clients Controller
The clients controller in fact is a signalR client, but this project can be controll all signalR clients in network.

For e.x:
![clientsController](https://raw.githubusercontent.com/Behzadkhosravifar/SignalR/master/img/clientsController.png)

In this application you can fetch any events of server from server windows logs by clicking on `Show Server Event Logs`
![logViewer](https://raw.githubusercontent.com/Behzadkhosravifar/SignalR/master/img/logViewer.png)

And by selecting one client in from list you can to control that by this form:
![ControlUser](https://raw.githubusercontent.com/Behzadkhosravifar/SignalR/master/img/selectedUserController.png)

In `Control User` form you can to send a message to selected users or execute an stored procedure on that clients. <br/>
By click on `Custom Procedure` you should see this form:
![dynamicCodeExec](https://raw.githubusercontent.com/Behzadkhosravifar/SignalR/master/img/dynamicCodeExec.PNG)

In `Runtime Dynamic Compiler` form you can type your c# codes to executed on selected users system.
