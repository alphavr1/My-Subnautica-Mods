using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;
using HarmonyLib;
using System.Collections;
using BepInEx;
using BepInEx.Logging;using VehicleFramework.VehicleTypes;
using VehicleFramework;
using UnityEngine.Assertions;
using UWE;
using VehicleFramework.Assets;

namespace Geodesubs
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID,PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency(VehicleFramework.PluginInfo.PLUGIN_GUID, VehicleFramework.PluginInfo.PLUGIN_VERSION)]
    public class MainPatcher : BaseUnityPlugin
    {


        public void Start()
        {
            var harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            harmony.PatchAll();
            UWE.CoroutineHost.StartCoroutine(Register());

        }

        public static IEnumerator Register()
        {
            Geode.GetAssets();
            Submarine geode = Geode.model.EnsureComponent<geode>();
            geode.name = "Geode";
            yield return CoroutineHost.StartCoroutine(VehicleRegistrar.RegisterVehicle(geode));
            yield break;
        }

    }
}
