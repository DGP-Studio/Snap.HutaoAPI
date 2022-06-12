﻿// Copyright (c) DGP Studio. All rights reserved.
// Licensed under the MIT license.

using System.Text.Json.Serialization;

namespace Snap.HutaoAPI.Models.Enka;

/// <summary>
/// 装备
/// </summary>
public class Equip
{
    /// <summary>
    /// 物品Id
    /// Equipment ID
    /// </summary>
    [JsonPropertyName("itemId")]
    public int ItemId { get; set; }

    /// <summary>
    /// 圣遗物
    /// Artifact Base Info
    /// </summary>
    [JsonPropertyName("reliquary")]
    public Reliquary? Reliquary { get; set; }

    /// <summary>
    /// Detailed Info of Equipment
    /// </summary>
    [JsonPropertyName("flat")]
    public Flat Flat { get; set; } = default!;

    /// <summary>
    /// 武器
    /// Weapon Base Info
    /// </summary>
    [JsonPropertyName("weapon")]
    public Weapon? Weapon { get; set; }
}
