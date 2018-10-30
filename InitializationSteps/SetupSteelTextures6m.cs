﻿using MetroOverhaul.NEXT;
using MetroOverhaul.NEXT.Extensions;
using MetroOverhaul.NEXT.Texturing;

namespace MetroOverhaul.InitializationSteps
{
    public static partial class SetupSteelTexture
    {
        public static void Setup6mSteelTexture(NetInfo info, NetInfoVersion version)
        {
            switch (version)
            {
                case NetInfoVersion.Ground:
                    {
                        foreach (var segment in info.m_segments)
                        {
                            if (segment.m_mesh.name.Contains("Fence"))
                            {
                                segment.SetTextures(
                                    new TextureSet
                                        (@"Textures\Ground_Fence_Steel__MainTex.png",
                                            @"Textures\Ground_Fence_Steel__AlphaMap.png",
                                            @"Textures\Ground_Fence_Steel__XYSMap.png"),
                                    new LODTextureSet
                                        (@"Textures\Ground_Fence_Steel__MainTex_LOD.png",
                                            @"Textures\Ground_Fence_Steel__AlphaMap_LOD.png",
                                            @"Textures\Ground_Fence_Steel__XYSMap_LOD.png"));
                            }
                            else if (segment.m_mesh.name.Contains("Pavement"))
                            {
                                segment.SetTextures(
                                    new TextureSet
                                        (@"Textures\Ground_Segment_Pavement_Steel_Small__MainTex.png",
                                            @"Textures\Ground_Segment_Pavement_Small__AlphaMap.png",
                                            @"Textures\Ground_Segment_Pavement_Steel__XYSMap.png"),
                                    new LODTextureSet
                                        (@"Textures\Ground_Segment_Pavement_Steel__MainTex_LOD.png",
                                            @"Textures\Ground_Segment_Pavement_Steel__AlphaMap_LOD.png",
                                            @"Textures\Ground_Segment_Pavement_Steel__XYSMap_LOD.png"));
                            }
                            else if (segment.m_mesh.name.Contains("ThirdRail"))
                            {
                                segment.SetTextures(
                                    new TextureSet
                                        (@"Textures\ThirdRail__MainTex.png",
                                            @"Textures\ThirdRail__AlphaMap.png",
                                            @"Textures\ThirdRail__XYSMap.png"),
                                    new LODTextureSet
                                        (@"Textures\ThirdRail__MainTex_LOD.png",
                                            @"Textures\ThirdRail__AlphaMap_LOD.png",
                                            @"Textures\ThirdRail__XYSMap_LOD.png"));
                            }
                            else
                            {
                                segment.SetTextures(
                                    new TextureSet
                                        (@"Textures\Ground_Segment_Rail__MainTex.png",
                                            @"Textures\Ground_Segment_Rail__AlphaMap.png",
                                            @"Textures\Ground_Segment_Rail__XYSMap.png"));
                            }
                        }
                        foreach (var node in info.m_nodes)
                        { 
                            if (node.m_mesh.name.Contains("LevelCrossing_Pavement"))
                            {
                                node.SetTextures(
                                    new TextureSet
                                        (@"Textures\Ground_Level_Crossing__MainTex.png",
                                            @"Textures\Ground_Level_Crossing__AlphaMap.png"),
                                    new LODTextureSet
                                        (@"Textures\Ground_Level_Crossing__MainTex_LOD.png",
                                            @"Textures\Ground_Level_Crossing__AlphaMap_LOD.png",
                                            @"Textures\Ground_Segment_Pavement__XYSMap_LOD.png"));
                            }
                            else if (node.m_mesh.name.Contains("LevelCrossing_Rail"))
                            {
                                node.SetTextures(
                                    new TextureSet
                                        (@"Textures\Ground_Level_Crossing_Rail__MainTex.png",
                                            @"Textures\Ground_Segment_Rail__AlphaMap.png",
                                            @"Textures\Ground_Level_Crossing_Rail__XYSMap.png"),
                                    new LODTextureSet
                                           (@"Textures\Ground_Level_Crossing_Rail__MainTex_LOD.png",
                                            @"Textures\Ground_Level_Crossing_Rail__AlphaMap_LOD.png",
                                            @"Textures\Ground_Level_Crossing_Rail__XYSMap_LOD.png"));
                            }

                            else if (node.m_mesh.name.Contains("Fence"))
                            {
                                node.SetTextures(
                                    new TextureSet
                                        (@"Textures\Ground_Fence_Steel__MainTex.png",
                                            @"Textures\Ground_Fence_Steel__AlphaMap.png",
                                            @"Textures\Ground_Fence_Steel__XYSMap.png"),
                                    new LODTextureSet
                                        (@"Textures\Ground_Fence_Steel__MainTex_LOD.png",
                                            @"Textures\Ground_Fence_Steel__AlphaMap_LOD.png",
                                            @"Textures\Ground_Fence_Steel__XYSMap_LOD.png"));
                            }
                            else if (node.m_mesh.name.Contains("Pavement"))
                            {
                                node.SetTextures(
                                    new TextureSet
                                        (@"Textures\Ground_Node_Pavement_Small__MainTex.png",
                                            @"Textures\Ground_Node_Pavement_Small__AlphaMap.png",
                                            @"Textures\Ground_Segment_Pavement_Steel__XYSMap.png"),
                                    new LODTextureSet
                                        (@"Textures\Ground_Node_Pavement_Steel__MainTex_LOD.png",
                                            @"Textures\Ground_Node_Pavement_Steel__AlphaMap_LOD.png",
                                            @"Textures\Ground_Segment_Pavement_Steel__XYSMap_LOD.png"));
                            }
                            else if (node.m_mesh.name.Contains("ThirdRail"))
                            {
                                node.SetTextures(
                                    new TextureSet
                                        (@"Textures\ThirdRail__MainTex.png",
                                            @"Textures\ThirdRail__AlphaMap.png",
                                            @"Textures\ThirdRail__XYSMap.png"),
                                    new LODTextureSet
                                        (@"Textures\ThirdRail__MainTex_LOD.png",
                                            @"Textures\ThirdRail__AlphaMap_LOD.png",
                                            @"Textures\ThirdRail__XYSMap_LOD.png"));
                            }
                            else
                            {
                                node.SetTextures(
                                    new TextureSet
                                        (@"Textures\Ground_Segment_Rail__MainTex.png",
                                            @"Textures\Ground_Segment_Rail__AlphaMap.png",
                                            @"Textures\Ground_Segment_Rail__XYSMap.png"));
                            }
                        }
                        break;
                    }
                case NetInfoVersion.Elevated:
                case NetInfoVersion.Bridge:
                    {
                        foreach (var segment in info.m_segments)
                        {
                            var elevatedBridge = segment.m_mesh.name.Contains("Elevated") ? "Elevated" : "Bridge";
                            if (segment.m_mesh.name.Contains("Station"))
                            {

                                segment.SetTextures(
                                    new TextureSet
                                        ($@"Textures\{elevatedBridge}_Station_Segment_Pavement_Steel__MainTex.png",
                                            $@"Textures\{elevatedBridge}_Segment_Pavement_Steel__AlphaMap.png",
                                            $@"Textures\{elevatedBridge}_Segment_Pavement_Steel__XYSMap.png"),
                                    new LODTextureSet
                                        ($@"Textures\{elevatedBridge}_Segment_Pavement_Steel__MainTex_LOD.png",
                                            $@"Textures\{elevatedBridge}_Segment_Pavement_Steel__AlphaMap_LOD.png",
                                            $@"Textures\{elevatedBridge}_Segment_Pavement_Steel__XYSMap_LOD.png"));
                            }
                            else if (segment.m_mesh.name.Contains("Pavement") || (segment.m_mesh.name.Contains("Fence")) || (segment.m_mesh.name.Contains("Bar")))
                            {
                                segment.SetTextures(
                                    new TextureSet
                                        ($@"Textures\{elevatedBridge}_Segment_Pavement_Steel_Small__MainTex.png",
                                            $@"Textures\{elevatedBridge}_Segment_Pavement_Steel__AlphaMap.png",
                                            $@"Textures\{elevatedBridge}_Segment_Pavement_Steel__XYSMap.png"),
                                    new LODTextureSet
                                        ($@"Textures\{elevatedBridge}_Segment_Pavement_Steel__MainTex_LOD.png",
                                            $@"Textures\{elevatedBridge}_Segment_Pavement_Steel__AlphaMap_LOD.png",
                                            $@"Textures\Elevated_Segment_Pavement__XYSMap_LOD.png"));
                            }
                            else if (segment.m_mesh.name.Contains("ThirdRail"))
                            {
                                segment.SetTextures(
                                    new TextureSet
                                        (@"Textures\ThirdRail__MainTex.png",
                                            @"Textures\ThirdRail__AlphaMap.png",
                                            @"Textures\ThirdRail__XYSMap.png"),
                                    new LODTextureSet
                                        (@"Textures\ThirdRail__MainTex_LOD.png",
                                            @"Textures\ThirdRail__AlphaMap_LOD.png",
                                            @"Textures\ThirdRail__XYSMap_LOD.png"));
                            }
                            else
                            {
                                segment.SetTextures(
                                    new TextureSet
                                        (@"Textures\Ground_Segment_Rail__MainTex.png",
                                            @"Textures\Ground_Segment_Rail__AlphaMap.png",
                                            @"Textures\Ground_Segment_Rail__XYSMap.png"));
                            }
                        }
                        foreach (var node in info.m_nodes)
                        {
                            if (node.m_mesh.name.Contains("LevelCrossing_Rail"))
                            {
                                node.SetTextures(
                                    new TextureSet
                                        (@"Textures\Ground_Level_Crossing_Rail__MainTex.png",
                                            @"Textures\Ground_Segment_Rail__AlphaMap.png",
                                            @"Textures\Ground_Level_Crossing_Rail__XYSMap.png"));
                            }
                            else if (node.m_mesh.name.Contains("LevelCrossing"))
                            {
                                node.SetTextures(
                                    new TextureSet
                                        (@"Textures\Ground_Level_Crossing__MainTex.png",
                                            @"Textures\Ground_Level_Crossing__AlphaMap.png"),
                                    new LODTextureSet
                                        (@"Textures\Ground_Level_Crossing__MainTex_LOD.png",
                                            @"Textures\Ground_Level_Crossing__AlphaMap_LOD.png",
                                            @"Textures\Ground_Segment_Pavement__XYSMap_LOD.png"));
                            }
                            else if (node.m_mesh.name.Contains("Pavement") || (node.m_mesh.name.Contains("Fence")) || (node.m_mesh.name.Contains("Bar")))
                            {
                                if (node.m_mesh.name.Contains("Trans"))
                                {
                                    node.SetTextures(
                                        new TextureSet
                                            (@"Textures\Elevated_Node_Pavement__MainTex.png",
                                                @"Textures\Elevated_Node_Pavement__AlphaMap.png",
                                                @"Textures\Ground_Segment_Pavement__XYSMap.png"),
                                        new LODTextureSet
                                            (@"Textures\Elevated_Node_Pavement__MainTex_LOD.png",
                                                @"Textures\Elevated_Node_Pavement__AlphaMap_LOD.png",
                                                @"Textures\Elevated_Segment_Pavement__XYSMap_LOD.png"));
                                }
                                if (node.m_mesh.name.Contains("Elevated"))
                                {
                                    node.SetTextures(
                                        new TextureSet
                                            (@"Textures\Elevated_Node_Pavement_Steel__MainTex.png",
                                                @"Textures\Elevated_Node_Pavement_Steel__AlphaMap.png",
                                                @"Textures\Ground_Segment_Pavement_Steel__XYSMap.png"),
                                        new LODTextureSet
                                            (@"Textures\Elevated_Segment_Pavement_Steel__MainTex_LOD.png",
                                                @"Textures\Elevated_Segment_Pavement_Steel__AlphaMap_LOD.png",
                                                @"Textures\Ground_Segment_Pavement_Steel__XYSMap_LOD.png"));
                                }
                                else if (node.m_mesh.name.Contains("Bridge"))
                                {
                                    node.SetTextures(
                                        new TextureSet
                                            (@"Textures\Bridge_Segment_Pavement_Steel__MainTex.png",
                                                @"Textures\Bridge_Segment_Pavement_Steel__AlphaMap.png",
                                                @"Textures\Bridge_Segment_Pavement_Steel__XYSMap.png"),
                                        new LODTextureSet
                                            (@"Textures\Bridge_Segment_Pavement_Steel__MainTex_LOD.png",
                                                @"Textures\Bridge_Segment_Pavement_Steel__AlphaMap_LOD.png",
                                                @"Textures\Bridge_Segment_Pavement_Steel__XYSMap_LOD.png"));
                                }
                            }
                            else if (node.m_mesh.name.Contains("ThirdRail"))
                            {
                                node.SetTextures(
                                    new TextureSet
                                        (@"Textures\ThirdRail__MainTex.png",
                                            @"Textures\ThirdRail__AlphaMap.png",
                                            @"Textures\ThirdRail__XYSMap.png"),
                                    new LODTextureSet
                                        (@"Textures\ThirdRail__MainTex_LOD.png",
                                            @"Textures\ThirdRail__AlphaMap_LOD.png",
                                            @"Textures\ThirdRail__XYSMap_LOD.png"));
                            }
                            else if (node.m_mesh.name.Contains("Boosted"))
                            {
                                node.SetTextures(
                                    new TextureSet
                                        (@"Textures\Elevated_Segment_Steel_Rail__MainTex.png",
                                            @"Textures\Ground_Segment_Rail__AlphaMap.png",
                                            @"Textures\Elevated_Segment_Steel_Rail__XYSMap.png"),
                                    new LODTextureSet
                                        (@"Textures\Elevated_Segment_Steel_Rail__MainTex_LOD.png",
                                            @"Textures\Ground_Segment_Rail__AlphaMap_LOD.png",
                                            @"Textures\Elevated_Segment_Steel_Rail__XYSMap_LOD.png"));
                            }
                            else if (node.m_mesh.name.Contains("LevelCrossing_Rail"))
                            {
                                node.SetTextures(
                                    new TextureSet
                                        (@"Textures\Ground_Level_Crossing_Rail__MainTex.png",
                                            @"Textures\Ground_Segment_Rail__AlphaMap.png",
                                            @"Textures\Ground_Level_Crossing_Rail__XYSMap.png"));
                            }
                            else if (node.m_mesh.name.Contains("LevelCrossing"))
                            {
                                node.SetTextures(
                                    new TextureSet
                                        (@"Textures\Ground_Level_Crossing__MainTex.png",
                                            @"Textures\Ground_Level_Crossing__AlphaMap.png"),
                                    new LODTextureSet
                                        (@"Textures\Ground_Level_Crossing__MainTex_LOD.png",
                                            @"Textures\Ground_Level_Crossing__AlphaMap_LOD.png",
                                            @"Textures\Ground_Segment_Pavement__XYSMap_LOD.png"));
                            }
                            else
                            {
                                node.SetTextures(
                                    new TextureSet
                                        (@"Textures\Ground_Segment_Rail__MainTex.png",
                                            @"Textures\Ground_Segment_Rail__AlphaMap.png",
                                            @"Textures\Ground_Segment_Rail__XYSMap.png"));
                            }
                        }
                        break;
                    }
                case NetInfoVersion.Slope:
                case NetInfoVersion.Tunnel:
                    {
                        for (var i = 0; i < info.m_segments.Length; i++)
                        {
                            var segment = info.m_segments[i];
                            if (segment.m_mesh.name.Contains("Steel_Ground"))
                            {
                                segment.SetTextures(
                                    new TextureSet
                                        (@"Textures\Ground_Segment_Pavement_Steel_Small__MainTex.png",
                                            @"Textures\Ground_Segment_Pavement_Small__AlphaMap.png",
                                            @"Textures\Tunnel_Segment_Pavement_Steel__XYSMap.png"),
                                    new LODTextureSet
                                        (@"Textures\Ground_Segment_Pavement_Steel_Small__MainTex_LOD.png",
                                            @"Textures\Ground_Segment_Pavement_Small__AlphaMap_LOD.png",
                                            @"Textures\Tunnel_Segment_Pavement_Steel__XYSMap_LOD.png"));
                            }
                            else if (segment.m_mesh.name.Contains("Pavement_Steel") || (segment.m_mesh.name.Contains("Fence_Steel")))
                            {
                                segment.SetTextures(
                                    new TextureSet
                                        (@"Textures\Tunnel_Segment_Pavement_Steel__MainTex.png",
                                            @"Textures\Ground_Segment_Rail__AlphaMap.png",
                                            @"Textures\Tunnel_Segment_Pavement_Steel__XYSMap.png"),
                                    new LODTextureSet
                                        (@"Textures\Tunnel_Segment_Pavement_Steel__MainTex_LOD.png",
                                            @"Textures\Ground_Segment_Rail__AlphaMap_LOD.png",
                                            @"Textures\Tunnel_Segment_Pavement_Steel__XYSMap_LOD.png"));
                            }
                            else if (segment.m_mesh.name.Contains("ThirdRail"))
                            {
                                segment.SetTextures(
                                    new TextureSet
                                        (@"Textures\ThirdRail__MainTex.png",
                                            @"Textures\ThirdRail__AlphaMap.png",
                                            @"Textures\ThirdRail__XYSMap.png"),
                                    new LODTextureSet
                                        (@"Textures\ThirdRail__MainTex_LOD.png",
                                            @"Textures\ThirdRail__AlphaMap_LOD.png",
                                            @"Textures\ThirdRail__XYSMap_LOD.png"));
                            }
                            else
                            {
                                segment.SetTextures(
                                    new TextureSet
                                        (@"Textures\Ground_Segment_Rail__MainTex.png",
                                            @"Textures\Ground_Segment_Rail__AlphaMap.png",
                                            @"Textures\Ground_Segment_Rail__XYSMap.png"));
                            }
                        }
                        for (var i = 0; i < info.m_nodes.Length; i++)
                        {
                            var node = info.m_nodes[i];
                            if (node.m_mesh.name.Contains("Node_Pavement") || (node.m_mesh.name.Contains("Fence_Steel")))
                            {
                                node.SetTextures(
                                    new TextureSet
                                        (@"Textures\Tunnel_Node_Pavement_Steel__MainTex.png",
                                            @"Textures\Ground_Segment_Rail__AlphaMap.png",
                                            @"Textures\Tunnel_Segment_Pavement_Steel__XYSMap.png"),
                                    new LODTextureSet
                                        (@"Textures\Tunnel_Node_Pavement_Steel__MainTex_LOD.png",
                                            @"Textures\Ground_Segment_Rail__AlphaMap_LOD.png",
                                            @"Textures\Tunnel_Segment_Pavement_Steel__XYSMap_LOD.png"));
                            }
                            else if (node.m_mesh.name.Contains("Trans"))
                            {
                                node.SetTextures(
                                    new TextureSet
                                        (@"Textures\Tunnel_Node_Pavement__MainTex.png",
                                            @"Textures\Elevated_Node_Pavement__AlphaMap.png",
                                            @"Textures\Tunnel_Segment_Pavement__XYSMap.png"),
                                    new LODTextureSet
                                        (@"Textures\Tunnel_Node_Pavement__MainTex_LOD.png",
                                            @"Textures\Elevated_Node_Pavement__AlphaMap_LOD.png",
                                            @"Textures\Tunnel_Segment_Pavement__XYSMap_LOD.png"));
                            }
                            else if (node.m_mesh.name.Contains("ThirdRail"))
                            {
                                node.SetTextures(
                                    new TextureSet
                                        (@"Textures\ThirdRail__MainTex.png",
                                            @"Textures\ThirdRail__AlphaMap.png",
                                            @"Textures\ThirdRail__XYSMap.png"),
                                    new LODTextureSet
                                        (@"Textures\ThirdRail__MainTex_LOD.png",
                                            @"Textures\ThirdRail__AlphaMap_LOD.png",
                                            @"Textures\ThirdRail__XYSMap_LOD.png"));
                            }
                            else if (node.m_mesh.name.Contains("LevelCrossing_Rail"))
                            {
                                node.SetTextures(
                                    new TextureSet
                                        (@"Textures\Ground_Level_Crossing_Rail__MainTex.png",
                                            @"Textures\Ground_Segment_Rail__AlphaMap.png",
                                            @"Textures\Ground_Level_Crossing_Rail__XYSMap.png"));
                            }
                            else if (node.m_mesh.name.Contains("LevelCrossing"))
                            {
                                node.SetTextures(
                                    new TextureSet
                                        (@"Textures\Ground_Level_Crossing__MainTex.png",
                                            @"Textures\Ground_Level_Crossing__AlphaMap.png"),
                                    new LODTextureSet
                                        (@"Textures\Ground_Level_Crossing__MainTex_LOD.png",
                                            @"Textures\Ground_Level_Crossing__AlphaMap_LOD.png",
                                            @"Textures\Ground_Segment_Pavement__XYSMap_LOD.png"));
                            }
                            else
                            {
                                node.SetTextures(
                                    new TextureSet
                                        (@"Textures\Ground_Segment_Rail__MainTex.png",
                                            @"Textures\Ground_Segment_Rail__AlphaMap.png",
                                            @"Textures\Ground_Segment_Rail__XYSMap.png"));
                            }
                        }
                        break;
                    }
            }
        }
    }
}

