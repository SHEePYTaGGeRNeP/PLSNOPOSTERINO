using System;
using System.Windows.Forms;

namespace PLS_NO_POSTERINO.Classes
{
    public class TitlesToBlock
    {
        public string Name { get; private set; }
        public TitleCheckKind Kind { get; private set; }
        public NativeWin32.ProcessWindow Window { get; set; }
        public TitlesToBlock(string pName, TitleCheckKind pKind)
        {
            this.Name = pName;
            this.Kind = pKind;
        }

        public override string ToString()
        {
            return this.Name + "  {" + this.Kind + "}";
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
