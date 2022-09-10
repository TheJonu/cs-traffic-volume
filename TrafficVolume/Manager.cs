using System.Collections.Generic;
using ColossalFramework.UI;
using HarmonyLib;
using ICities;
using TrafficVolume.TempGUI;

#pragma warning disable 0649

namespace TrafficVolume
{
    public static class Manager
    {
        private const string HarmonyModID = "trafficvolume";

        public const string VersionId = "10 Sep";
        
        public const int VehicleMaxIndex = 256 * 64;
        public const int CitizenMaxIndex = 256 * 256;

        private static Log _log;
        
        public static Log Log => _log ?? (_log = new Log(HarmonyModID));

        private static GlobalVolumeGUI _globalVolumeGUI;
        private static LocalVolumeGUI _localVolumeGUI;

        private static UnityHook _unityHook;

        public static void OnModEnabled()
        {
            AttachHarmony();
        }

        public static void OnLevelLoaded(LoadMode mode)
        {
            UnityHelper.InstantiateSingle(ref _globalVolumeGUI);
            UnityHelper.InstantiateSingle(ref _localVolumeGUI);

            UnityHelper.InstantiateSingle(ref _unityHook);
            _unityHook.UnityUpdate += OnUnityUpdate;

            UIManager.PrepareColors();
            UIManager.CreateTrafficChart();
        }

        private static void OnUnityUpdate()
        {
            
        }
        
        public static void OnSimulationUpdate(float realTimeDelta, float simulationTimeDelta)
        {
            
        }
        
        private static void AttachHarmony()
        {
            // Harmony.DEBUG = true;

            var harmony = new Harmony(HarmonyModID);
            harmony.PatchAll();
        }

        // private static void CreateOverlayCheckbox()
        // {
        //     var parent = TrafficPanel;
        //
        //     parent.size = parent.size + new Vector2(0, 20);
        //     
        //     var checkbox = UIUtils.CreateCheckBox(parent);
        //
        //     checkbox.isChecked = true;
        //
        //     checkbox.eventCheckChanged += OnCheckChanged;
        // }

        // private static void OnCheckChanged(UIComponent ui, bool check)
        // {
        //     Log.WriteInfo($"Check: {check}");
        // }
    }
}