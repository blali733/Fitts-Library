using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Networking;

namespace FittsLibrary.Messages
{
    public class MyMsgType
    {
        public static short TestCases = MsgType.Highest + 1;
        public static short TargetDatas = MsgType.Highest + 2;
        public static short TargetInfos = MsgType.Highest + 3;
        public static short UserList = MsgType.Highest + 4;
        public static short DataRequest = MsgType.Highest + 5;
        public static short NewUserData = MsgType.Highest + 6;
        public static short DeviceData = MsgType.Highest + 7;
        public static short DeviceId = MsgType.Highest + 8;
        public static short ColorRanges = MsgType.Highest + 9;
        public static short UserCode = MsgType.Highest + 10;
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
        [Serializable]
        public struct Pack
        {
            public List<List<TargetData>> TargetDatas;
            public string User;

            public Pack(List<List<TargetData>> targetDatas, string user)
            {
                TargetDatas = targetDatas;
                User = user;
            }
        }

        public Pack Content;

        public RawTargetDatasMessage(List<List<TargetData>> targetDatas, string user)
        {
            Content = new Pack(targetDatas, user);
        }

        public RawTargetDatasMessage() { }

        public override void Deserialize(NetworkReader reader)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(reader.ReadBytesAndSize());
            Content = (Pack)bf.Deserialize(ms);
            ms.Dispose();
        }

        public override void Serialize(NetworkWriter writer)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, Content);
            writer.WriteBytesFull(ms.ToArray());
            ms.Dispose();
        }
    }

    public class TargetInfosMessage : MessageBase
    {
        [Serializable]
        public struct Pack
        {
            public List<List<TargetInfo>> TargetInfos;
            public string User;
            public string DevId;

            public Pack(List<List<TargetInfo>> targetDatas, string user, string devId)
            {
                TargetInfos = targetDatas;
                User = user;
                DevId = devId;
            }
        }

        public Pack Content;

        public TargetInfosMessage(List<List<TargetInfo>> targetInfos, string user, string devId)
        {
            Content = new Pack(targetInfos, user, devId);
        }

        public TargetInfosMessage() { }

        public override void Deserialize(NetworkReader reader)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(reader.ReadBytesAndSize());
            Content = (Pack)bf.Deserialize(ms);
            ms.Dispose();
        }

        public override void Serialize(NetworkWriter writer)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, Content);
            writer.WriteBytesFull(ms.ToArray());
            ms.Dispose();
        }
    }

    public class UserListMessage : MessageBase
    {
        public List<User> UserList;

        public UserListMessage() { }

        public UserListMessage(List<User> userList)
        {
            UserList = userList;
        }

        public override void Deserialize(NetworkReader reader)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(reader.ReadBytesAndSize());
            UserList = (List<User>)bf.Deserialize(ms);
            ms.Dispose();
        }

        public override void Serialize(NetworkWriter writer)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, UserList);
            writer.WriteBytesFull(ms.ToArray());
            ms.Dispose();
        }
    }

    public class RequestMessage : MessageBase
    {
        public RequestType Type;

        public RequestMessage() { }

        public RequestMessage(RequestType type)
        {
            Type = type;
        }

        public override void Deserialize(NetworkReader reader)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(reader.ReadBytesAndSize());
            Type = (RequestType)bf.Deserialize(ms);
            ms.Dispose();
        }

        public override void Serialize(NetworkWriter writer)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, Type);
            writer.WriteBytesFull(ms.ToArray());
            ms.Dispose();
        }
    }

    public class StoredUserMessage : MessageBase
    {
        public StoredUser User;

        public StoredUserMessage() { }

        public StoredUserMessage(StoredUser user)
        {
            User = user;
        }

        public override void Deserialize(NetworkReader reader)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(reader.ReadBytesAndSize());
            User = (StoredUser)bf.Deserialize(ms);
            ms.Dispose();
        }

        public override void Serialize(NetworkWriter writer)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, User);
            writer.WriteBytesFull(ms.ToArray());
            ms.Dispose();
        }
    }

    public class DeviceDataMessage : MessageBase
    {
        public DeviceIdentification DeviceIdentification;

        public DeviceDataMessage() { }

        public DeviceDataMessage(DeviceIdentification deviceIdentification)
        {
            DeviceIdentification = deviceIdentification;
        }

        public override void Deserialize(NetworkReader reader)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(reader.ReadBytesAndSize());
            DeviceIdentification = (DeviceIdentification)bf.Deserialize(ms);
            ms.Dispose();
        }

        public override void Serialize(NetworkWriter writer)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, DeviceIdentification);
            writer.WriteBytesFull(ms.ToArray());
            ms.Dispose();
        }
    }

    public class ColorRangesMessage : MessageBase
    {
        public List<ColorRange> ColorRangeList;

        public ColorRangesMessage() { }

        public ColorRangesMessage(List<ColorRange> colorRangeList)
        {
            ColorRangeList = colorRangeList;
        }

        public override void Deserialize(NetworkReader reader)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(reader.ReadBytesAndSize());
            ColorRangeList = (List<ColorRange>)bf.Deserialize(ms);
            ms.Dispose();
        }

        public override void Serialize(NetworkWriter writer)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, ColorRangeList);
            writer.WriteBytesFull(ms.ToArray());
            ms.Dispose();
        }
    }
}
