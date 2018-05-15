using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MyNetworkConfig
{
    public string address;
    public string port;
    public MyNetworkConfig(string address, string port)
    {
        this.address = address;
        this.port = port;
    }
}

public struct TestCase
{
    public int targets;
    public int 
}