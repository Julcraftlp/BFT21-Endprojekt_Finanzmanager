﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFT21_Endprojekt_Finanzmanager.Database.Datasets
{
    internal class InvoicePosition
    {
        public int Id { get; set; }
        public Invoice Buchung { get; set; } = null!;
        public int Position { get; set; } = 0!;
        public string Text { get; set; } = null!;
        public double BPPU { get; set; }
        public int Amt {  get; set; }
        public double NettoPreis { get; set; }
        public double BruttoPreis { get; set; }
    }
}
