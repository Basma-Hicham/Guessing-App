using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guessing_app.Models
{
    internal class PredDetails
    {
        public int pred_id { get; set; }
        public string image_path { get; set; }
        public string correct_answer { get; set; }
        public string wrong_answer { get; set; }


    }
}
