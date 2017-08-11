using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine
{
    public class Job
    {
        #region Variables

        private static int jobId;
        [Key]
        public int JobNumber { get; private set; }

        public string JobTitle { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }

        public int AccountNumber { get; set; }

        
        #endregion

        #region Constructor

        public Job()
        {
            JobNumber = ++jobId;
        }

        #endregion
    }

}
