﻿using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace Elinor
{
    [Serializable]
    public class Profile : ISerializable
    {
        public Profile()
        {
            charId = 0;
            profileName = "Default";
            marginThreshold = .1;
            minimumThreshold = .02;
            accounting = 5;
            brokerRelations = 5;
            factionStanding = .0;
            corpStanding = .0;
            advancedStepSettings = false;
            buyPercentage = .0;
            buyThreshold = .0;
            sellPercentage = .0;
            sellThreshold = .0;

            isAPI = false;
            corporation = null;
            faction = null;
            charName = null;

            keyId = null;
            vcode = null;

            useBuyCustomBroker = false;
            buyCustomBroker = 0.01;
            useSellCustomBroker = false;
            sellCustomBroker = 0.01;

            sellRange = (int)ranges.HUB;
            buyRange = (int)ranges.HUB;
        }

        public Profile(SerializationInfo info, StreamingContext ctxt)
        {

            foreach (SerializationEntry entry in info)
            {
                switch (entry.Name)
                {
                    case "charId":
                        charId = (long)info.GetValue("charId", typeof(long)); break;
                    case "accounting":
                        accounting = (int)info.GetValue("accounting", typeof(int)); break;
                    case "profilename":
                        profileName = (string)info.GetValue("profilename", typeof(string)); break;
                    case "marginthreshold":
                        marginThreshold = (double)info.GetValue("marginthreshold", typeof(double)); break;
                    case "minimumthreshold":
                        minimumThreshold = (double)info.GetValue("minimumthreshold", typeof(double)); break;
                    case "brokerrelations":
                        brokerRelations = (int)info.GetValue("brokerrelations", typeof(int)); break;
                    case "factionstanding":
                        factionStanding = (double)info.GetValue("factionstanding", typeof(double)); break;
                    case "corpstanding":
                        corpStanding = (double)info.GetValue("corpstanding", typeof(double)); break;
                    case "advancedstepsettings":
                        advancedStepSettings = info.GetBoolean("advancedstepsettings"); break;
                    case "buypercentage":
                        buyPercentage = info.GetDouble("buypercentage"); break;
                    case "buythreshold":
                        buyThreshold = info.GetDouble("buythreshold"); break;
                    case "sellpercentage":
                        sellPercentage = info.GetDouble("sellpercentage"); break;
                    case "sellthreshold":
                        sellThreshold = info.GetDouble("sellthreshold"); break;
                    case "isAPI":
                        isAPI = info.GetBoolean("isAPI"); break;
                    case "corporation":
                        corporation = (String)info.GetValue("corporation", typeof(String)); break;
                    case "faction":
                        faction = (String)info.GetValue("faction", typeof(String)); break;
                    case "charName":
                        charName = (String)info.GetValue("charName", typeof(String)); break;
                    case "keyId":
                        keyId = (String)info.GetValue("keyId", typeof(String)); break;
                    case "vcode":
                        vcode = (String)info.GetValue("vcode", typeof(String)); break;
                    case "useBuyCustomBroker":
                        useBuyCustomBroker = info.GetBoolean("useBuyCustomBroker"); break;
                    case "buyCustomBroker":
                        buyCustomBroker = info.GetDouble("buyCustomBroker"); break;
                    case "useSellCustomBroker":
                        useSellCustomBroker = info.GetBoolean("useSellCustomBroker"); break;
                    case "sellCustomBroker":
                        sellCustomBroker = info.GetDouble("sellCustomBroker"); break;
                    case "buyRange":
                        buyRange = info.GetInt32("buyRange"); break;
                    case "sellRange":
                        sellRange = info.GetInt32("sellRange"); break;
                }
            }
        }

        internal long charId { get; set; }
        internal string profileName { get; set; }
        internal double marginThreshold { get; set; }
        internal double minimumThreshold { get; set; }
        internal int accounting { get; set; }
        internal int brokerRelations { get; set; }
        internal double factionStanding { get; set; }
        internal double corpStanding { get; set; }
        internal bool advancedStepSettings { get; set; }
        internal double buyPercentage { get; set; }
        internal double buyThreshold { get; set; }
        internal double sellPercentage { get; set; }
        internal double sellThreshold { get; set; }

        internal bool isAPI { get; set; }
        internal String corporation { get; set; }
        internal String faction { get; set; }
        internal String charName { get; set; }

        internal String keyId { get; set; }
        internal String vcode { get; set; }

        internal bool useBuyCustomBroker { get; set; }
        internal double buyCustomBroker { get; set; }
        internal bool useSellCustomBroker { get; set; }
        internal double sellCustomBroker { get; set; }

        internal int buyRange { get; set; }
        internal int sellRange { get; set; }

        public enum ranges
        {
            [Description("Hubs (Station)")]
            HUB,
            [Description("System")]
            SYSTEM,
            [Description("1 jump")]
            ONEJUMP,
            [Description("2 jumps")]
            TWOJUMP,
            [Description("Region")]
            REGION,
        }

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("charId", charId);
            info.AddValue("profilename", profileName);
            info.AddValue("marginthreshold", marginThreshold);
            info.AddValue("minimumthreshold", minimumThreshold);
            info.AddValue("accounting", accounting);
            info.AddValue("brokerrelations", brokerRelations);
            info.AddValue("factionstanding", factionStanding);
            info.AddValue("corpstanding", corpStanding);
            info.AddValue("advancedstepsettings", advancedStepSettings);
            info.AddValue("buypercentage", buyPercentage);
            info.AddValue("buythreshold", buyThreshold);
            info.AddValue("sellpercentage", sellPercentage);
            info.AddValue("sellthreshold", sellThreshold);

            info.AddValue("isAPI", isAPI);
            info.AddValue("corporation", corporation);
            info.AddValue("faction", faction);
            info.AddValue("charName", charName);

            info.AddValue("keyId", keyId);
            info.AddValue("vcode", vcode);

            info.AddValue("useBuyCustomBroker", useBuyCustomBroker);
            info.AddValue("buyCustomBroker", buyCustomBroker);
            info.AddValue("useSellCustomBroker", useSellCustomBroker);
            info.AddValue("sellCustomBroker", sellCustomBroker);

            info.AddValue("buyRange", buyRange);
            info.AddValue("sellRange", sellRange);
    }

        #endregion

        public override string ToString()
        {
            return profileName;
        }

        public static Profile ReadSettings(string profileName)
        {
            if (File.Exists(string.Format("profiles\\{0}.dat", profileName)))
            {
                try
                {
                    return Serializer.DeSerializeObject(string.Format("profiles\\{0}.dat", profileName));
                }
                catch (Exception exception)
                {
                    return null;
                }
            }
            return null;
        }

        public static void SaveSettings(Profile profile)
        {
            if (profile.profileName == "Default") return;

            Directory.CreateDirectory("profiles");

            Serializer.SerializeObject(
                string.Format(
                    "profiles\\{0}.dat", 
                    profile.profileName
                ), 
                profile
            );
        }

        public bool isAPIProfile()
        {
            return isAPI;
        }
    }
}