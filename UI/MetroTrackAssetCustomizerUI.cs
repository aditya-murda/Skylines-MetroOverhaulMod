﻿using System;
using ColossalFramework.Threading;
using ColossalFramework.UI;
using MetroOverhaul.Extensions;
using UnityEngine;
using MetroOverhaul.NEXT.Extensions;
using System.Linq;
using System.Collections.Generic;
using ColossalFramework;

namespace MetroOverhaul.UI
{
    public class MetroTrackAssetCustomizerUI : UIPanel
    {
        public int trackStyle = 0;
        public int trackSize = 1;
        public int trackDirection = 1;
        public int isStation = 1;
        public int stationType = 0;
        public bool fence = false;
        public bool extraElevated = false;
        private BulldozeTool m_bulldozeTool;
        private NetTool m_netTool;
        private UIButton m_upgradeButtonTemplate;
        private NetInfo m_currentNetInfo;
        private bool m_activated = false;
        public static MetroTrackAssetCustomizerUI instance;

        UISprite m_useFenceCheckBoxClicker = null;
        UISprite m_useExtraElevatedPillarClicker = null;
        UICheckBox m_useFenceCheckBox = null;
        UICheckBox m_useExtraElevatedPillarsCheckBox = null;

        private NetInfo concretePrefab;
        private NetInfo concretePrefabNoBar;

        private NetInfo concreteTwoLaneOneWayPrefab;
        private NetInfo concreteTwoLaneOneWayPrefabNoBar;

        private NetInfo concreteLargePrefab;
        private NetInfo concreteLargePrefabNoBar;

        private NetInfo concreteSmallPrefab;
        private NetInfo concreteSmallPrefabNoBar;

        private NetInfo concreteSmallTwoWayPrefab;
        private NetInfo concreteSmallTwoWayPrefabNoBar;

        private NetInfo concreteSidePlatformStationPrefab;
        private NetInfo concreteIslandPlatformStationPrefab;
        private NetInfo concreteSinglePlatformStationPrefab;

        private NetInfo steelPrefab;
        private NetInfo steelPrefabNoBar;

        private NetInfo steelTwoLaneOneWayPrefab;
        private NetInfo steelTwoLaneOneWayPrefabNoBar;

        private NetInfo steelLargePrefab;
        private NetInfo steelLargePrefabNoBar;

        private NetInfo steelSmallPrefab;
        private NetInfo steelSmallPrefabNoBar;

        private NetInfo steelSmallTwoWayPrefab;
        private NetInfo steelSmallTwoWayPrefabNoBar;

        private NetInfo steelSidePlatformStationPrefab;
        private NetInfo steelIslandPlatformStationPrefab;
        private NetInfo steelSinglePlatformStationPrefab;


        private UIButton btnModernStyle;
        private UIButton btnClassicStyle;
        private UIButton btnStation;
        private UIButton btnTrack;
        private UIButton btnSidePlatform;
        private UIButton btnIslandPlatform;
        private UIButton btnSinglePlatform;
        private UIButton btnSingleTrack;
        private UIButton btnDoubleTrack;
        private UIButton btnOneWay;
        private UIButton btnTwoWay;

