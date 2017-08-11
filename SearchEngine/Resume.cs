using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine
{
    public class Resume
    {
        #region Variables

        private static int resumeId;
        [Key]
         public int ResumeNumber { get; private set; }
         public string ResumeName { get; set; }
        public string Description { get; set; }
        public string Education { get; set; }
        public string Skills { get; set; }
        public int AccountNumber { get; set; }
        #endregion

        #region Constructor

        public Resume()
        {
            ResumeNumber = ++resumeId;
        }

        #endregion
    }
}
