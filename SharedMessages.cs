using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using SharedTypes;
using UnityEngine.Networking;

namespace SharedMessages
{
    public class MyMsgType
    {
        public static short TestCases = MsgType.Highest + 1;
        public static short TargetDatas = MsgType.Highest + 1;
        public static short TargetInfos = MsgType.Highest + 1;
    }

    public class TestCasesMessage : MessageBase
    {
        public List<TestCase> TestCases;

        public TestCasesMessage(List<TestCase> testCases)
        {
            TestCases = testCases;
        }

        public TestCasesMessage() { }
    }

    public class RawTargetDatasMessage : MessageBase
    {
        public List<TargetData> TargetDatas;

        public RawTargetDatasMessage(List<TargetData> targetDatas)
        {
            TargetDatas = targetDatas;
        }

        public RawTargetDatasMessage() { }
    }

    public class TargetInfosMessage : MessageBase
    {
        public List<TargetInfo> TargetInfos;

        public TargetInfosMessage(List<TargetInfo> targetInfos)
        {
            TargetInfos = targetInfos;
        }

        public TargetInfosMessage() { }
    }

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
