using System.ComponentModel.DataAnnotations;

namespace Web04.Models {
  public abstract class MusicItem {

    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Title { get; set; }

  }
}

