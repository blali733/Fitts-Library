using System;
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
        public int MaxTargetScale;
        public int MinTargetScale;
        public DistanceMode DistanceMode;
        public float Radius;

        public TestCase(int targetsCount, ColorMode color, DisplayMode displayMode, int maxTargetScale, int minTargetScale, DistanceMode distanceMode, float radius)
        {
            TargetsCount = targetsCount;
            Color = color;
            DisplayMode = displayMode;
            MaxTargetScale = maxTargetScale;
            MinTargetScale = minTargetScale;
            DistanceMode = distanceMode;
            Radius = radius;
        }
    }

    public struct TargetData
    {
        public bool PixelOriented;
        public Color Color;
        public int XPixelPosition, YPixelPosition;
        public float XUnitPosition, YUnitPosition;
        public float UnitSize;
        public int PixelSize;
        public DateTime SpawnTime;
        public DateTime DestroyTime;
        public DateTime Duration;

        public TargetData(Color color, float xUnitPosition, float yUnitPosition, float unitSize, DateTime spawnTime)
        {
            PixelOriented = false;
            Color = color;
            XPixelPosition = 0;
            YPixelPosition = 0;
            XUnitPosition = xUnitPosition;
            YUnitPosition = yUnitPosition;
            UnitSize = unitSize;
            PixelSize = 0;
            SpawnTime = spawnTime;
            DestroyTime = new DateTime();
            Duration = new DateTime();
        }
    }
}