﻿// Copyright (c) DGP Studio. All rights reserved.
// Licensed under the MIT license.

using Snap.HutaoAPI.Entities.Record;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snap.HutaoAPI.Entities;

/// <summary>
/// 玩家实体
/// </summary>
public class Player
{
    /// <summary>
    /// 玩家Id (from database)
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid InnerId { get; set; }

    /// <summary>
    /// 玩家uid
    /// </summary>
    [Required]
    public string Uid { get; set; } = null!;

    /// <summary>
    /// 外键
    /// </summary>
    public IList<DetailedAvatarInfo> Avatars { get; set; } = null!;
}
