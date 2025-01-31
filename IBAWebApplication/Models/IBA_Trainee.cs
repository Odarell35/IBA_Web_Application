using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace IBAWebApplication.Models
{
    public class IBA_Trainee
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string AssignedProducts { get; set; }
        public string TrainingProgram { get; set; }

        public IBA_Trainee()
        {
            
        }

    }
    
}
