using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LegendsOfSlime.Global
{
    public static class GlobalConstance
    {
        #region AnimationState
        public const string WALK_ANIMATION = "Walk";
        public const string ATTACK_ANIMATION = "Attack";
        public const string DAMAGE_ANIMATION = "Damage";
        public const string DEATH_ANIMATION = "Death";
        #endregion
        #region Tags
        public const string ENEMY_TAG = "Enemy";
        public const string PLAYER_TAG = "Player";
        #endregion
        #region Enums
        public enum UnitCharacteristics { ATK, HP, S_ATK};
        #endregion
    }
}

