﻿// Copyright (c) DGP Studio. All rights reserved.
// Licensed under the MIT license.

using System.ComponentModel.DataAnnotations;

namespace Snap.HutaoAPI.Models.Uploading
{
    /// <summary>
    /// 上传的深渊记录
    /// </summary>
    public class RecordInfo
    {
        /// <summary>
        /// 玩家Uid
        /// </summary>
        [MaxLength(10)]
        public string Uid { get; set; } = null!;

        /// <summary>
        /// 角色信息
        /// </summary>
        public List<AvatarInfo> PlayerAvatars { get; set; } = null!;

        /// <summary>
        /// 深渊信息
        /// </summary>
        public List<LevelInfo> PlayerSpiralAbyssesLevels { get; set; } = null!;
    }
}