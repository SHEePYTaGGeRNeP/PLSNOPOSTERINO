using System;
using System.Windows.Forms;

namespace PLS_NO_POSTERINO.Classes
{
    public class TitlesToBlock
    {
        public string Name { get; }
        public TitleCheckKind Kind { get; }
        public NativeWin32.ProcessWindow Window { get; set; }
        public TitlesToBlock(string pName, TitleCheckKind pKind)
        {
            Name = pName;
            Kind = pKind;
        }

        public override string ToString()
        {
            return Name + " - " + Kind;
        }
    }

    public enum TitleCheckKind
    {
        Equals,
        Contains,
        StartsWith,
        EndsWith
    }
}
