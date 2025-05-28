using Heron.MudCalendar;

namespace Learnova.Commons;

public class CalendarEvent
{
    /*
    Field "Text" in CalendarItem is used as title field of the event
    */
    public CalendarItem item { get; set; }
    public string description { get; set; }
    public int id { get; set; }
    public override bool Equals(object? obj)
    {
        return id == (obj as CalendarEvent).id;
    }
}