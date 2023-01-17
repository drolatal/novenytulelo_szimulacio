using System;
using System.IO;

namespace NovenyTulelo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Bolygo b = new Bolygo();
                Console.WriteLine("Kérem adja meg a fájl nevét: ");
                string fajlNev = Console.ReadLine();
                Beolvas(b, fajlNev, out int napokSzama,out string vege);
                b.Szimulal(napokSzama);
                (bool,Noveny) legerosebb = b.LegerosebbNoveny();
                if (legerosebb.Item1)
                {
                    Console.WriteLine($"A legerősebb növény: {legerosebb.Item2}");
                    Console.WriteLine($"Teszteset:\n {vege}");
                }
                else
                {
                    Console.WriteLine($"Nincs élő növény");
                    Console.WriteLine($"Teszteset:\n {vege}");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"A file nem található!");
            }
        }

        static void peldanyosit(string[] darabok, out Noveny uj) {
            uj = null;
            if (darabok.Length == 3) {
                int ta;
                switch (darabok[1]) {
                    case "p":
                        if (int.TryParse(darabok[2], out ta)){
                            uj = new Puffancs(darabok[0], ta);
                        }
                        else { throw new FormatException("Hibas tapanyag mennyiseg!"); };
                        break;
                    case "d":
                        if (int.TryParse(darabok[2], out ta))
                        {
                            uj = new Deltafa(darabok[0], ta);
                        }
                        else { throw new FormatException("Hibas tapanyag mennyiseg!"); };
                        break;
                    case "b":
                        if (int.TryParse(darabok[2], out ta))
                        {
                            uj = new Parabokor(darabok[0], ta);
                        }
                        else { throw new FormatException("Hibas tapanyag mennyiseg!"); }
                        break;
                    default: throw new FormatException("Hibas tapanyag mennyiseg!");
                }
            }
            else {
                throw new ArgumentException("Nincs megfelelő számú paraméter a sorban!");
            }
        }

        static void Beolvas(Bolygo b, string fajlNev, out int napok,out string vege) {
            vege = "";
            napok = 0;
            using (StreamReader sr = new StreamReader(fajlNev)) {
                string sor = sr.ReadLine();
                Console.WriteLine(sor);
                int novSzam = 0;
                if (!int.TryParse(sor, out novSzam)){
                    throw new FormatException("Hibas noveny szam!");
                }
                for (int i = 0; i < novSzam; i++)
                {
                    sor = sr.ReadLine();
                    Console.WriteLine(sor);
                    string[] darabok = sor.Split(new char[] { ' ','\t'}, StringSplitOptions.RemoveEmptyEntries);
                    peldanyosit(darabok,out Noveny uj);
                    b.AddNoveny(uj);
                }
                sor = sr.ReadLine();
                if (!int.TryParse(sor, out napok)) {
                    throw new FormatException("Hibas napok szama!");
                }
                vege = sr.ReadToEnd();
            }
        }
    }
}
