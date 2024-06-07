using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TopSharksUI : MonoBehaviour
{
    [SerializeField] private Transform _contentPanel;
    [SerializeField] private List<TextMeshProUGUI> _sharkTexts = new List<TextMeshProUGUI>();

    private TopSharksManager _topSharksManager;

    private void Start()
    {
        _topSharksManager.SetUI(this);
    }

    public void UpdateSharkList(List<Shark> sharks)
    {
        foreach (var sharkText in _sharkTexts)
        {
            sharkText.text = string.Empty;
        }

        for (int i = 0; i < sharks.Count && i < _sharkTexts.Count; i++)
        {
            _sharkTexts[i].text = $"{sharks[i].name} - {sharks[i].ScoreLevel}";
        }
    }

    public void Construct(TopSharksManager topSharksManager)
    {
        _topSharksManager = topSharksManager;
    }
}