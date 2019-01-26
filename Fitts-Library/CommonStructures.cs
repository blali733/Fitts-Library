using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

namespace FittsLibrary
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
    public class TargetTestCase
    {
        public string Name;
        public DistanceMode DistanceMode;
        public TargetMode TargetMode;
        public DisplayMode DisplayMode;

        public TargetTestCase(string name, DistanceMode distanceMode, TargetMode targetMode, DisplayMode displayMode)
        {
            Name = name;
            DistanceMode = distanceMode;
            TargetMode = targetMode;
            DisplayMode = displayMode;
        }
    }

    [Serializable]
    public class TestCase : TargetTestCase
    {
        public int TargetsCount;
        public ColorMode Color;
        public int MaxTargetScale;
        public int MinTargetScale;
        public float Radius;

        public TestCase(int targetsCount, ColorMode color, DisplayMode displayMode, int maxTargetScale,
            int minTargetScale, DistanceMode distanceMode, float radius, string name, TargetMode targetMode) 
            : base(name, distanceMode, targetMode, displayMode)
        {
            TargetsCount = targetsCount;
            Color = color;
            MaxTargetScale = maxTargetScale;
            MinTargetScale = minTargetScale;
            Radius = radius;
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
        [XmlIgnore]
        public TimeSpan Duration;
        [Browsable(false)]
        [XmlElement(DataType="duration", ElementName="Duration")]
        public string DurationString
        {
            get => XmlConvert.ToString(Duration);
            set => Duration = string.IsNullOrEmpty(value) ?
                TimeSpan.Zero : XmlConvert.ToTimeSpan(value);
        }
        public double ColorDistance;

        public TargetData(Color color, float xUnitPosition, float yUnitPosition, float unitSize, DateTime spawnTime,
            double colorDistance)
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
            ColorDistance = colorDistance;
        }
    }

    [Serializable]
    public struct TargetInfo
    {
        public float PixelDistance;
        public float UnitDistance;
        public float UnitSize;
        public int PixelSize;
        [XmlIgnore]
        public TimeSpan Duration;
        [Browsable(false)]
        [XmlElement(DataType="duration", ElementName="Duration")]
        public string DurationString
        {
            get => XmlConvert.ToString(Duration);
            set => Duration = string.IsNullOrEmpty(value) ?
                TimeSpan.Zero : XmlConvert.ToTimeSpan(value);
        }
        public SerializableColor Color;
        public double ColorDistance;

        public TargetInfo(float pixelDistance, float unitDistance, float unitSize, int pixelSize, TimeSpan duration,
            Color color, double colorDistance)
        {
            PixelDistance = pixelDistance;
            UnitDistance = unitDistance;
            UnitSize = unitSize;
            PixelSize = pixelSize;
            Duration = duration;
            Color = color;
            ColorDistance = colorDistance;
        }

        public TargetInfo(TargetData previousTarget, TargetData currentTarget, double colorDistance)
        {
            PixelDistance = Helpers.Distance2D(previousTarget.XPixelPosition, previousTarget.YPixelPosition,
                currentTarget.XPixelPosition, currentTarget.YPixelPosition);
            UnitDistance = Helpers.Distance2D(previousTarget.XUnitPosition, previousTarget.YUnitPosition,
                currentTarget.XUnitPosition, currentTarget.YUnitPosition);
            UnitSize = currentTarget.UnitSize;
            PixelSize = currentTarget.PixelSize;
            Duration = currentTarget.Duration;
            Color = currentTarget.Color;
            ColorDistance = colorDistance;
        }
    }

    [Serializable]
    public class User
    {
        public string Name;
        public string TestGroup;
        public string Code;

        public User()
        {
        }

        public User(string name, string testGroup, string code)
        {
            Name = name;
            TestGroup = testGroup;
            Code = code;
        }
    }

    [Serializable]
    public class StoredUser : User
    {
        public Questionarie Results;

        public StoredUser()
        {
        }

        public StoredUser(string name, Questionarie results) : base(name, "", "")
        {
            Results = results;
            Code = "";
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
        public string ColorPerception;

        public Questionarie(string ageGroup, string touchFrequency, bool none, bool smaller5, bool smaller11,
            bool greater11, string activities, string colorPerception)
        {
            AgeGroup = ageGroup;
            TouchFrequency = touchFrequency;
            None = none;
            Smaller5 = smaller5;
            Smaller11 = smaller11;
            Greater11 = greater11;
            Activities = activities;
            ColorPerception = colorPerception;
        }
    }

    [Serializable]
    public class DeviceIdentification
    {
        public string DevId;
        public int Id;
        public int ScreenHeight;
        public int ScreenWidth;
        public DeviceClass DeviceClass;

        public DeviceIdentification(DeviceClass deviceClass)
        {
            DeviceClass = deviceClass;
            Id = 0;
            ScreenHeight = Screen.height;
            ScreenWidth = Screen.width;
            DevId = SystemInfo.deviceUniqueIdentifier;
            if (Application.isEditor)
            {
                DevId = $"UnityEditor@{DevId}";
            }

            if (DevId == SystemInfo.unsupportedIdentifier)
            {
                string temp = SystemInfo.deviceType.ToString();
                if (SystemInfo.deviceModel != SystemInfo.unsupportedIdentifier)
                {
                    temp += SystemInfo.deviceModel;
                }

                if (SystemInfo.deviceName != SystemInfo.unsupportedIdentifier)
                {
                    temp += SystemInfo.deviceName;
                }

                temp += SystemInfo.graphicsDeviceName;
                SHA1 sha = new SHA1CryptoServiceProvider();
                DevId = sha.ComputeHash(Encoding.Unicode.GetBytes(temp)).ToString();
                DevId+=SystemInfo.deviceModel;
            }

            DevId = $"{DevId}_{SystemInfo.deviceModel}";
        }
    }

    [Serializable]
    public class ColorRange
    {
        public float Distance;
        public List<SerializableColor> Colors;

        public ColorRange(float distance, List<SerializableColor> colors)
        {
            Distance = distance;
            Colors = colors;
        }

        public ColorRange(float distance, List<List<float>> colors)
        {
            Distance = distance;
            Colors = new List<SerializableColor>();
            foreach (var colorf in colors)
            {
                SerializableColor scolor = new SerializableColor();
                scolor.FromListRGB(colorf);
                Colors.Add(scolor);
            }
        }
    }

    [Serializable]
    public class TargetPoint
    {
        public double Duration;
        public double DifficultyIndex;

        public TargetPoint(double duration, double difficultyIndex)
        {
            Duration = duration;
            DifficultyIndex = difficultyIndex;
        }

        public TargetPoint()
        {
        }
    }

    [Serializable]
    public class TargetSet
    {
        public double ColourDifference;
        public double ParameterA;
        public double ParameterB;
        public List<TargetPoint> TargetPoints;
        public TargetTestCase TestCase;

        public TargetSet()
        {
            TargetPoints = new List<TargetPoint>();
        }

        public TargetSet(double colourDifference, double parameterA, double parameterB, List<TargetPoint> targetPoints, TargetTestCase testCase)
        {
            ColourDifference = colourDifference;
            ParameterA = parameterA;
            ParameterB = parameterB;
            TargetPoints = targetPoints;
            TestCase = testCase;
        }
    }

    [Serializable]
    public class UserResultSet
    {
        public string UID;
        public string DID;
        public List<TargetSet> TargetSets;

        public UserResultSet(string uid, string devId, List<TargetSet> targetSets)
        {
            DID = devId;
            UID = uid;
            TargetSets = targetSets;
        }

        public UserResultSet()
        {
            TargetSets = new List<TargetSet>();
        }
    }
}