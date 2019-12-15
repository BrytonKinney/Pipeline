using System;
using System.IO;
using System.Reflection;
public static class PipeTestHelper
{
    public static string GetFilePath(string relativePath)
    {
        string codeBase = Assembly.GetExecutingAssembly().CodeBase;
        UriBuilder uri = new UriBuilder(codeBase);
        string path = Uri.UnescapeDataString(uri.Path);
        return Path.Combine(Path.GetDirectoryName(path), relativePath);
    }
}