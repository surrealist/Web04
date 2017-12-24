using System.Collections.Generic;

namespace Web04.Models {
  public class Playlist {

    public Playlist() {
      Items = new HashSet<MusicItem>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public ApplicationUser Owner { get; set; }

    public ICollection<MusicItem> Items { get; set; }
  }
}
