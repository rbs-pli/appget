﻿using System.Collections.Generic;

namespace AppGet.Manifests
{
    public class PackageManifest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string ProductUrl { get; set; }

        public string[] Exe { get; set; }
        public InstallMethodType InstallMethod { get; set; }

        public List<Installer> Installers { get; set; }
    }


    public class Artifact
    {
        public ArtifactTypes Type { get; set; }
        public string Path { get; set; }
    }

    public class Installer
    {
        public string Location { get; set; }
        public string Sha1 { get; set; }
        public string Sha256 { get; set; }
        public string Md5 { get; set; }
        public string ZipSubDir { get; set; }

        public ArchitectureType Architecture { get; set; }

        public WindowsVersion MinWindowsVersion { get; set; }
        public WindowsVersion MaxWindowsVersion { get; set; }
        public DotNetVersion MinDotNet { get; set; }

        public List<string> ProductIds { get; set; }

        public Installer()
        {
            ProductIds = new List<string>();
        }
    }

    public enum ArtifactTypes
    {
        Exe,
        Font,
        PowerShellModule,
        FirefoxExtention,
        ChromeExtention,
        Path,
        EnvironmetVariable
    }


    public enum DotNetVersion
    {
        Net10 = 100,
        Net20 = 200,
        Net30 = 300,
        Net35Client = 350,
        Net35 = 351,
        Net40Client = 400,
        Net40 = 401,
        Net45 = 450,
        Net451 = 451,
    }

    public enum ArchitectureType
    {
        Any,
        x86,
        x64,
        Itanium,
        ARM
    }

    public enum InstallMethodType
    {
        Zip,
        MSI,
        Inno,
        InstallShield,
        ClickOnce,
        NSIS
    }
}