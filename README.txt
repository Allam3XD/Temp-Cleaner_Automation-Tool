TempCleaner - Windows Temp Folder Automation Tool
=================================================

Overview
--------
TempCleaner is a lightweight C# console application that automatically cleans the Windows temp folder. 
It also displays a Windows notification showing:
- The total size of files deleted.
- The current free space available on the C: drive.

The tool can be scheduled to run automatically (daily, weekly, monthly) using Windows Task Scheduler.

Features
--------
- Deletes files in the Windows temp folder.
- Calculates and displays the size of deleted files.
- Shows current free space on the C: drive.
- Sends a Windows notification popup with results.
- Can be scheduled for automatic execution.

Requirements
------------
- Windows 10/11
- .NET Framework or .NET Core SDK
- Task Scheduler (built into Windows)

How to Run
----------
1. Clone or download this repository.
2. Open the project in Visual Studio or your preferred C# IDE.
3. Build and run the project.
4. To automate execution:
   - Open Task Scheduler.
   - Create a new task and set the trigger (daily/weekly/startup).
   - Set the action to run the compiled TempCleaner executable.

Demo
----
A demo video is available showing how TempCleaner works and integrates with Task Scheduler.


License
-------
This project is open-source. You are free to use and modify it for learning or personal use.
