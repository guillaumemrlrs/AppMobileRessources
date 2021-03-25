using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppMobileRessources.Models
{
    public class Ressources
    {
        [PrimaryKey]
        public int id { get; set; }
        public string titre { get; set; }
        public string contenu { get; set; }

        public override string ToString()
        {
            return this.titre +"(" + this.contenu +")";
        }
    }

}
