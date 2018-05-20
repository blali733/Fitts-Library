using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
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

        public override void Deserialize(NetworkReader reader)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(reader.ReadBytesAndSize());
            TestCases = (List<TestCase>) bf.Deserialize(ms);
            ms.Dispose();
        }

        public override void Serialize(NetworkWriter writer)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, TestCases);
            writer.WriteBytesFull(ms.ToArray());
            ms.Dispose();
        }
    }

    public class RawTargetDatasMessage : MessageBase
    {
        public List<TargetData> TargetDatas;

        public RawTargetDatasMessage(List<TargetData> targetDatas)
        {
            TargetDatas = targetDatas;
        }

        public RawTargetDatasMessage() { }

        public override void Deserialize(NetworkReader reader)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(reader.ReadBytesAndSize());
            TargetDatas = (List<TargetData>)bf.Deserialize(ms);
            ms.Dispose();
        }

        public override void Serialize(NetworkWriter writer)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, TargetDatas);
            writer.WriteBytesFull(ms.ToArray());
            ms.Dispose();
        }
    }

    public class TargetInfosMessage : MessageBase
    {
        public List<TargetInfo> TargetInfos;

        public TargetInfosMessage(List<TargetInfo> targetInfos)
        {
            TargetInfos = targetInfos;
        }

        public TargetInfosMessage() { }

        public override void Deserialize(NetworkReader reader)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(reader.ReadBytesAndSize());
            TargetInfos = (List<TargetInfo>)bf.Deserialize(ms);
            ms.Dispose();
        }

        public override void Serialize(NetworkWriter writer)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, TargetInfos);
            writer.WriteBytesFull(ms.ToArray());
            ms.Dispose();
        }
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
