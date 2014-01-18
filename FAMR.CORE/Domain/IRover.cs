using System.Collections.Generic;
using FAMR.CORE.Models;

namespace FAMR.CORE.Domain
{
  public interface IRover
  {
    void Move(List<Command> commands);
    PositionModel GetPosition();
    bool ObstacleFound { get; }
  }
}