using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web04.Models {
  public class PlaylistMusicItem {
    public int Id { get; set; }
    public Playlist Playlist { get; set; }
    public MusicItem MusicItem { get; set; }
  }
}
