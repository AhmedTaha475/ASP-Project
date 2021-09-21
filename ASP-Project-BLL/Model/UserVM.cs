using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_BLL.Model
{
  public  class UserVM
    {

        public string Id { get; set; }
        public string UserName { get; set; }
        
        public string RoleName { get; set; }
    }
}
