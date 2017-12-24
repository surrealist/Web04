using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web04.Models {
  public class Song : MusicItem { 

    public TimeSpan Length { get; set; }
     
  }
}
