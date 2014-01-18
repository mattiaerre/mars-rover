using System.Collections.Generic;
using FAMR.CORE.Models;

namespace FAMR.CORE.Domain
{
  public class Rover : IRover
  {
    public void Commands(List<Command> commands)
    {
    }

    public PositionModel GetPosition()
    {
      return new PositionModel();
    }
  }
}