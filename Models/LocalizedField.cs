using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace wallaby_api.Models
{
    public class LocalizedField
    {
        [Required]
        public IEnumerable<Translation> Translations { get; set; }
    }

    public class Translation
    {
        [Required]
        public string Lang { get; set; }

        [Required]
        public string Text { get; set; }
    }
}