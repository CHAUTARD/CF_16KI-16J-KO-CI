using System;

namespace CF_16KI_16J_KO_CI.Gestion
{
    public class ComboboxItem
    {
        public int Key { get; set; }
        public string Value { get; set; }

        public ComboboxItem(int _key, string _value)
        {
            Key = _key;
            Value = _value ?? throw new ArgumentNullException(nameof(_value));
        }

        public int ToKey() { return Key; }

        public override string ToString() { return Value; }
    }
}
