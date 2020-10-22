# CsvComparer
Simple console application for comparing two csv files 

## Setup
In the Program.cs file you can define the two files that should be compared. The output is writen to a log file.

```
private static readonly char _separator = ';';
private static readonly string _filePath1 = @"C:\Path\To\File1.CSV";
private static readonly string _filePath2 = @"C:\Path\To\File2.CSV";
private static readonly string _logFile = @"C:\Path\To\Log.txt";
```
