Log System
==========

DbEntry provides a simple log system.

The log recorder could be defined in the configuration file.

There are some pre-defined recorders.
* ``DebugLogRecorder`` will output the information to debug window in Visual Studio.
* ``ConsoleLogRecorder`` will output the information to console.
* ``TextFileLogRecorder`` will output the information to a text file.
* ``CacheTextFileLogRecorder`` will output the information to a text file by cache it in RAM for 10 secends at first.
* ``DtsFileLogRecorder`` will output the information to a text file with dts format. So we can import it to database later.
* ``DatabaseLogRecorder`` will output the information to a database table named ``Log``, it could be created by auto create table feature.

In ``Logger``, there are some pre-defined loggers in it. Such as SQL, Default and System. 

The ORM part is using SQL logger to log composed SQLs. So we can define a log recorder to log all ORM composed sql to analyze.

The following shows how to use it:

Edit the ``App.config`` as following:

````xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <configSections>
    <section name="Leafing.Settings"
        type="Leafing.Util.Setting.NameValueSectionHandler, Leafing.Util" />
  </configSections>

  <Leafing.Settings>
    <add key="SqlLogRecorder" value="@Console" />
    <add key="DefaultLogRecorder" value="@Console" />
    <add key="SystemLogRecorder" value="@Console" />
  </Leafing.Settings>
</configuration>
````

Log recorder value starts with @ will be consider as pre-definded recorder. Use a self-defined recorder need set the value as the FULLNAME of the recorder type.

And we can use | to set more log recorder(s) in config file as:

````xml
<add key="DefaultLogRecorder" value="@Console | @Debug" />
````

Edit the ``Program.cs`` as following:

````c#
using System;
using Leafing.Util.Logging;

class Program
{
    static void Main(string[] args)
    {
        Logger.SQL.Trace("test 0");
        Logger.Default.Trace("test 1");
        Logger.Default.Warn("test 2");
        Logger.System.Error("test 3");
        Console.ReadLine();
    }
}
````

The result is:

````
Trace,Program.Main(string[] args),SQL,test 0,
Trace,Program.Main(string[] args),Default,test 1,
Warn,Program.Main(string[] args),Default,test 2,
Error,Program.Main(string[] args),System,test 3,
````
