using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovenyTulelo
{
     public class Noveny
    {
        public string Nev { get; private set; }
        public int Tapanyag { get; protected set; }
        public static readonly Noveny Min = new Noveny("Default",0);

        public Noveny(string n, int t)
        {
            Nev = n;
            Tapanyag = t;
        }

        public virtual bool IsPuffancs() => false;
        public virtual bool IsDeltafa() => false;
        public virtual bool IsParabokor() => false;

        public virtual void TapanyagValtoztat(SugarzasFajta s) { }
        public virtual void Igenyel(Sugarzas s) { }
        public virtual bool ElE() => Tapanyag > 0;
    }

    public class Puffancs : Noveny
    {
        public Puffancs(string n, int t) : base(n, t) { }

        public override bool IsPuffancs() => true;

        public override void TapanyagValtoztat(SugarzasFajta s)
        {
           if (ElE()) Tapanyag += s.BefolyasolPuffancs();
        }

        public override bool ElE()
        {
            return Tapanyag > 0 && Tapanyag < 11;
        }

        public override void Igenyel(Sugarzas s)
        {
            if (ElE()) s.IgenyelA(10);
        }

        public override string ToString()
        {
            return $"{Nev} Puffancs {Tapanyag}";
        }
    }

    public class Deltafa : Noveny
    {
        public Deltafa(string n, int t) : base(n, t) { }

        public override bool IsDeltafa() => true;

        public override void Igenyel(Sugarzas s)
        {
            if (Tapanyag < 11 && Tapanyag > 4)
            {
                s.IgenyelD(1);
            }
            else if (Tapanyag < 5 && Tapanyag > 0) {
                s.IgenyelD(4);
            }
        }

        public override void TapanyagValtoztat(SugarzasFajta s)
        {
            if (ElE()) Tapanyag += s.BefolyasolDeltafa();
        }

        public override string ToString()
        {
            return $"{Nev} Deltafa {Tapanyag}";
        }
    }

    public class Parabokor : Noveny
    {
        public Parabokor(string n, int t) : base(n, t) { }

        public override bool IsParabokor() => true;

        public override void TapanyagValtoztat(SugarzasFajta s)
        {
            if(ElE()) Tapanyag += s.BefolyasolParabokor();
        }

        public override string ToString()
        {
            return $"{Nev} Parabokor {Tapanyag}";
        }
    }

}
