using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TopSharksUI : MonoBehaviour
{
    [SerializeField] private Transform _contentPanel;
    [SerializeField] private TextMeshProUGUI _sharkText;

    private List<TextMeshProUGUI> _entries = new List<TextMeshProUGUI>();
    private TopSharksManager _topSharksManager;

    private void Start()
    {
        _topSharksManager.SetUI(this);
    }

    public void UpdateSharkList(List<Shark> sharks)
    {
        foreach (var entry in _entries)
        {
            Destroy(entry);
        }
        _entries.Clear();

        foreach (var shark in sharks)
        {
            var newEntry = Instantiate(_sharkText, _contentPanel);
            newEntry.text = $"{shark.name} - {shark.ScoreLevel}";
            _entries.Add(newEntry);
        }
    }

    public void Construct(TopSharksManager topSharksManager) =>
        _topSharksManager = topSharksManager;
}