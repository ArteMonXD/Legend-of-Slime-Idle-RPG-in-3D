using LegendsOfSlime.Units.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LegendsOfSlime.Global.Economy_M
{
    public class EconomyManager : MonoBehaviour
    {
        Player player;
        Interface.GameInterface _interface;
        [SerializeField] private int money = 100;
        public int GetMoney
        {
            get { return money; }
        }
        [SerializeField] private int multipilierEarned;

        [SerializeField] private int basePriseLevelUp;
        [SerializeField] private int currentPriceAttack;
        public int GetPriceAttack
        {
            get { return currentPriceAttack; }
        }
        [SerializeField] private int currentPriceHealth;
        public int GetPriceHealth
        {
            get { return currentPriceHealth; }
        }
        [SerializeField] private int currentPriceSpeedAttack;
        public int GetPriceSpeedAttack
        {
            get { return currentPriceSpeedAttack; }
        }

        private static EconomyManager _instance;
        public static EconomyManager Instance
        {
            get { return _instance; }
        }
        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            else
                Destroy(gameObject);
        }
        private void Start()
        {
            currentPriceAttack = basePriseLevelUp;
            currentPriceHealth = basePriseLevelUp;
            currentPriceSpeedAttack = basePriseLevelUp;
            player = Player.Instance;
            _interface = Interface.GameInterface.Instance;
        }
        public void Earned(int stage)
        {
            money += multipilierEarned * stage;
            UpdateMoneyCounter();
        }

        private void UpdateMoneyCounter()
        {
            _interface.UpdateMoneyCounter();
        }

        private void UpdatePrices(GlobalConstance.UnitCharacteristics unitCharacteristics)
        {
            _interface.UpdatePrices(unitCharacteristics);
        }
        public void LevelUp(int state)
        {
            switch (state)
            {
                case 0:
                    if (CalculateUpgrade(ref currentPriceAttack))
                    {
                        player.PlayerUpgrade(GlobalConstance.UnitCharacteristics.ATK);
                        UpdateMoneyCounter();
                        UpdatePrices(GlobalConstance.UnitCharacteristics.ATK);
                    }  
                    break;
                case 1:
                    if(CalculateUpgrade(ref currentPriceHealth))
                    {
                        player.PlayerUpgrade(GlobalConstance.UnitCharacteristics.HP);
                        UpdateMoneyCounter();
                        UpdatePrices(GlobalConstance.UnitCharacteristics.HP);
                    }
                    break;
                case 2:
                    if(CalculateUpgrade(ref currentPriceSpeedAttack))
                    {
                        player.PlayerUpgrade(GlobalConstance.UnitCharacteristics.S_ATK);
                        UpdateMoneyCounter();
                        UpdatePrices(GlobalConstance.UnitCharacteristics.S_ATK);
                    } 
                    break;
            }
            

            bool CalculateUpgrade( ref int value)
            {
                if (money >= value)
                {
                    money -= value;
                    value += (basePriseLevelUp / 2);
                    return true;
                }
                else
                    return false;
            }
        }
    }
}

