using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovenyTulelo
{
    public class Bolygo
    {
        private Sugarzas sugarzas;
        private List<Noveny> novenyek;

        public Bolygo()
        {
            sugarzas = new Sugarzas();
            novenyek = new List<Noveny>();
        }

        public void SetMasnap() {
            foreach (var noveny in novenyek)
            {
                noveny.TapanyagValtoztat(sugarzas.Dominans);
                noveny.Igenyel(sugarzas);
            }
            sugarzas.Valtozik();
        }

        public (bool,Noveny) LegerosebbNoveny() {
            Noveny legerosebb = Noveny.Min;
            bool l = false;
            foreach (var noveny in novenyek)
            {
                if (!noveny.ElE()) continue;
                if (l && noveny.ElE())
                {
                    if (legerosebb.Tapanyag < noveny.Tapanyag)
                    {
                        legerosebb = noveny;
                    }
                }
                else if (!l && noveny.ElE()) {
                    l = true;
                    legerosebb = noveny;
                }
            }
            return (l,legerosebb);
        }

        public void AddNoveny(Noveny n) {
            novenyek.Add(n);
        }

        public void Szimulal(int napok)
        {
            for (int i = 1; i <= napok; i++)
            {
                Console.WriteLine($"{i}. nap sugarzas: {sugarzas.Dominans}");
                SetMasnap();
                foreach (var noveny in novenyek)
                {
                    Console.WriteLine(noveny);
                }
            }

        }
    }
}
