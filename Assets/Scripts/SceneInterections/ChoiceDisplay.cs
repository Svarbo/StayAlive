using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceDisplay : MonoBehaviour
{
    [SerializeField] private Events _events;

    private List<Toggle> _toggles = new List<Toggle>();

    private void Awake()
    {
        TakeToggles();
    }

    private void OnEnable()
    {
        _events.CurrentChanged += Display;
    }

    private void OnDisable()
    {
        _events.CurrentChanged -= Display;
    }

    private void Display()
    {
        OffAll();

        int choicesCount = _events.CurrentEvent.Choices.Count;

        if (choicesCount != 0)
        {
            for (int i = 0; i < choicesCount; i++)
            {
                ChangeText(i);
                _toggles[i].gameObject.SetActive(true);
            }

            _toggles[_events.CurrentEvent.FinalChoiceIndex].isOn = true;
        }
    }

    private void OffAll()
    {
        foreach(Toggle toggle in _toggles)
            toggle.gameObject.SetActive(false);
    }

    private void ChangeText(int toggleIndex)
    {
        string description = _events.CurrentEvent.Choices[toggleIndex].Description;
        _toggles[toggleIndex].GetComponentInChildren<Text>().text = description;
    }

    private void TakeToggles()
    {
        foreach(Transform toggle in transform)
            _toggles.Add(toggle.GetComponent<Toggle>());
    }
}