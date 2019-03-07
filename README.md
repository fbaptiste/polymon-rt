# Polymon-RT
[-- this project is inactive --]
I originally created Polymon-RT as open source in CodePlex.
The original archive can still be found here: https://archive.codeplex.com/?p=polymonrt

Polymon-RT is an offshoot of Polymon and is a real-time monitoring system that allows users to create custom dashboards.
Unlike Polymon, PolyMonRT does not persist monitoring data to a database and therefore does not require a back-end database to function.

## Features:
- Easily customizable dashboards (drag and drop)
- Color coded threshold values
- Polling Intervals fully customizable at individual monitor level
- Fully customizable polling retention time periods at individual monitor level with Min/Max/Avg counters
- Ability to run monitors under a different user than currently logged in user
- Save dashboard definitions to plain text xml files


## Current monitors include:
- PerfMon
- Ping
- PowerShell (custom PowerShell scripts)
- SQL (custom Stored Procedures)
- Monitors can be displayed in a variety of formats:
- Trace Chart
- Dial Gauge
- Linear Gauge (LED style)
- Cylinder Gauge
- Status Light

## Requirements:
- Microsoft .NET 3.5
- WinXP or Vista supported
- PowerShell