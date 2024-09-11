using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEntityFramework.Models {
    public class Author {
        public int Id { get; set; }//主キー
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public string Gender { get; set; }
        public virtual ICollection<Book> Books { get; set; }

    }
}
