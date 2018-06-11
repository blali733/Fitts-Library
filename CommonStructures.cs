﻿using System;
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
        public SerializableColor Color;
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
        public SerializableColor Color;

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

    [Serializable]
    public class User
    {
        public string Name;
        public string TestGroup;

        public User() { }

        public User(string name, string testGroup)
        {
            Name = name;
            TestGroup = testGroup;
        }
    }

    [Serializable]
    public class StoredUser: User
    {
        public int Code;
        public Questionarie Results;

        public StoredUser() { }

        public StoredUser(string name, Questionarie results) : base(name, "")
        {
            Results = results;
            Code = -1;
        }
    }

    [Serializable]
    public struct Questionarie
    {
        public string AgeGroup;
        public string TouchFrequency;
        public bool None;
        public bool Smaller5;
        public bool Smaller11;
        public bool Greater11;
        public string Activities;

        public Questionarie(string ageGroup, string touchFrequency, bool none, bool smaller5, bool smaller11, bool greater11, string activities)
        {
            AgeGroup = ageGroup;
            TouchFrequency = touchFrequency;
            None = none;
            Smaller5 = smaller5;
            Smaller11 = smaller11;
            Greater11 = greater11;
            Activities = activities;
        }
    }
}