using Microsoft.VisualStudio.TestTools.UnitTesting;
using NovenyTulelo;

namespace NovenyTuleloTest
{
    [TestClass]
    public class NovenySugarzasTest
    {
        [TestMethod]
        public void KonstruktorTest()
        {
            Noveny n = new Puffancs("Pufi", 3);
            // a példány megkapja-e a nevét és a tápanyagot
            Assert.AreEqual("Pufi",n.Nev);
            Assert.AreEqual(3,n.Tapanyag);

            n = new Deltafa("Deltas", 7);
            Assert.AreEqual("Deltas", n.Nev);
            Assert.AreEqual(7, n.Tapanyag);

            n = new Parabokor("Parás", 10);
            Assert.AreEqual("Parás", n.Nev);
            Assert.AreEqual(10, n.Tapanyag);
        }

        [TestMethod]
        public void IsMetodusTest() {
            Noveny n = new Puffancs("Pufi", 3);
            Noveny d = new Deltafa("Deltas", 7);
            Noveny p = new Parabokor("Paras", 7);

            SugarzasFajta sa = Alfa.Instance;
            SugarzasFajta sd = Delta.Instance;
            SugarzasFajta sn = Nincs.Instance;

            //is függvények helyes értékkel térnek-e vissza
            Assert.IsTrue(n.IsPuffancs());
            Assert.IsFalse(n.IsParabokor());
            Assert.IsFalse(n.IsDeltafa());
            Assert.IsTrue(d.IsDeltafa());
            Assert.IsFalse(d.IsParabokor());
            Assert.IsFalse(d.IsPuffancs());
            Assert.IsTrue(p.IsParabokor());
            Assert.IsFalse(p.IsDeltafa());
            Assert.IsFalse(p.IsPuffancs());

            Assert.IsTrue(sa.IsAlfa());
            Assert.IsFalse(sa.IsDelta());
            Assert.IsFalse(sa.IsNincs());
            Assert.IsTrue(sd.IsDelta());
            Assert.IsFalse(sd.IsAlfa());
            Assert.IsFalse(sd.IsNincs());
            Assert.IsTrue(sn.IsNincs());
            Assert.IsFalse(sn.IsDelta());
            Assert.IsFalse(sn.IsAlfa());
        }

        [TestMethod]
        public void ElETest() {
            Noveny p1 = new Puffancs("Pufi", 2);
            Noveny p2 = new Parabokor("Paras", 2);
            Noveny d = new Deltafa("Deltas",2);

            Assert.IsTrue(p1.ElE());
            p1 = new Puffancs("Pufi", 0);
            Assert.IsFalse(p1.ElE());
            p1 = new Puffancs("Pufi", 11);
            Assert.IsFalse(p1.ElE());
            
            Assert.IsTrue(p2.ElE());
            p2 = new Parabokor("Paras", 0);
            Assert.IsFalse(p2.ElE());

            Assert.IsTrue(d.ElE());
            d = new Deltafa("Deltas", 0);
            Assert.IsFalse(d.ElE());
        }

        [TestMethod]
        public void TapanyagValtoztat() {
            Noveny p1 = new Puffancs("Pufi", 2);
            Noveny p2 = new Parabokor("Paras", 1);
            Noveny d = new Deltafa("Deltas", 2);

            p1.TapanyagValtoztat(Alfa.Instance);
            Assert.AreEqual(4, p1.Tapanyag);
            p1.TapanyagValtoztat(Delta.Instance);
            Assert.AreEqual(2, p1.Tapanyag);
            p1.TapanyagValtoztat(Nincs.Instance);
            Assert.AreEqual(1, p1.Tapanyag);
            p1.TapanyagValtoztat(Nincs.Instance);//meghalt
            p1.TapanyagValtoztat(Nincs.Instance);//halál után sem változik
            Assert.AreEqual(0, p1.Tapanyag);

            p2.TapanyagValtoztat(Alfa.Instance);
            Assert.AreEqual(2, p2.Tapanyag);
            p2.TapanyagValtoztat(Delta.Instance);
            Assert.AreEqual(3, p2.Tapanyag);
            p2.TapanyagValtoztat(Nincs.Instance);
            Assert.AreEqual(2, p2.Tapanyag);
            p2.TapanyagValtoztat(Nincs.Instance);
            p2.TapanyagValtoztat(Nincs.Instance);
            p2.TapanyagValtoztat(Nincs.Instance);
            Assert.AreEqual(0, p2.Tapanyag);

            d.TapanyagValtoztat(Delta.Instance);
            Assert.AreEqual(6, d.Tapanyag);
            d.TapanyagValtoztat(Alfa.Instance);
            Assert.AreEqual(3, d.Tapanyag);
            d.TapanyagValtoztat(Nincs.Instance);
            Assert.AreEqual(2, d.Tapanyag);
            d.TapanyagValtoztat(Alfa.Instance);
            d.TapanyagValtoztat(Alfa.Instance);
            Assert.AreEqual(d.Tapanyag, -1);
        }

