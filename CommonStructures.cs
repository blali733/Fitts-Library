using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SharedTypes
{
    public struct MyNetworkConfig
    {
        public string Address;
        public string Port;

        public MyNetworkConfig(string address, string port)
        {
            this.Address = address;
            this.Port = port;
        }
    }

    public struct TestCase
    {
        public int TargetsCount;
        public ColorMode Color;
        public DisplayMode DisplayMode;
        public float MaxTargetScale;
        public float MinTargetScale;
    }
}