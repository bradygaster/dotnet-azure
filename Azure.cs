using System;
using System.IO;

public static class Azure
{
  public static string fileName
  {
    get { return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "rbac.json");}
  }
  public static void CreateServicePrincipalFile()
  {
    var result = ShellHelper.Bash("az ad sp create-for-rbac");

    File.WriteAllText(fileName, result);
  }

  public static bool Login()
  {
    var result = ShellHelper.Bash("az login");
    return result.Contains("You have logged in.");
  }

  public static bool IsLoggedIn()
  {
    var result = ShellHelper.Bash("az account list -o table");
    return result.Contains("az login");
  }
}