using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var caja = new Caja() { };
            caja.Total += Caja_Total; //Suscribirse a un evento
            caja.Total -= Caja_Total; //Desuscribirse a un evento
        }

        private static void Caja_Total(object o, TotalEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
    class Tikect
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
    }

    class Caja
    {
        public event TotalEventHandler Total;
        public Caja()
        {
            this.tickets = new List<Tikect>();
        }
        public virtual void OnTotal(TotalEventArgs e)
        {
            var handler = Total;
            if(null!=handler)
            {
                handler(this, e);
            }
        }
        public int Id { get; set; }
        public List<Tikect> tickets { get; private set;}
    }
    public delegate void TotalEventHandler(object o,TotalEventArgs e);

    public class TotalEventArgs:EventArgs
    {
        public TotalEventArgs(int id, decimal total)
        {
            Id = id;
            Total = total;

        }
        public int Id { get; private set; }
        public decimal Total { get; private set; }
    }
}
