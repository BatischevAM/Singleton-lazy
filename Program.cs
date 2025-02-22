﻿using Servers;

public class Program
{
    public static void Main()
    {
        var servers = server.Singleton;

        Console.WriteLine(servers.AddServer("http://apple.com"));
        Console.WriteLine(servers.AddServer("https://explorer.com"));
        Console.WriteLine(servers.AddServer("https://explorer.com"));
        Console.WriteLine(servers.AddServer("https://lore.com"));
        Console.WriteLine(servers.AddServer("ftp://axe.com"));
        Console.WriteLine(servers.AddServer("http://apple.com"));
        Console.WriteLine(servers.AddServer("htts://explorer.com"));

        var httpServers = servers.GetHttpServers();
        var httpsServers = servers.GetHttpsServers();

        Console.WriteLine("HTTP Servers:");
        foreach (var server in httpServers)
        {
            Console.WriteLine(server);
        }

        Console.WriteLine("HTTPS Servers:");
        foreach (var server in httpsServers)
        {
            Console.WriteLine(server);
        }
    }
}