using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMDBApplication.Models;

namespace CMDBApplication.ViewModels
{
    public class AreaView : ViewModel
    {
        public List<Area> Areas { get; set; }
        public Area Area { get; set; }

        public AreaView()
            : base()
        {
            Areas = new List<Area>();
            Area = new Area();

        }

    }
}
