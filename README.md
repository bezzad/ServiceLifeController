# Service Life Controller 
[![GitHub license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/Behzadkhosravifar/ServiceLifeController/blob/master/LICENSE)
[![GitHub license](https://img.shields.io/badge/first--timers--only-friendly-blue.svg)](http://www.firsttimersonly.com/)

Controll windows services life for stopping or running or any else status of service time by notification from 
Email and SMS (by default in based of I.R.Iran Telecommunications System).

This project created by two part of project, first part is a windows service application which controll other OS services by pooling the status of service.
And other parts is a service controller win32 application to bind your choosed services to main win service for life controlling.


---------------------------
### How to use

After the compile you have a folder by name `output` in main directory.
Goto `output\ServiceLifeController\` and execute `ServiceLifeController.exe` file to open **Service Controller** application.
This app can bind your setting to main win service to controll any time and realtime your choosed services.

The **Service Controller** application main form is like this:

![Service Controller](https://raw.githubusercontent.com/Behzadkhosravifar/ServiceLifeController/master/Help/screenshots/ServiceController.png)

In this form you can check any services you want to controlled that. And then you can to choose a stable state to any choosed services to keep that on status.

After all selecting you must to go setting form to save and add your intresting settings to application.
So click on `Setting` button to show this form:

![Setting](https://raw.githubusercontent.com/Behzadkhosravifar/ServiceLifeController/master/Help/screenshots/Setting.png)

In this form set any your setting and at last click on `Save Setting` to save all settings in a json file.
This file path in default is in `ApplicationCommonData` path, and that's called you after saving by a message box.


---------------------------
### Default Setting for Service Life Controller Service

Go to OS drive like `C:\` and go to `ProgramData`

Create a directory by name `ServicesLifeController` and then copy setting.json file from 

`$(ProjectDirectory)\ServiceLifeController\Help\Setting.json`

to

`$(OperationSystemDrive)C:\ProgramData\ServicesLifeController\Setting.json`


----------------------------
### Service Event Logs

For your easy working the application stored any errors, infos, warnings and etc in Windows Event Log to fetch that any time you need them.
To fetch application logs in from windows event log you can click on `Show Event Logs` in main form to open this form:

![Service Event Logs](https://raw.githubusercontent.com/Behzadkhosravifar/ServiceLifeController/master/Help/screenshots/ServiceLogViewer.png)


---------------------------
### Service Life Controller Service

Now, you can install an run `service life controller` service to run main application.

If you want to install or unistall the service of **Service Life Controller** or just run the server without installing, do following commands:

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

----------------------------
### Common Problems in Servers

If you want to use this application in a real Server by a controlled Server Operation System, maybe this application notifications like email is not work!
Because your server OS usually blocked SMTP and HTTP ports.
So you need to open or unblocked some ports that included in below.

For sending an Email, this application use as SMTP protocol.

Simple Mail Transfer Protocol (SMTP) is the standard protocol for sending emails across the Internet.

By default, the SMTP protocol works on three ports:

Port 25 - this is the default SMTP non-encrypted port
Port 2525 - this port is opened on all SiteGround servers in case port 25 is filtered (by your ISP for example) and you want to send non-encrypted emails with SMTP
Port 465 - this is the port used, if you want to send messages using SMTP securely

And for sending SMS from this app you need to open HTTP protocol.