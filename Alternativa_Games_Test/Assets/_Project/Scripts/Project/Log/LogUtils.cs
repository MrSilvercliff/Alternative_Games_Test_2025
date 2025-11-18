using System;
using UnityEngine;

namespace _Project.Scripts.Project.Log
{
    public static class LogUtils
    {
        #region Info

        public static void Info(object sender, string message)
        {
            Info(sender.GetType(), message);
        }

        public static void Info(Type senderType, string message)
        {
            Info(senderType.Name, message);
        }

        public static void Info(string senderName, string message)
        {
            Debug.Log($"[{senderName}] {message}");
        }

        #endregion Info


        #region Warning

        public static void Warning(object sender, string message)
        {
            Warning(sender.GetType(), message);
        }

        public static void Warning(Type senderType, string message)
        {
            Warning(senderType.Name, message);
        }

        public static void Warning(string senderName, string message)
        {
            Debug.LogWarning($"[{senderName}] {message}");
        }

        #endregion Warning



        #region Error

        public static void Error(object sender, string message)
        {
            Error(sender.GetType(), message);
        }

        public static void Error(Type senderType, string message)
        {
            Error(senderType.Name, message);
        }

        public static void Error(string senderName, string message)
        {
            Debug.LogError($"[{senderName}] {message}");
        }

        #endregion
    }
}
