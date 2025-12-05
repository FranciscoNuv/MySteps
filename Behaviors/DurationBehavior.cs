using Microsoft.Maui.Controls;
using System.Linq;

namespace MySteps.Behaviors;

public class DurationBehavior : Behavior<Entry>
{
    bool _isUpdating;

    protected override void OnAttachedTo(Entry entry)
    {
        base.OnAttachedTo(entry);
        entry.TextChanged += OnTextChanged;
    }

    protected override void OnDetachingFrom(Entry entry)
    {
        base.OnDetachingFrom(entry);
        entry.TextChanged -= OnTextChanged;
    }

    void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        if (_isUpdating)
            return;
        var entry = (Entry)sender;
        if (string.IsNullOrEmpty(e.NewTextValue))
        {
            return;
        }
        _isUpdating = true;
        try
        {
            var digits = new string(e.NewTextValue.Where(char.IsDigit).ToArray());
            if (string.IsNullOrEmpty(digits))
            {
                entry.Text = string.Empty;
                return;
            }
            if (digits.Length == 1)
            {
                digits = "0" + digits;
            }
            string minutesStr;
            string secondsStr;
            if (digits.Length <= 2)
            {
                minutesStr = "0";
                secondsStr = digits.PadLeft(2, '0');
            }
            else
            {
                secondsStr = digits.Substring(digits.Length - 2, 2);
                minutesStr = digits.Substring(0, digits.Length - 2);
                minutesStr = minutesStr.TrimStart('0');
                if (string.IsNullOrEmpty(minutesStr))
                    minutesStr = "0";
            }
            if (int.TryParse(secondsStr, out int seconds))
            {
                if (seconds > 59)
                    seconds = 59;
                secondsStr = seconds.ToString("00");
            }
            else
            {
                secondsStr = "00";
            }
            var formatted = $"{minutesStr}:{secondsStr}";
            if (entry.Text != formatted)
            {
                entry.Text = formatted;
            }
            entry.TextColor = Colors.Black;
        }
        finally
        {
            _isUpdating = false;
        }
    }
}
