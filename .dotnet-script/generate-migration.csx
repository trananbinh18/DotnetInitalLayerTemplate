#!/usr/bin/env dotnet-script
using System;
using System.IO;
using System.Collections.Generic;


string GetCurrentFileName([System.Runtime.CompilerServices.CallerFilePath] string fileName = null)
{
    return fileName;
}

var argsList = Args as IList<string>;

if (argsList.Count == 0)
{
    Console.WriteLine("Usage: dotnet script generate-migration.csx <MigrationName>");
    return;
}

string migrationName = argsList[0];
string timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
string className = $"{migrationName}";
string fileName = $"{timestamp}_{className}.cs";
string scriptDirectory = GetCurrentFileName();
string folderPath = Path.Combine(scriptDirectory, "../../Persistence/Migrations");
if (!Directory.Exists(folderPath))
    Directory.CreateDirectory(folderPath);

string filePath = Path.Combine(folderPath, fileName);

string migrationTemplate = $@"using FluentMigrator;

namespace Persistence.Migrations
{{
    [Migration({timestamp})]
    public class {className} : Migration
    {{
        public override void Up()
        {{
            // Add migration logic here
        }}

        public override void Down()
        {{
            // Add rollback logic here
        }}
    }}
}}";

File.WriteAllText(filePath, migrationTemplate);
Console.WriteLine($"Migration file created: {filePath}");