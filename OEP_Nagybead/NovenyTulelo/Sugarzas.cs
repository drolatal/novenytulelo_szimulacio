using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovenyTulelo
{
    public class Sugarzas
    {
        protected int igenyA = 0;
        protected int igenyD = 0;
        public SugarzasFajta Dominans { get; private set; }

        public Sugarzas()
        {
            igenyA = 0;
            igenyD = 0;
            Dominans = Nincs.Instance;
        }

        public void IgenyelA(int m)
        {
            igenyA += m;
        }

        public void IgenyelD(int m)
        {
            igenyD += m;
        }

        public void Valtozik() {
            if (igenyA + 3 <= igenyD)
            {
                Dominans = Delta.Instance;
            }
            else if (igenyA >= igenyD + 3)
            {
                Dominans = Alfa.Instance;
            }
            else {
                Dominans = Nincs.Instance;
            }
            igenyA = 0;
            igenyD = 0;
        }

    }

}
