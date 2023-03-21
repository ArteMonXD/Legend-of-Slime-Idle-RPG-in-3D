using LegendsOfSlime.Units.Player;
using UnityEngine;

namespace LegendsOfSlime.Global.Interface
{
    public class GameInterface : MonoBehaviour
    {
        Player player;
        [SerializeField] TMPro.TMP_Text moneyCounter;
        [SerializeField] TMPro.TMP_Text charATK;
        [SerializeField] TMPro.TMP_Text charHP;
        [SerializeField] TMPro.TMP_Text charS_ATK;
        [SerializeField] TMPro.TMP_Text priceATK;
        [SerializeField] TMPro.TMP_Text priceHP;
        [SerializeField] TMPro.TMP_Text priceS_ATK;
        [SerializeField] TMPro.TMP_Text lvlATK;
        [SerializeField] TMPro.TMP_Text lvlHP;
        [SerializeField] TMPro.TMP_Text lvlS_ATK;
        [SerializeField] private GameObject losePanel;
        [SerializeField] private GameObject winPanel;
        private static GameInterface _instance;
        public static GameInterface Instance
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
            player = Player.Instance;
        }
        public void UpdateMoneyCounter()
        {
            moneyCounter.text = Economy_M.EconomyManager.Instance.GetMoney.ToString();
        }
        private void LosePanelActive()
        {
            losePanel.SetActive(true);
        }

        private void WinPanelActive()
        {
            winPanel.SetActive(true);
        }

        public void EndGamePanel(bool status)
        {
            if (status)
                WinPanelActive();
            else
                LosePanelActive();
        }
        public void UpdatePrices(GlobalConstance.UnitCharacteristics unitCharacteristics)
        {
            switch (unitCharacteristics)
            {
                case GlobalConstance.UnitCharacteristics.ATK:
                    priceATK.text = Economy_M.EconomyManager.Instance.GetPriceAttack.ToString();
                    break;
                case GlobalConstance.UnitCharacteristics.HP:
                    priceHP.text = Economy_M.EconomyManager.Instance.GetPriceHealth.ToString();
                    break;
                case GlobalConstance.UnitCharacteristics.S_ATK:
                    priceS_ATK.text = Economy_M.EconomyManager.Instance.GetPriceSpeedAttack.ToString();
                    break;
            }
        }
        public void UpdateLevelsAndCharacteristic(GlobalConstance.UnitCharacteristics unitCharacteristics)
        {
            switch (unitCharacteristics)
            {
                case GlobalConstance.UnitCharacteristics.ATK:
                    lvlATK.text = player.GetLevelCharacteristic(unitCharacteristics).ToString();
                    charATK.text = player.PlayerCharacteristics.CurrentAttack.ToString();
                    break;
                case GlobalConstance.UnitCharacteristics.HP:
                    lvlHP.text = player.GetLevelCharacteristic(unitCharacteristics).ToString();
                    charHP.text = player.PlayerCharacteristics.HealthMax.ToString();
                    break;
                case GlobalConstance.UnitCharacteristics.S_ATK:
                    lvlS_ATK.text = player.GetLevelCharacteristic(unitCharacteristics).ToString();
                    charS_ATK.text = player.PlayerCharacteristics.GetCurrentAttackSpeed.ToString();
                    break;
            }
        }
    }
}

