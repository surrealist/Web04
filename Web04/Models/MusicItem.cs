using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web04.Models {
  public abstract class MusicItem {

    public MusicItem() {
      Playlists = new HashSet<PlaylistMusicItem>();
    }

    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Title { get; set; }

    public ICollection<PlaylistMusicItem> Playlists { get; set; }
  }
}

