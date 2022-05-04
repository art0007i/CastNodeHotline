using HarmonyLib;
using NeosModLoader;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using FrooxEngine;
using FrooxEngine.LogiX;

namespace CastNodeHotline
{
    public class CastNodeHotline : NeosMod
    {
        public override string Name => "CastNodeHotline";
        public override string Author => "art0007i";
        public override string Version => "1.0.1";
        public override string Link => "https://github.com/art0007i/CastNodeHotline/";
        public override void OnEngineInit()
        {
            Harmony harmony = new Harmony("me.art0007i.CastNodeHotline");

            var method = typeof(LogixNode).GetMethod("Cleanup", BindingFlags.NonPublic | BindingFlags.Instance);
            var patchMethod = typeof(CastNodeHotlinePatch).GetMethod("Prefix");
            harmony.Patch(method, new HarmonyMethod(patchMethod));
        }

        class CastNodeHotlinePatch
        {
            public static bool Prefix()
            {
                return false;
            }
        }
    }
}