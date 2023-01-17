using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovenyTulelo
{
    public abstract class SugarzasFajta
    {
        public virtual bool IsAlfa() => false;
        public virtual bool IsDelta() => false;
        public virtual bool IsNincs() => false;

        public abstract int BefolyasolPuffancs();
        public abstract int BefolyasolDeltafa();
        public abstract int BefolyasolParabokor();
    }


    public class Alfa : SugarzasFajta
    {
        static Alfa instance;
        Alfa() { }
        static public Alfa Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Alfa();
                }
                return instance;
            }
        }

        public static void Destroy() {
            instance = null;
        }

        ~Alfa() {
            Destroy();
        }

        public override bool IsAlfa() => true;

        public override int BefolyasolPuffancs()
        {
            return 2;
        }

        public override int BefolyasolDeltafa()
        {
            return -3;
        }

        public override int BefolyasolParabokor()
        {
            return 1;
        }

        public override string ToString()
        {
            return "Alfa";
        }
    }

    public class Delta : SugarzasFajta
    {
        static Delta instance;
        Delta() { }
        static public Delta Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Delta();
                }
                return instance;
            }
        }

        public static void Destroy()
        {
            instance = null;
        }

        ~Delta()
        {
            Destroy();
        }


        public override bool IsDelta() => true;

        public override int BefolyasolPuffancs()
        {
            return -2;
        }

        public override int BefolyasolDeltafa()
        {
            return 4;
        }

        public override int BefolyasolParabokor()
        {
            return 1;
        }

        public override string ToString()
        {
            return "Delta";
        }
    }

    public class Nincs : SugarzasFajta
    {
        static Nincs instance;
        protected Nincs() { }
        static public Nincs Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Nincs();
                }
                return instance;
            }
        }

        public static void Destroy()
        {
            instance = null;
        }

        ~Nincs()
        {
            Destroy();
        }

        public override bool IsNincs() => true;

        public override int BefolyasolDeltafa()
        {
            return -1;
        }

        public override int BefolyasolParabokor()
        {
            return -1;
        }

        public override int BefolyasolPuffancs()
        {
            return -1;
        }

        public override string ToString()
        {
            return "Nincs";
        }
    }
}

