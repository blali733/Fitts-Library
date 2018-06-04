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
        public static short TargetDatas = MsgType.Highest + 2;
        public static short TargetInfos = MsgType.Highest + 3;
        public static short UserList = MsgType.Highest + 4;
        public static short DataRequest = MsgType.Highest + 5;
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
        public List<List<TargetData>> TargetDatas;

        public RawTargetDatasMessage(List<List<TargetData>> targetDatas)
        {
            TargetDatas = targetDatas;
        }

        public RawTargetDatasMessage() { }

        public override void Deserialize(NetworkReader reader)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(reader.ReadBytesAndSize());
            TargetDatas = (List<List<TargetData>>)bf.Deserialize(ms);
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
        public List<List<TargetInfo>> TargetInfos;

        public TargetInfosMessage(List<List<TargetInfo>> targetInfos)
        {
            TargetInfos = targetInfos;
        }

        public TargetInfosMessage() { }

        public override void Deserialize(NetworkReader reader)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(reader.ReadBytesAndSize());
            TargetInfos = (List<List<TargetInfo>>)bf.Deserialize(ms);
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

    public class Request : MessageBase
    {
        public RequestType Type;

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
}
