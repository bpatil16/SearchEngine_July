using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine
{
    public class Application
    {
        #region Variables

        private static int appId;
        [Key]
        public int AppNumber { get; private set; }

        public Account AccountDetails { get; set; }
        public Resume ResumeDetails{ get; set; }

        [ForeignKey("Job"), Column(Order = 0)]
        public int JobNumber { get; set; }

      
       public virtual Job Job { get; set; }


        #endregion

        #region Constructor

        public Application()
        {
            AppNumber = ++appId;
        }

        #endregion
    }
}
