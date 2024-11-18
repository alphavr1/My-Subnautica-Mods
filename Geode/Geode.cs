using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VehicleFramework;
using VehicleFramework.VehicleParts;
using VehicleFramework.VehicleTypes;
using System.IO;

namespace Geodesubs
{
    public class Geode : Submersible
    {

        public static GameObject model = null;

        public static void GetAssets()
        {
            // load the asset bundle
            string modPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(modPath, "assets/mysub"));
            if (myLoadedAssetBundle == null)
            {
                return;
            }

            System.Object[] arr = myLoadedAssetBundle.LoadAllAssets();
            foreach (System.Object obj in arr)
            {
                if (obj.ToString().Contains("Vehiclename"))
                {
                    model = (GameObject)obj;
                }

            }

        }

        

        public override VehiclePilotSeat PilotSeat
        {
            get
            {
                VehicleFramework.VehicleParts.VehiclePilotSeat vps = new VehicleFramework.VehicleParts.VehiclePilotSeat();
                Transform mainSeat = transform.Find("PilotSeat");
                vps.Seat = mainSeat.gameObject;
                vps.SitLocation = mainSeat.Find("SitLocation").gameObject;
                vps.LeftHandLocation = mainSeat;
                vps.RightHandLocation = mainSeat;
                return vps;
            }
        }

        public override List<VehicleHatchStruct> Hatches
        {
            get
            {
                 var list = new List<VehicleFramework.VehicleParts.VehicleHatchStruct>();

                VehicleFramework.VehicleParts.VehicleHatchStruct vh = new VehicleFramework.VehicleParts.VehicleHatchStruct();
                Transform inthatch = transform.Find("Hatch");
                vh.Hatch = inthatch.gameObject;
                vh.ExitLocation = inthatch.Find("ExitLocation");
                vh.SurfaceExitLocation = inthatch.Find("ExitLocation");
                list.Add(vh);
                return list;
            }
        }

        public override GameObject VehicleModel
        {
            get
            {
                return model;
            }
        }

public override GameObject CollisionModel
        {
            get
            {
                return transform.Find("CollisionModel").gameObject;
            }
        }

        public override GameObject StorageRootObject
        {
            get
            {
                return transform.Find("StorageRoot").gameObject;
            }
        }

        public override GameObject ModulesRootObject
        {
            get
            {
                return transform.Find("ModulesRoot").gameObject;
            }
        }

        public override List<VehicleStorage> InnateStorages
        {
            get
            {
                var list = new List<VehicleFramework.VehicleParts.VehicleStorage>();
                VehicleFramework.VehicleParts.VehicleStorage thisv5 = new VehicleFramework.VehicleParts.VehicleStorage();
                Transform thisStorage = transform.Find("InnateStorages/Storage1");
                thisv5.Container = thisStorage.gameObject;
                thisv5.Height = 12;
                thisv5.Width = 10;
                list.Add(thisv5);

                VehicleFramework.VehicleParts.VehicleStorage thisv6 = new VehicleFramework.VehicleParts.VehicleStorage();
                Transform thisStorage1 = transform.Find("InnateStorages/Storage2");
                thisv6.Container = thisStorage.gameObject;
                thisv6.Height = 12;
                thisv6.Width = 10;
                list.Add(thisv6);

                return list;
            }
        }

        public override List<VehicleStorage> ModularStorages
        {
            get
            {
                var list = new List<VehicleFramework.VehicleParts.VehicleStorage>();
                return list;
            }
        }

