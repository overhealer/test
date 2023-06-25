using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CoolNamespace
{
    public class HUDPanel : UIPanel
    {
        [SerializeField] private TMP_Text _pointsText;

        public void UpdatePointsText(int points)
        {
            _pointsText.text = "points: " + points;
        }
    }
}
