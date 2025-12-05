using Microsoft.Maui.Controls;
using System.Globalization;

namespace MySteps.Behaviors;

public class FloatBehavior : Behavior<Entry>
{
    private bool _isUpdating;
    private string _rawDigits = string.Empty;      // só dígitos
    private string _lastFormatted = string.Empty;  // texto formatado anterior

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
        var newText = e.NewTextValue ?? string.Empty;

        // Se apagou tudo, zera tudo
        if (string.IsNullOrEmpty(newText))
        {
            _isUpdating = true;
            _rawDigits = string.Empty;
            _lastFormatted = string.Empty;
            entry.Text = string.Empty;
            _isUpdating = false;
            return;
        }

        _isUpdating = true;

        try
        {
            // Detecta se foi adição ou remoção com base no texto anterior formatado
            if (newText.Length > _lastFormatted.Length)
            {
                // Provavelmente adicionou um caractere
                char addedChar = newText[^1];

                if (char.IsDigit(addedChar))
                {
                    _rawDigits += addedChar; // adiciona dígito (inclusive 0!)
                }
                // se não for dígito (vírgula, ponto, etc), ignora
            }
            else if (newText.Length < _lastFormatted.Length)
            {
                // Provavelmente backspace/delete
                if (_rawDigits.Length > 0)
                    _rawDigits = _rawDigits.Substring(0, _rawDigits.Length - 1);
            }
            else
            {
                // Mesmo tamanho (casos estranhos, colar texto, etc) -> recalcula bruto
                _rawDigits = "";
                foreach (var c in newText)
                {
                    if (char.IsDigit(c))
                        _rawDigits += c;
                }
            }

            if (string.IsNullOrEmpty(_rawDigits))
            {
                entry.Text = string.Empty;
                _lastFormatted = string.Empty;
                return;
            }

            // Garante pelo menos 2 dígitos para centavos
            if (_rawDigits.Length == 1)
                _rawDigits = "0" + _rawDigits;

            if (!long.TryParse(_rawDigits, out long raw))
                raw = 0;

            decimal value = raw / 100m;
            var culture = CultureInfo.GetCultureInfo("pt-BR");

            // 2 casas decimais, sem separador de milhar; se quiser com milhares, use "N2"
            string formatted = value.ToString("F2", culture);

            _lastFormatted = formatted;
            entry.Text = formatted;
            entry.CursorPosition = entry.Text.Length; // cursor sempre no fim

            entry.TextColor = Colors.Black;
        }
        finally
        {
            _isUpdating = false;
        }
    }
}
