using System;
using System.Collections.Generic;

namespace Capstone_4_TaskList_Success.Models
{
    public partial class Job
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool Complete { get; set; }
    }
}
