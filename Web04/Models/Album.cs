using System;
using System.Collections.Generic;
using System.Linq;

namespace Web04.Models {
  public class Album : MusicItem {

    public Album() {
      Songs = new HashSet<Song>();
    } 

    public string Artist { get; set; }

    public string CoverImageUrl { get; set; }

    // navigation properties
    public ICollection<Song> Songs { get; set; }
     
    public TimeSpan TotalLength => TimeSpan.FromSeconds(Songs.Sum(x => x.Length.TotalSeconds));
  }
}
