using Fiorello.Domain.Entities.Common;

namespace Fiorello.Domain.Entities;

public class Slider:BaseEntity
{
    public string ImagePath { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
