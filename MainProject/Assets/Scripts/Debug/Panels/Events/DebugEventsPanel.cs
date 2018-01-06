using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugEventsPanel : MonoBehaviour
{
    [SerializeField]
    protected DebugEventsButton _defaultButtonElement;

    [SerializeField]
    protected DebugEventChapter _defaultChapterSeprator;

    [SerializeField]
    protected Transform _container;

    private List<DebugEventsButton> _buttons = new List<DebugEventsButton>();

    protected void Start()
    {
        InitButtons();
    }

    protected void OnDisable()
    {
        gameObject.SetActive(false);
    }

    protected void InitButtons()
    {
        DebugEventsButton button;
        string[] chapters = GameManager.Instance.ChapterManager.GetChapters();
        
        for (int j = 0; j < chapters.Length; ++j)
        {
            DebugEventChapter chapter = Instantiate<DebugEventChapter>(_defaultChapterSeprator, _container, true);
            chapter.gameObject.SetActive(true);
            chapter.UpdateInformation(chapters[j]);
            string[] events = GameManager.Instance.ChapterManager.GetEvents(chapters[j]);
            for (int i = 0, count = events.Length; i < count; ++i)
            {
                button = Instantiate<DebugEventsButton>(_defaultButtonElement, _container, true);
                button.UpdateButtonElement(events[i]);
                button.gameObject.SetActive(true);
                _buttons.Add(button);
            }
        }
    }
}