using Microsoft.Maui.Controls;
using System.Globalization;

namespace MySteps.Behaviors;

public class FloatBehavior : Behavior<Entry>
{
    protected override void OnAttachedTo(Entry entry)
    {
        base.OnAttachedTo(entry);
        // entry.TextChanged += OnTextChanged;
        entry.Unfocused += OnEntryUnfocused;
    }

    protected override void OnDetachingFrom(Entry entry)
    {
        base.OnDetachingFrom(entry);
        entry.Unfocused -= OnEntryUnfocused;
        // entry.TextChanged -= OnTextChanged;
    }

    private void OnEntryUnfocused(object sender, FocusEventArgs e)
    {
        var entry = (Entry)sender;
        if (float.TryParse(entry.Text, out float value))
        {
            entry.Text = value.ToString("F2", System.Globalization.CultureInfo.CurrentCulture);
        }
        else
        {
            entry.Text = "0,00";
        }
    }

}
