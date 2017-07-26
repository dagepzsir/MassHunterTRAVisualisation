using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassHunterTRAnalyser.Data_Classes
{
    public interface IData
    {
         DataTable Data { get; set; }
    }
}
