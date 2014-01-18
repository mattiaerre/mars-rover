using System.Collections.Generic;
using FAMR.CORE.Models;

namespace FAMR.CORE.Domain
{
  public interface IRover
  {
    void Commands(List<Command> commands);
    PositionModel GetPosition();
  }
}