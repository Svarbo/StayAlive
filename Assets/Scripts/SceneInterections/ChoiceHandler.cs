using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ToggleGroup))]
public class ChoiceHandler : MonoBehaviour
{
    [SerializeField] private Events _events;
    
    private ToggleGroup _choiceToggleGroup;

    private void Awake()
    {
        _choiceToggleGroup = GetComponent<ToggleGroup>();
    }

    public void ChangeChoice()
    {
        Toggle activeToggle = _choiceToggleGroup.GetFirstActiveToggle();
        int choiceIndex = activeToggle.transform.GetSiblingIndex();

        _events.ChangeFinalChoice(choiceIndex);
    }
}