        public override List<VehicleUpgrades> Upgrades
        {
            get
            {
                var list = new List<VehicleFramework.VehicleParts.VehicleUpgrades>();

                VehicleFramework.VehicleParts.VehicleUpgrades vu = new VehicleFramework.VehicleParts.VehicleUpgrades();
                vu.Interface = transform.Find("UpgradesInterface").gameObject;
                vu.Flap = vu.Interface;
                list.Add(vu);
                return list;
            }
        }
        public override List<VehicleBattery> Batteries
        {
            get
            {

                var list = new List<VehicleFramework.VehicleParts.VehicleBattery>();

                VehicleFramework.VehicleParts.VehicleBattery vb = new VehicleFramework.VehicleParts.VehicleBattery();
                vb.BatterySlot = transform.Find("Batteries/Battery1").gameObject;
                list.Add(vb);

                VehicleFramework.VehicleParts.VehicleBattery vb1 = new VehicleFramework.VehicleParts.VehicleBattery();
                vb1.BatterySlot = transform.Find("Batteries/Battery2").gameObject;
                list.Add(vb1);

                VehicleFramework.VehicleParts.VehicleBattery vb2 = new VehicleFramework.VehicleParts.VehicleBattery();
                vb2.BatterySlot = transform.Find("Batteries/Battery3").gameObject;
                list.Add(vb2);

                VehicleFramework.VehicleParts.VehicleBattery vb3 = new VehicleFramework.VehicleParts.VehicleBattery();
                vb3.BatterySlot = transform.Find("Batteries/Battery4").gameObject;
                list.Add(vb3);

                return list;
            }
        }

        public override List<VehicleFloodLight> HeadLights
        {
            get
            {
                var list = new List<VehicleFramework.VehicleParts.VehicleFloodLight>();

                VehicleFramework.VehicleParts.VehicleFloodLight left = new VehicleFramework.VehicleParts.VehicleFloodLight
                {
                    Light = transform.Find("lights_parent/headlight1").gameObject,
                    Angle = 42,
                    Color = Color.white,
                    Intensity = 3,
                    Range = 30,

                    

                };
                list.Add(left);

                VehicleFramework.VehicleParts.VehicleFloodLight Right = new VehicleFramework.VehicleParts.VehicleFloodLight
                {
                    Light = transform.Find("lights_parent/headlight2").gameObject,
                    Angle = 42,
                    Color = Color.white,
                    Intensity = 3,
                    Range = 30,

                };
                list.Add(Right);

                return list;
            }
        }

        public override List<GameObject> WaterClipProxies
        {
            get
            {
                var list = new List<GameObject>();
                foreach (Transform child in transform.Find("WaterClipProxie"))
                {
                    list.Add(child.gameObject);

                }
                return list;
            }
        }

        public override List<GameObject> CanopyWindows
        {
            get
            {
                var list = new List<GameObject>();
                list.Add(transform.Find("model/Sphere.002").gameObject);
                return list;
            }
        }

        public override GameObject BoundingBox
        {
            get
            {
                return transform.Find("BoundingBox").gameObject;
            }
        }

        public override Dictionary<TechType, int> Recipe
        {
            get
            {
                Dictionary<TechType,int> recipe = new Dictionary<TechType, int>();
                recipe.Add(TechType.PlasteelIngot, 3);
                recipe.Add(TechType.EnameledGlass, 2);
                recipe.Add(TechType.ComputerChip, 1);
                recipe.Add(TechType.Diamond, 2);
                recipe.Add(TechType.PowerCell, 4);
                return recipe;


            }
        }

        public override Atlas.Sprite PingSprite => null;

        public override string Description => "Geode small size submarine with a low wight and storage makes the geode submarine great for deep sea exploration";

        public override string EncyclopediaEntry => "The Geode Submarine is a light wight vehicle make by altera for a super simple submarime it has 2 lockers and a base depth 500 meters";

        public override int BaseCrushDepth => 500;

        public override int CrushDepthUpgrade1 => 1000;

        public override int CrushDepthUpgrade2 => 1700;

        public override int CrushDepthUpgrade3 => 3400;


        public override int MaxHealth => 1350;

        public override int Mass => 3500;

        public override int NumModules => 6;

        public override bool HasArms => false;
    }
}