        [TestMethod]
        public void IgenyelTest() {
            //sugárzás változik-e alfára
            Sugarzas s = new Sugarzas();
            Noveny p = new Puffancs("Pufi", 3);
            Noveny pa = new Parabokor("Para", 1);
            Noveny d1 = new Deltafa("Deltas", 3);
            Noveny d2 = new Deltafa("Szalkas", 3);
            Noveny d3 = new Deltafa("Hosszu", 4);
            Noveny d4 = new Deltafa("Lombos", 6);
            p.Igenyel(s);
            s.Valtozik();
            Assert.IsTrue(s.Dominans.IsAlfa());

            //sugárzás változik-e Nincsre
            d1.Igenyel(s);
            d2.Igenyel(s);
            p.Igenyel(s);
            s.Valtozik();
            Assert.IsTrue(s.Dominans.IsNincs());

            //sugárzás változik-e deltára
            d1.Igenyel(s);
            d2.Igenyel(s);
            d3.Igenyel(s);
            d4.Igenyel(s);
            p.Igenyel(s);
            s.Valtozik();
            Assert.IsTrue(s.Dominans.IsDelta());

            p.TapanyagValtoztat(s.Dominans);
            p.TapanyagValtoztat(s.Dominans); //megöltük Pufi-t
            p.Igenyel(s); //nem tud igényelni
            s.Valtozik(); //nincs lesz
            Assert.IsTrue(s.Dominans.IsNincs());

            d1.TapanyagValtoztat(s.Dominans);
            d1.TapanyagValtoztat(s.Dominans);
            d1.TapanyagValtoztat(s.Dominans);
            d1.Igenyel(s);
            s.Valtozik();
            Assert.IsTrue(s.Dominans.IsNincs());

            pa.Igenyel(s);
            s.Valtozik();
            Assert.IsTrue(s.Dominans.IsNincs());
            pa.TapanyagValtoztat(s.Dominans);
            pa.Igenyel(s);
            s.Valtozik();
            Assert.IsTrue(s.Dominans.IsNincs());
        }

        [TestMethod]
        public void BefolyasolTest() {
            SugarzasFajta a = Alfa.Instance;
            SugarzasFajta d = Delta.Instance;
            SugarzasFajta n = Nincs.Instance;

            Assert.IsTrue(n.IsNincs());
            Assert.AreEqual(-1, n.BefolyasolDeltafa());
            Assert.AreEqual(-1, n.BefolyasolParabokor());
            Assert.AreEqual(-1, n.BefolyasolPuffancs());
            
            Assert.IsTrue(d.IsDelta());
            Assert.AreEqual(4, d.BefolyasolDeltafa());
            Assert.AreEqual(1, d.BefolyasolParabokor());
            Assert.AreEqual(-2, d.BefolyasolPuffancs());
            
            Assert.IsTrue(a.IsAlfa());
            Assert.AreEqual(-3, a.BefolyasolDeltafa());
            Assert.AreEqual(1, a.BefolyasolParabokor());
            Assert.AreEqual(2, a.BefolyasolPuffancs());
        }

    }
}
