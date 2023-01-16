﻿namespace HotelLeSequelle.Models
{
    public class Hotell
    {
        public int ID { get; set; }
        public int AntalRum { get; set; }
        public int AntalVåningar { get; set; }
        public virtual ICollection<Våning> Våning { get; set; }
        public string Namn { get; set; }
        public string Land { get; set; }
        public string GatuAdress { get; set; }
        public string Postnummer { get; set; }
        public string PostOrt { get; set; }
        public string Telefonnummer { get; set; }
        public string Epost { get; set; }
        public string Hemsida { get; set; }

        public Hotell()
        {
            Våning = new HashSet<Våning>();
        }





    }
}
