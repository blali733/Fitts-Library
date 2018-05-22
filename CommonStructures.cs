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

    [Serializable]
    public struct TestCase
    {
        public int TargetsCount;
        public ColorMode Color;
        public DisplayMode DisplayMode;
        public int MaxTargetScale;
        public int MinTargetScale;
        public DistanceMode DistanceMode;
        public float Radius;
        public string Name;

        public TestCase(int targetsCount, ColorMode color, DisplayMode displayMode, int maxTargetScale, int minTargetScale, DistanceMode distanceMode, float radius, string name)
        {
            TargetsCount = targetsCount;
            Color = color;
            DisplayMode = displayMode;
            MaxTargetScale = maxTargetScale;
            MinTargetScale = minTargetScale;
            DistanceMode = distanceMode;
            Radius = radius;
            Name = name;
        }
    }

    [Serializable]
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
        public TimeSpan Duration;

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
            Duration = new TimeSpan();
        }
    }

    [Serializable]
    public struct TargetInfo
    {
        public float PixelDistance;
        public float UnitDistance;
        public float UnitSize;
        public int PixelSize;
        public TimeSpan Duration;
        public Color Color;

        public TargetInfo(float pixelDistance, float unitDistance, float unitSize, int pixelSize, TimeSpan duration, Color color)
        {
            PixelDistance = pixelDistance;
            UnitDistance = unitDistance;
            UnitSize = unitSize;
            PixelSize = pixelSize;
            Duration = duration;
            Color = color;
        }

        public TargetInfo(TargetData previousTarget, TargetData currentTarget)
        {
            PixelDistance = Helpers.Distance2D(previousTarget.XPixelPosition, previousTarget.YPixelPosition,
                currentTarget.XPixelPosition, currentTarget.YPixelPosition);
            UnitDistance = Helpers.Distance2D(previousTarget.XUnitPosition, previousTarget.YUnitPosition,
                currentTarget.XUnitPosition, currentTarget.YUnitPosition);
            UnitSize = currentTarget.UnitSize;
            PixelSize = currentTarget.PixelSize;
            Duration = currentTarget.Duration;
            Color = currentTarget.Color;
        }
    }
}