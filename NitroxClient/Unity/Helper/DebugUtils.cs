﻿using System.Text;
using NitroxModel.Logger;
using UnityEngine;

namespace NitroxClient.Unity.Helper
{
    public static class DebugUtils
    {
        public static void DumpGameObject(this GameObject gameObject, string indent = "")
        {
            Log.Info("{0}+{1}", indent, gameObject.name);

            foreach (Component component in gameObject.GetComponents<Component>())
            {
                DumpComponent(component, indent + "  ");
            }

            foreach (Transform child in gameObject.transform)
            {
                DumpGameObject(child.gameObject, indent + "  ");
            }
        }

        public static void DumpComponent(this Component component, string indent = "")
        {
            Log.Info("{0}{1}", indent, (component == null ? "(null)" : component.GetType().Name + ": " + component.ToString()));
        }

        public static string ByteArrayToHexString(this byte[] bytes)
        {
            StringBuilder hex = new StringBuilder(bytes.Length * 2);

            foreach (byte b in bytes)
            {
                hex.Append("0x");
                hex.Append(b.ToString("X2"));
                hex.Append(" ");
            }

            return hex.ToString();
        }
    }
}
