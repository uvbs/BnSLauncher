﻿using System;
using System.IO;
using Microsoft.Win32;
using Ini;

class SettingsClass
{
    string installpath = "";
    string installpathregion = "";
    string modpath = "";
    string localcoockedpcpath = "";
    string notexturestreaming = "";
    string unnatended = "";
    string region = "";
    string languageid = "";
    string useallcores = "";
    string architeture = "";
    string servertype = "";
    string xmlsettings = "";

    IniFile fSettings = new IniFile(Environment.CurrentDirectory + "\\Settings.ini");
    

    // Declare a Name property of type string:
    public string sInstallPath
    {
        get{return installpath;}
        set { installpath = value; }
    }

    public string sInstallPathRegion
    {
        get { return installpathregion; }
        set { installpathregion = value; }
    }
    public string sModPath
    {
        get { return modpath; }
        set { modpath = value; }
    }
    public string sLocalCookedPCPath
    {
        get { return localcoockedpcpath; }
        set { localcoockedpcpath = value; }
    }
    public string sNoTextureStreaming
    {
        get
        {
            notexturestreaming = fSettings.IniReadValue("Settings", "NoTextureStreaming");
            return notexturestreaming;
        }
        set { notexturestreaming = value; }
    }
    public string sUnattended
    {
        get
        {
            unnatended = fSettings.IniReadValue("Settings", "Unattended");
            return unnatended;
        }
        set { unnatended = value; }
    }
    public string sRegion
    {
        get
        {
            region = fSettings.IniReadValue("Settings", "Region");
            if (region == "JP")
            {
                installpath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\plaync\BNS_JPN", "BaseDir", null);
                installpathregion = @"contents\Local\NCJAPAN\";
                localcoockedpcpath = Path.Combine(sInstallPath, sInstallPathRegion, @"JAPANESE\CookedPC\");
                modpath = Path.Combine(sLocalCookedPCPath + @"mod\");
                xmlsettings = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\BnS\NCJAPAN\ClientConfiguration.xml";
            }
            else if (region == "TW")
            {
                installpath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\NCTaiwan\TWBNS22", "BaseDir", null);
                installpathregion = @"contents\Local\NCTAIWAN\";
                localcoockedpcpath = Path.Combine(sInstallPath, sInstallPathRegion, @"CHINESET\CookedPC\");
                modpath = Path.Combine(sLocalCookedPCPath, @"mod\");
                xmlsettings = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\BnS\NCTAIWAN\ClientConfiguration.xml";
            }
            else if (region == "EN")
            {
                installpath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\NCWest\BnS", "BaseDir", null);
                installpathregion = @"contents\Local\NCWEST\";
                localcoockedpcpath = Path.Combine(sInstallPath, sInstallPathRegion, @"ENGLISH\CookedPC\");
                modpath = Path.Combine(localcoockedpcpath, @"mod\");
                xmlsettings = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\BnS\NCWEST\ClientConfiguration.xml";
            }
            else if (region == "KR")
            {
                servertype = fSettings.IniReadValue("Settings", "ServerType");
                if (servertype == "Live")
                {
                    installpath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\plaync\BNS_KOR", "BaseDir", null);
                    installpathregion = @"contents\local\NCSoft\";
                    modpath = Path.Combine(sInstallPath, sInstallPathRegion, @"korean\CookedPC\mod\");
                    localcoockedpcpath = Path.Combine(sInstallPath, @"contents\bns\CookedPC\");
                    xmlsettings = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\BnS\NCSOFT\ClientConfiguration.xml";
                }
                else if (servertype == "Test")
                {
                    installpath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\plaync\BNS_KOR_TEST", "BaseDir", null);
                    installpathregion = @"contents\local\NCSoft\";
                    modpath = Path.Combine(sInstallPath, sInstallPathRegion, @"korean\CookedPC\mod\");
                    localcoockedpcpath = Path.Combine(sInstallPath, @"contents\bns\CookedPC\");
                    xmlsettings = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\BnS\NCSOFT_TEST\ClientConfiguration.xml";
                }
            }
            return region;
        }
        set { region = value; }
    }
    public string sLanguageID
    {
        get
        {
            languageid = fSettings.IniReadValue("Settings", "language");
            return languageid;
        }
        set { languageid = value; }
    }
    public string sUseAllCores
    {
        get
        {
            useallcores = fSettings.IniReadValue("Settings", "UseAllCores");
            return useallcores;
        }
        set { useallcores = value; }
    }
    public string sArchitecture
    {
        get
        {
            architeture = fSettings.IniReadValue("Settings", "Architecture");
            return architeture;
        }
        set { architeture = value; }
    }
    public string sServerType
    {
        get { return servertype; }
        set { servertype = value; }
    }

    public string XmlSettings
    {
        get { return xmlsettings; }
        set { xmlsettings = value; }
    }
}
