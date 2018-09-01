using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Common.ICommon
{
    public interface IMessage
    {
        /// <summary>
        /// 以json格式返回信息 {"type":"error","Info":"提交失败"}
        /// </summary>
        string ReturnMessage { get; }

        /// <summary>
        /// 获取json info信息
        /// </summary>
        string GetInfo { get; }
        //bool HasMsg { get; }

        /// <summary>
        /// 是否error状态
        /// </summary>
        bool IsError { get; }

        /// <summary>
        /// 是否success状态
        /// </summary>
        bool IsSuccess { get; }

        /// <summary>
        /// 记录或输出错误(error)信息
        /// </summary>
        /// <param name="pErrMsg"></param>
        void Error(string pErrMsg);

        /// <summary>
        /// 记录或输出错误(error)信息
        /// </summary>
        /// <param name="pErrMsg"></param>
        /// <param name="pPath"></param>
        void Error(string pErrMsg, string pPath);

        /// <summary>
        /// 记录或输出错误(error)信息
        /// </summary>
        /// <param name="pErrMsg"></param>
        void Success(string pErrMsg);

        /// <summary>
        /// 记录或输出成功(success)信息
        /// </summary>
        /// <param name="pErrMsg"></param>
        /// <param name="pPath"></param>
        void Success(string pErrMsg, string pPath);

        /// <summary>
        /// 记录或输出提示(message)信息
        /// </summary>
        /// <param name="pMsg"></param>
        void Write(string pMsg);

        /// <summary>
        /// 添加一个信息类型
        /// </summary>
        /// <param name="pName">类型名称</param>
        /// <param name="pMsg"></param>
        void AddMessage(string pName, string pMsg);

        /// <summary>
        /// 记录或输出信息
        /// </summary>
        /// <param name="pMsg"></param>
        /// <param name="pPath"></param>
        /// <param name="pEM"></param>
        void WriteMessage(ref string pMsg, string pPath, MessageGeneral.MessageEnum pEM);

        /// <summary>
        /// 记录或输出信息
        /// </summary>
        /// <param name="pTitie"></param>
        /// <param name="pMsg"></param>
        /// <param name="pPath"></param>
        /// <param name="pType"></param>
        void WriteMessage(string pTitie, ref string pMsg, string pPath, string pType);
    }
}
