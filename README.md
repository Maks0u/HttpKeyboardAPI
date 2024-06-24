# HttpKeyboardAPI

A lightweight C# application that provides an HTTP API for simulating keyboard input on Windows systems. This project allows remote triggering of keystrokes through simple HTTP POST requests, enabling automation and remote control scenarios.

Key features:
- HTTP endpoint for receiving key press commands
- Simulates keyboard input using Windows API (keybd_event)
- Supports single and multi-key combinations
- Configurable key codes for flexibility
- Easy to integrate with other applications and scripts

This tool is ideal for remote automation, testing, and any scenario requiring programmatic keyboard input simulation on Windows machines.

### Build release (single .exe file)

```bash
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
```

### Created in a dotnet devcontainer

```bash
dotnet new web -o HttpKeyboardAPI
```
