using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("Account"), Column(Order = 0) ]
        public int AccountNumber { get; set; }
        [ForeignKey("Account"), Column(Order = 1)] 
        public string EmailAddress { get; set; }
        public virtual Account Account { get; set; }
        #endregion

        #region Constructor

        public Resume()
        {
            ResumeNumber = ++resumeId;
        }

        #endregion
    }
}