        public override void Awake()
        {
            concretePrefab = PrefabCollection<NetInfo>.FindLoaded("Metro Track Ground");
            concretePrefabNoBar = PrefabCollection<NetInfo>.FindLoaded("Metro Track Ground NoBar");

            concreteTwoLaneOneWayPrefab = PrefabCollection<NetInfo>.FindLoaded("Metro Track Ground Two-Lane One-Way");
            concreteTwoLaneOneWayPrefabNoBar = PrefabCollection<NetInfo>.FindLoaded("Metro Track Ground Two-Lane One-Way NoBar");

            concreteLargePrefab = PrefabCollection<NetInfo>.FindLoaded("Metro Track Ground Large");
            concreteLargePrefabNoBar = PrefabCollection<NetInfo>.FindLoaded("Metro Track Ground Large NoBar");

            concreteSmallPrefab = PrefabCollection<NetInfo>.FindLoaded("Metro Track Ground Small");
            concreteSmallPrefabNoBar = PrefabCollection<NetInfo>.FindLoaded("Metro Track Ground Small NoBar");

            concreteSmallTwoWayPrefab = PrefabCollection<NetInfo>.FindLoaded("Metro Track Ground Small Two-Way");
            concreteSmallTwoWayPrefabNoBar = PrefabCollection<NetInfo>.FindLoaded("Metro Track Ground Small Two-Way NoBar");

            concreteSidePlatformStationPrefab = PrefabCollection<NetInfo>.FindLoaded("Metro Station Track Ground");
            concreteIslandPlatformStationPrefab = PrefabCollection<NetInfo>.FindLoaded("Metro Station Track Ground Island");
            concreteSinglePlatformStationPrefab = PrefabCollection<NetInfo>.FindLoaded("Metro Station Track Ground Small");

            steelPrefab = PrefabCollection<NetInfo>.FindLoaded("Steel Metro Track Ground");
            steelPrefabNoBar = PrefabCollection<NetInfo>.FindLoaded("Steel Metro Track Ground NoBar");

            steelTwoLaneOneWayPrefab = PrefabCollection<NetInfo>.FindLoaded("Steel Metro Track Ground Two-Lane One-Way");
            steelTwoLaneOneWayPrefabNoBar = PrefabCollection<NetInfo>.FindLoaded("Steel Metro Track Ground Two-Lane One-Way NoBar");

            steelSmallPrefab = PrefabCollection<NetInfo>.FindLoaded("Steel Metro Track Ground Small");
            steelSmallPrefabNoBar = PrefabCollection<NetInfo>.FindLoaded("Steel Metro Track Ground Small NoBar");

            steelSmallTwoWayPrefab = PrefabCollection<NetInfo>.FindLoaded("Steel Metro Track Ground Small Two-Way");
            steelSmallTwoWayPrefabNoBar = PrefabCollection<NetInfo>.FindLoaded("Steel Metro Track Ground Small Two-Way NoBar");

            steelLargePrefab = PrefabCollection<NetInfo>.FindLoaded("Steel Metro Track Ground Large");
            steelLargePrefabNoBar = PrefabCollection<NetInfo>.FindLoaded("Steel Metro Track Ground Large NoBar");

            steelSidePlatformStationPrefab = PrefabCollection<NetInfo>.FindLoaded("Steel Metro Station Track Ground");
            steelIslandPlatformStationPrefab = PrefabCollection<NetInfo>.FindLoaded("Steel Metro Station Track Ground Island");
            steelSinglePlatformStationPrefab = PrefabCollection<NetInfo>.FindLoaded("Steel Metro Station Track Ground Small");
        }

        public override void Update()
        {
            if (m_netTool == null)
            {
                return;
            }
            try
            {
                var toolInfo = m_netTool.enabled ? m_netTool.m_prefab : null;
                if (toolInfo == m_currentNetInfo)
                {
                    return;
                }
                NetInfo finalInfo = null;
                if (toolInfo != null)
                {
                    //RestoreStationTrackStyle(toolInfo);
                    if (toolInfo.IsMetroTrack() || toolInfo.IsMetroStationTrack())
                    {
                        finalInfo = toolInfo;
                    }
                }
                if (finalInfo == m_currentNetInfo)
                {
                    return;
                }
                if (finalInfo != null)
                {
                    Activate(finalInfo);
                }
                else
                {
                    Deactivate();
                }
            }
            catch (Exception e)
            {
                UnityEngine.Debug.LogException(e);
                Deactivate();
            }

        }
        public override void Start()
        {
            m_netTool = FindObjectOfType<NetTool>();
            if (m_netTool == null)
            {
#if DEBUG
                Next.Debug.Log("NetTool Not Found");
#endif
                enabled = false;
                return;
            }

            m_bulldozeTool = FindObjectOfType<BulldozeTool>();
            if (m_bulldozeTool == null)
            {
#if DEBUG
                Next.Debug.Log("BulldozeTool Not Found");
#endif
                enabled = false;
                return;
            }
            m_netTool = FindObjectOfType<NetTool>();
            if (m_netTool == null)
            {
#if DEBUG
                Next.Debug.Log("NetTool Not Found");
#endif
                enabled = false;
                return;
            }

            try
            {
                m_upgradeButtonTemplate = GameObject.Find("RoadsSmallPanel").GetComponent<GeneratedScrollPanel>().m_OptionsBar.Find<UIButton>("Upgrade");
            }
            catch
            {
#if DEBUG
                Next.Debug.Log("Upgrade button template not found");
#endif
            }

            CreateUI();
            trackStyle = 0;
            trackSize = 1;
            trackDirection = 1;
            isStation = 1;
            stationType = 0;
            fence = false;
            SetNetToolPrefab();
        }

