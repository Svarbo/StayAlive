using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EventsData))]
public class EventsDataEditor : Editor
{
    private EventsData _eventsData;

    private void Awake()
    {
        _eventsData = (EventsData)target;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Remove"))
            _eventsData.RemoveCurrentElement();
        if (GUILayout.Button("Add"))
            _eventsData.AddElement();
        if (GUILayout.Button("<="))
            _eventsData.TryGetPreviousEventData();
        if (GUILayout.Button("=>"))
            _eventsData.TryGetNextEventData();

        GUILayout.EndHorizontal();
        base.OnInspectorGUI();
    }
}
