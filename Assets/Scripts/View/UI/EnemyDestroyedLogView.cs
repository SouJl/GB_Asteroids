using System.Collections;
using TMPro;
using UnityEngine;

namespace GB_Asteroids.UI
{
    public class EnemyDestroyedLogView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _logText;
        [SerializeField] private float _resetTextTimer = 1.5f;

        private void Awake()
        {
            _logText.text = string.Empty;
        }

        public void DestroyTextChange(string demolished) 
        {
            _logText.text = $"Destroyed: {demolished}";
            StartCoroutine(ReserLog());
        }

        private IEnumerator ReserLog() 
        {
            yield return new WaitForSeconds(_resetTextTimer);
            _logText.text = string.Empty;
        }
    }
}