        private void CreateUI()
        {
#if DEBUG
            Next.Debug.Log("MOM TRACK GUI Created");
#endif

            backgroundSprite = "GenericPanel";
            color = new Color32(73, 68, 84, 170);
            width = 300;
            height = 300;
            opacity = 90;
            position = Vector2.zero;
            isVisible = false;
            isInteractive = true;
            padding = new RectOffset() { bottom = 8, left = 8, right = 8, top = 8 };

            UIPanel dragHandlePanel = AddUIComponent<UIPanel>();
            dragHandlePanel.atlas = atlas;
            dragHandlePanel.backgroundSprite = "GenericPanel";
            dragHandlePanel.width = width;
            dragHandlePanel.height = 20;
            dragHandlePanel.opacity = 100;
            dragHandlePanel.color = new Color32(21, 140, 34, 255);
            dragHandlePanel.relativePosition = Vector3.zero;

            UIDragHandle dragHandle = dragHandlePanel.AddUIComponent<UIDragHandle>();
            dragHandle.width = width;
            dragHandle.height = dragHandle.parent.height;
            dragHandle.relativePosition = Vector3.zero;
            dragHandle.target = this;

            UILabel titleLabel = dragHandlePanel.AddUIComponent<UILabel>();
            titleLabel.relativePosition = new Vector3() { x = 5, y = 5, z = 0 };
            titleLabel.textAlignment = UIHorizontalAlignment.Center;
            titleLabel.text = "Track/Station Options";
            titleLabel.isInteractive = false;


            btnModernStyle = CreateButton("Modern", new Vector3(8, 50), (c, v) =>
            {
                trackStyle = 0;
                SetNetToolPrefab();
            });

            btnClassicStyle = CreateButton("Classic", new Vector3(8 + (0.5f * width) - 16, 50), (c, v) =>
              {
                  trackStyle = 1;
                  SetNetToolPrefab();
              });
            btnStation = CreateButton("Stn Trk", new Vector3(8, 100), (c, v) =>
            {
                isStation = 1;
                SetNetToolPrefab();
            });
            btnTrack = CreateButton("Track", new Vector3(8 + (0.5f * width) - 16, 100), (c, v) =>
            {
                isStation = 0;
                SetNetToolPrefab();
            });
            btnSidePlatform = CreateButton("Side", new Vector3(8, 150), (c, v) =>
             {
                 stationType = 0;
                 SetNetToolPrefab();
             });
            btnIslandPlatform = CreateButton("Island", new Vector3(8 + (0.33333f * width) - 16, 150), (c, v) =>
            {
                stationType = 1;
                SetNetToolPrefab();
            });
            btnSinglePlatform = CreateButton("Single", new Vector3(8 + (0.66666f * width) - 32, 150), (c, v) =>
            {
                stationType = 2;
                SetNetToolPrefab();
            });
            btnSingleTrack = CreateButton("Single", new Vector3(8, 150), (c, v) =>
              {
                  trackSize = 0;
                  SetNetToolPrefab();
              });

            btnDoubleTrack = CreateButton("Double", new Vector3(8 + (0.5f * width) - 16, 150), (c, v) =>
              {
                  trackSize = 1;
                  SetNetToolPrefab();
              });

            btnOneWay = CreateButton("OneWay", new Vector3(8, 200), (c, v) =>
             {
                 trackDirection = 0;
                 SetNetToolPrefab();
             });

            btnTwoWay = CreateButton("TwoWay", new Vector3(8 + (0.5f * width) - 16, 200), (c, v) =>
              {
                  trackDirection = 1;
                  SetNetToolPrefab();
              });



            m_useFenceCheckBox = AddUIComponent<UICheckBox>();
            m_useFenceCheckBox.text = "Island Platform";
            m_useFenceCheckBox.size = new Vector2(width - 16, 16);
            m_useFenceCheckBox.relativePosition = new Vector2(8, 250);
            m_useFenceCheckBox.isInteractive = true;
            m_useFenceCheckBox.eventCheckChanged += (c, v) =>
            {
                fence = m_useFenceCheckBox.isChecked;
                if (fence)
                {
                    m_useFenceCheckBoxClicker.spriteName = "check-checked";
                }
                else
                {
                    m_useFenceCheckBoxClicker.spriteName = "check-unchecked";
                }
                SetNetToolPrefab();
            };

            m_useFenceCheckBoxClicker = m_useFenceCheckBox.AddUIComponent<UISprite>();
            m_useFenceCheckBoxClicker.atlas = atlas;
            m_useFenceCheckBoxClicker.spriteName = "check-unchecked";
            m_useFenceCheckBoxClicker.relativePosition = new Vector2(0, 0);
            m_useFenceCheckBoxClicker.size = new Vector2(16, 16);
            m_useFenceCheckBoxClicker.isInteractive = true;

            UILabel useFenceLabel = m_useFenceCheckBox.AddUIComponent<UILabel>();
            useFenceLabel.relativePosition = new Vector2(20, 0);
            useFenceLabel.text = "Alt/Barrier";
            useFenceLabel.height = 16;
            useFenceLabel.isInteractive = true;

            m_useExtraElevatedPillarsCheckBox = AddUIComponent<UICheckBox>();
            m_useExtraElevatedPillarsCheckBox.text = "Island Platform";
            m_useExtraElevatedPillarsCheckBox.size = new Vector2(width - 16, 16);
            m_useExtraElevatedPillarsCheckBox.relativePosition = new Vector2(8, 280);
            m_useExtraElevatedPillarsCheckBox.isInteractive = true;
            m_useExtraElevatedPillarsCheckBox.eventCheckChanged += (c, v) =>
            {
                extraElevated = m_useExtraElevatedPillarsCheckBox.isChecked;
                if (extraElevated)
                {
                    m_useExtraElevatedPillarClicker.spriteName = "check-checked";
                }
                else
                {
                    m_useExtraElevatedPillarClicker.spriteName = "check-unchecked";
                }
                SetNetToolPrefab();
            };

            m_useExtraElevatedPillarClicker = m_useExtraElevatedPillarsCheckBox.AddUIComponent<UISprite>();
            m_useExtraElevatedPillarClicker.atlas = atlas;
            m_useExtraElevatedPillarClicker.spriteName = "check-unchecked";
            m_useExtraElevatedPillarClicker.relativePosition = new Vector2(0, 0);
            m_useExtraElevatedPillarClicker.size = new Vector2(16, 16);
            m_useExtraElevatedPillarClicker.isInteractive = true;

            UILabel useExtraElevatedPillarLabel = m_useExtraElevatedPillarsCheckBox.AddUIComponent<UILabel>();
            useExtraElevatedPillarLabel.relativePosition = new Vector2(20, 0);
            useExtraElevatedPillarLabel.text = "Extra Elevated Pillars";
            useExtraElevatedPillarLabel.height = 16;
            useExtraElevatedPillarLabel.isInteractive = true;
        }
        private UITextureAtlas m_InGameAtlas = null;
        private UITextureAtlas InGameAtlas()
        {
            if (m_InGameAtlas == null)
            {
                var atlases = Resources.FindObjectsOfTypeAll<UITextureAtlas>();
                foreach (UITextureAtlas atlas in atlases)
                {
                    if (atlas.name == "Ingame")
                    {
                        m_InGameAtlas = atlas;
                    }
                }
            }
            return m_InGameAtlas;
        }
        private UIButton CreateButton(string text, Vector3 pos, MouseEventHandler eventClick)
        {
            var button = this.AddUIComponent<UIButton>();
            button.atlas = InGameAtlas();
            button.width = 80;
            button.height = 30;
            button.normalBgSprite = "ButtonMenu";
            button.color = new Color32(150, 150, 150, 255);
            button.disabledBgSprite = "ButtonMenuDisabled";
            button.hoveredBgSprite = "ButtonMenuHovered";
            button.hoveredColor = new Color32(163, 255, 16, 255);
            button.focusedBgSprite = "ButtonMenu";
            button.focusedColor = new Color32(163, 255, 16, 255);
            button.pressedBgSprite = "ButtonMenuPressed";
            button.pressedColor = new Color32(163, 255, 16, 255);
            button.textColor = new Color32(255, 255, 255, 255);
            button.normalBgSprite = "ButtonMenu";
            button.focusedBgSprite = "ButtonMenuFocused";
            button.playAudioEvents = true;
            button.opacity = 75;
            button.dropShadowColor = new Color32(0, 0, 0, 255);
            button.dropShadowOffset = new Vector2(-1, -1);
            button.text = text;
            button.relativePosition = pos;
            button.eventClick += eventClick;

            return button;
        }
        private void ToggleButtonPairs(UIButton active, params UIButton[] inactives)
        {
            active.color = new Color32(163, 255, 16, 255);
            active.normalBgSprite = "ButtonMenuFocused";
            active.useDropShadow = true;
            active.opacity = 95;
            foreach (UIButton inactive in inactives)
            {
                inactive.color = new Color32(150, 150, 150, 255);
                inactive.normalBgSprite = "ButtonMenu";
                inactive.useDropShadow = false;
                inactive.opacity = 75;
            }
        }
        private void SetNetToolPrefab()
        {
            if (trackStyle == 0)
                ToggleButtonPairs(btnModernStyle, btnClassicStyle);
            else if (trackStyle == 1)
                ToggleButtonPairs(btnClassicStyle, btnModernStyle);

            btnSingleTrack.isVisible = isStation == 0;
            btnDoubleTrack.isVisible = isStation == 0;
            btnOneWay.isVisible = isStation == 0;
            btnTwoWay.isVisible = isStation == 0;
            m_useFenceCheckBox.isVisible = isStation == 0;
            m_useExtraElevatedPillarsCheckBox.isVisible = isStation == 0;

            btnSidePlatform.isVisible = isStation == 1;
            btnIslandPlatform.isVisible = isStation == 1;
            btnSinglePlatform.isVisible = isStation == 1;

            if (isStation == 0)
            {
                ToggleButtonPairs(btnTrack, btnStation);
                if (trackSize == 0)
                    ToggleButtonPairs(btnSingleTrack, btnDoubleTrack);
                else if (trackSize == 1)
                    ToggleButtonPairs(btnDoubleTrack, btnSingleTrack);
                if (trackDirection == 0)
                    ToggleButtonPairs(btnOneWay, btnTwoWay);
                else if (trackDirection == 1)
                    ToggleButtonPairs(btnTwoWay, btnOneWay);
            }
            else if (isStation == 1)
            {
                ToggleButtonPairs(btnStation, btnTrack);
                if (stationType == 0)
                    ToggleButtonPairs(btnSidePlatform, btnIslandPlatform, btnSinglePlatform);
                else if (stationType == 1)
                    ToggleButtonPairs(btnIslandPlatform, btnSidePlatform, btnSinglePlatform);
                else if (stationType == 2)
                    ToggleButtonPairs(btnSinglePlatform, btnIslandPlatform, btnSidePlatform);
            }
            NetInfo prefab = null;
            switch (trackStyle)
            {
                case 0:
                    {
                        switch (isStation)
                        {
                            case 0:
                                {
                                    switch (trackSize)
                                    {
                                        case 0:
                                            {
                                                if (trackDirection == 0)
                                                    prefab = fence ? concreteSmallPrefab : concreteSmallPrefabNoBar;
                                                else
                                                    prefab = fence ? concreteSmallTwoWayPrefab : concreteSmallTwoWayPrefabNoBar;
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (trackDirection == 0)
                                                    prefab = fence ? concreteTwoLaneOneWayPrefab : concreteTwoLaneOneWayPrefabNoBar;
                                                else
                                                    prefab = fence ? concretePrefab : concretePrefabNoBar;
                                            }
                                            break;
                                        case 2:
                                            {
                                                if (trackDirection == 0) { }
                                                else
                                                    prefab = fence ? concreteLargePrefab : concreteLargePrefabNoBar;
                                            }
                                            break;
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    switch (stationType)
                                    {
                                        case 0:
                                            prefab = concreteSidePlatformStationPrefab;
                                            break;
                                        case 1:
                                            prefab = concreteIslandPlatformStationPrefab;
                                            break;
                                        case 2:
                                            prefab = concreteSinglePlatformStationPrefab;
                                            break;
                                    }
                                }
                                break;
                        }
                    }
                    break;
                case 1:
                    {
                        switch (isStation)
                        {
                            case 0:
                                {
                                    switch (trackSize)
                                    {
                                        case 0:
                                            {
                                                if (trackDirection == 0)
                                                {
                                                    prefab = fence ? steelSmallPrefab : steelSmallPrefabNoBar;
                                                }
                                                else
                                                {
                                                    prefab = fence ? steelSmallTwoWayPrefab : steelSmallTwoWayPrefabNoBar;
                                                }
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (trackDirection == 0)
                                                {
                                                    prefab = fence ? steelTwoLaneOneWayPrefab : steelTwoLaneOneWayPrefabNoBar;
                                                }
                                                else
                                                {
                                                    prefab = fence ? steelPrefab : steelPrefabNoBar;
                                                }
                                            }
                                            break;
                                        case 2:
                                            {
                                                if (trackDirection == 0)
                                                {
                                                    //prefab = fence ? steelTwoLaneOneWayPrefab : steelTwoLaneOneWayPrefabNoBar;
                                                }
                                                else
                                                {
                                                    prefab = fence ? steelLargePrefab : steelLargePrefabNoBar;
                                                }
                                            }
                                            break;
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    switch (stationType)
                                    {
                                        case 0:
                                            prefab = steelSidePlatformStationPrefab;
                                            break;
                                        case 1:
                                            prefab = steelIslandPlatformStationPrefab;
                                            break;
                                        case 2:
                                            prefab = steelSinglePlatformStationPrefab;
                                            break;
                                    }
                                }
                                break;
                        }
                        break;
                    }
            }
            if (prefab != null)
            {
                m_netTool.m_prefab = prefab;
                var elevation = m_netTool.GetElevation();
                var lanes = m_netTool.m_prefab.m_lanes.ToList();
                Next.Debug.Log($"MOM EE lane count: {lanes.Count()}");
                var lane = lanes.FirstOrDefault(l => l.m_laneType == NetInfo.LaneType.None);
                NetLaneProps.Prop prop = null;
                if (lane != null)
                {
                    var propList = lane.m_laneProps.m_props?.ToList();
                    if (propList != null)
                    {
                        Next.Debug.Log($"MOM EE lane found with {propList.Count()} props");
                        prop = propList.FirstOrDefault(p => p.m_prop.name.ToLower().Contains("l pillar ("));
                        if (prop != null)
                        {
                            Next.Debug.Log($"MOM EE Examining aLane");
                            var name = prop.m_prop.name;
                            if (extraElevated)
                            {
                                prop.m_probability = 100;
                                Next.Debug.Log("MOM EE Enabled");
                            }
                            else
                            {
                                prop.m_probability = 0;
                                Next.Debug.Log("MOM EE Disabled");
                            }
                            var props = lane.m_laneProps.m_props?.ToList();
                            if (props != null)
                            {
                                var replacementPair = new KeyValuePair<string, PropInfo>(name, prop.m_prop);

                                if (props.Any(p => p.m_prop.name.ToLower().Contains(replacementPair.Key.ToLower())))
                                {
                                    var tempProp = new NetLaneProps.Prop();
                                    var propsToReplace = props.Where(p => p.m_prop.name.ToLower().Contains(replacementPair.Key.ToLower())).ToList();
                                    for (var i = 0; i < propsToReplace.Count; i++)
                                    {
                                        tempProp = propsToReplace[i].ShallowClone();
                                        props.Remove(propsToReplace[i]);
                                        tempProp.m_prop = replacementPair.Value;
                                        props.Add(tempProp);
                                    }
                                }
                                lane.m_laneProps.m_props = props.ToArray();
                            }
                        }
                    }
                }
                m_netTool.m_prefab.m_lanes = lanes.ToArray();
            }
        }

        private void Activate(NetInfo nInfo)
        {
            m_activated = true;
            m_currentNetInfo = nInfo;
            isVisible = true;
            SetNetToolPrefab();
        }
        private void Deactivate()
        {
            if (!m_activated)
            {
                return;
            }
            m_currentNetInfo = null;
            isVisible = false;
            m_activated = false;
        }
    }
}
