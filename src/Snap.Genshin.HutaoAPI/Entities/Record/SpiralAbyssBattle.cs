﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snap.HutaoAPI.Entities.Record
{
    public class SpiralAbyssBattle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public long InnerId { get; set; }

        /// <summary>
        /// 第几次战斗
        /// </summary>
        [Required]
        public int BattleIndex { get; set; }

        /// <summary>
        /// 上场角色的Id
        /// </summary>
        public IList<SpiralAbyssAvatar> Avatars { get; set; } = null!;

        /// <summary>
        /// 外键
        /// </summary>
        [ForeignKey(nameof(SpiralAbyssLevelId))]
        public SpiralAbyssLevel AbyssLevel { get; set; } = null!;

        public long SpiralAbyssLevelId { get; set; }
    }
}
