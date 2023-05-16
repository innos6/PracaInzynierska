using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Models
{
    public class NewLogApearEventArgs : EventArgs
    {
        public string Body { get; set; }

        public ChartItem ChartItemBest { get; set; }

        public ChartItem ChartItemAverage { get; set; }
    }
}
