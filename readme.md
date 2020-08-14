# 💻 USB/IP Autoconnect
USB/IP Autoconnect automatically connects a USB device shared via USB/IP and then starts a desired application. After this application is closed, the USB/IP connection is automatically closed and released.

## ❓ Application example - License USB devices:<br>
A software requires a USB stick to validate the license. You have five license USB devices, but more than five workstations. Never more than five workstations work with the software at the same time, but exchanging the USB devices is annoying. Connect all five USB devices to the USB/IP server and define the IP address of the server and the application requiring the license in the config.txt of USB/IP Autoconnect. 

Now simply start the USB/IP Autoconnect application. The software automatically searches for all available license USB devices, connects, waits five seconds and then starts the license requiring application. When you close the application, the USB/IP connection is automatically disconnected and the USB device is available in the pool again. 

## 🚀 Installation & Setup 

### 💫 Requirements:<br>
(1) Running USB/IP server and the ability to connect to the server from the desired device to use the USB devices in the operating system.

(2) Compatible USB device. 

### 💢 How to use:<br>
Download the application and put it in a safe place.
Create another folder with the name `usbip` in this folder. Copy all data required for USB/IP into this folder. The latest USB/IP version for Windows can be found [here](https://github.com/cezanne/usbip-win).<br><br>
Create another folder named `config` and create the file `config.txt` inside the folder. The configuration is structured as follows, separated by semicolons: <br><br>

* Full path to usbip.exe
* IP address of the server
* Path to the desired application
* Process name of the application

Example:<br>
` "C:\usbip\win\usbip.exe";10.0.68.91;"C:\Users\Public\Desktop\Application.lnk";Application `
